using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;



namespace SecondChance
{
    public partial class mainForm : Form
    {
        #region Getters and Setters

        private Complete cmplte;

        public Complete Cmplte
        {
            get { return cmplte; }
            set { cmplte = value; }
        }

        private Welcome wel;

        public Welcome Wel
        {
            get { return wel; }
            set { wel = value; }
        }

        private workWindow wWin;

        public workWindow WWin
        {
            get { return wWin; }
            set { wWin = value; }
        }

        #endregion

        #region Internal Strings, ints and lists

        internal string InstallDir = @"C:\Second_Chance\";
        internal string backupDate = "_" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        internal string backupLocation; 
        internal string ServerName; 
        internal string databaseName; 
        internal string fileToBeBackedUp;
        internal string commandArgs;
        internal string DBNAME;
        internal string xmlPath = "C:\\Info.xml";        
        internal string FTPConf = ".\\FTP.conf";
        internal string ZipPath = ".\\7za.exe"; 
        //internal string ScheduleExeLocation = @"C:\Second_Chance\Second Chance.exe";
        internal string ScheduleExeLocation = Environment.CurrentDirectory + "\\SecondChance.exe";
        internal string FTPServerAddress;
        internal string FTPUsername;
        internal string FTPPassword;
        internal string FileToFTP;
        internal List<string> DBCountList = new List<string>();
        private int index;
        internal bool FTP;

        #endregion

        #region Classes
         internal BackupOperations BackOp;
         internal RestoreOperations RestOp;
         internal CompressOperations CompOp;
         internal FTP FtpOp;
         internal Schedule SchedOp;
        #endregion

        #region Delegates
        private delegate void updateStatusLabelSafe(string message, int errorCode);
        private delegate void updateProgressBarSafe(int val);
        private delegate void updateErrorTextSafe(string message,bool error);
        private delegate void ChangeSelectedTabSafe(int tab);
        #endregion

        public mainForm(string args)
        {
            InitializeComponent();

            cmplte = new Complete(this);
            wel = new Welcome(this);
            wWin = new workWindow(this);

            commandArgs = args;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (commandArgs == null) //if no arguments exist run the GUI
            {
                this.pnlMain.Controls.Add(wel);
                this.wel.Dock = DockStyle.Fill;
                this.WindowState = FormWindowState.Normal;

                this.index = 0; //set index to 0 (welcome screen);
            }
            else
            {
                //if commands are present start Hidden 
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                //& start new Thread of AutoDoWork method.
                Thread th = new Thread(new ThreadStart(AutoDoWork));
                th.Name = "Worker Thread";
                th.IsBackground = true;
                th.Start();
            }
        }

        #region Initialize Classes
        private void LoadBackupClass()
        {
            BackOp = new BackupOperations(this);           
        }
        private void LoadRestoreClass()
        {
            RestOp = new RestoreOperations(this);
        }
        private void LoadCompressClass()
        {
            CompOp = new CompressOperations(this);
        }
        private void LoadFTPClass()
        {
            FtpOp = new FTP(this);
        }
        internal void LoadScheduleClass()
        {
            SchedOp = new Schedule(this);
        }
        #endregion

        #region Delegates to Update UI
        internal void updateProgressBar(int val)
        {
            if (this.wWin.pBarBackup.InvokeRequired)
            {
                this.wWin.pBarBackup.Invoke(new updateProgressBarSafe(this.updateProgressBar), new object[] { val });
            }
            else
            {
                if (!this.wWin.pBarBackup.Visible)
                    {
                        this.wWin.pBarBackup.Visible = true;
                        //lblPercent.Visible = true;
                        //this.lblPercent.Text = val.ToString() + "%";
                    }
                    if (val == 100)
                    {
                        this.wWin.pBarBackup.Visible = false;
                        this.wWin.pBarBackup.Dispose();
                        this.lblPercent.Visible = false;
                        this.lblPercent.Text = val.ToString() + "%";                    
                       
                        
                        this.wWin.gBoxBupSelection.Visible = true;
                        this.wWin.gBoxBackingUp.Visible = false;
                       // this.btnNext.Enabled = true;
                        //this.btnNext.Text = "Backup";
                        this.wWin.lblBackupStatus.Text = "%";                   
                        
                    }
                
                this.lblPercent.Text = val.ToString() + "%";
                this.wWin.pBarBackup.Value = val;
            }
        }
        internal void updateStatusLabel(string message,int errorCode)
        {
            if (this.lblStatus.InvokeRequired)
            {
                this.lblStatus.Invoke(new updateStatusLabelSafe(this.updateStatusLabel), new object[] { message,errorCode });
            }
            else
            {
                if (message.Equals("Backup of " + databaseName + " Successful"))
                {                    
                    this.btnNext.Text = "Done";
                    this.btnNext.Enabled = true;
                }
                else if (message.Equals("Compressing Database: " + databaseName))
                {
                    this.wWin.pBarComp.Style = ProgressBarStyle.Marquee;
                    this.wWin.pBarComp.MarqueeAnimationSpeed = 50;
                    this.wWin.pBarComp.Visible = true;
                    this.wWin.pBarComp.Enabled = true;
                }
                else if (message.Equals("Compression Complete!"))
                {
                    this.wWin.pBarComp.Visible = false;
                    this.btnNext.Text = "Done";
                    this.btnNext.Enabled = true;
                }
                if(!this.lblStatus.Visible)
                {
                    this.lblStatus.Visible = true;
                }
                if (errorCode == 1)
                {      
                    this.btnBack.Visible = true;
                    this.btnNext.Enabled = false;
                }
                if (this.wWin.gBoxBupSelection.Visible)
                {
                    this.wWin.gBoxBupSelection.Visible = false;
                    this.wWin.gBoxBackingUp.Visible = true;
                }

                this.wWin.lblBackupStatus.Text = message;               
                this.lblStatus.Text = message;

            }
        }
        internal void updateErrorText(string message, bool error)
        {
            if (this.lblStatus.InvokeRequired)
            {
                this.lblStatus.Invoke(new updateErrorTextSafe(this.updateErrorText), new object[] { message,error });
            }
            else
            {
                if (error)
                {
                    this.wWin.btnErrorpnl.Visible = true;
                    this.wWin.txtlblError.Text = message;
                }
                else
                {
                    this.wWin.btnErrorpnl.Visible = false;
                }
            }
        }
        internal void ChangeSelectedTab(int tab)
        {
            if (this.wWin.tabCont.InvokeRequired)
            {
                this.wWin.tabCont.Invoke(new ChangeSelectedTabSafe(this.ChangeSelectedTab), new object[] { tab });
            }
            else
            {
                this.wWin.tabCont.SelectedIndex = tab;
                
            }
        }
        #endregion 

        #region Button Clicks

        private void btnNext_Click(object sender, EventArgs e)
        {
            #region Welcome Screen
            if (index == 0) //welcome panel
            {
                this.btnNext.Enabled = false;
                this.btnNext.Text = "Backup";
                this.pnlMain.Controls.Remove(wel);
                this.pnlMain.Controls.Add(wWin);
                this.wWin.Dock = DockStyle.Fill;
                this.index = 1; //set index to 1.
                getBackupInfo(); //get info to populate listbox
            }
            #endregion            
            else if (index == 1) //main panel
            {
                #region Done and Exit Buttons
                if (this.btnNext.Text == "Done") //will display last page.
                {
                    this.pnlMain.Controls.Remove(wWin);
                    this.pnlMain.Controls.Add(cmplte);
                    this.cmplte.Dock = DockStyle.Fill;
                    this.btnNext.Text = "Exit";
                    this.btnBack.Text = "Restart";
                    this.btnBack.Visible = true;
                }
                else if (this.btnNext.Text == "Exit") //will exit application.
                {
                    Environment.Exit(0);
                }
                #endregion 
                else
                {
                    #region Backup
                    if (this.wWin.tabCont.SelectedTab.Text == "Backup") //checks if backup tab is selected when 'this' button is clicked
                    {
                        if (this.wWin.txtFTPServer.Text != "" && this.wWin.txtFTPUser.Text != "" && this.wWin.txtFTPPass.Text != "")
                        {
                            if (this.wWin.chkBoxFTP.Checked)
                            {
                                FTP = true;
                            }
                            else
                            {
                                FTP = false;
                            }
                        }
                        
                        LoadBackupClass(); //load classes and methods 

                        this.wWin.gBoxBupSelection.Visible = false;
                        this.wWin.gBoxBackingUp.Visible = true;
                        this.wWin.pBarBackup.Value = 0;
                        this.wWin.pBarBackup.Maximum = 100;
                        this.btnNext.Enabled = false;


                        //runs backup class in new thread
                        ThreadStart ts = delegate() { this.BackOp.ManualBackupDatabase(wWin.txtDbName.Text, wWin.txtServerName.Text, wWin.txtBackupLocation.Text + wWin.txtDbName.Text + backupDate + ".bak"); };
                        Thread backupThread = new Thread(ts);
                        backupThread.Name = "ManualBackup Thread";
                        backupThread.Start();


                    }
                    #endregion
                    #region Restore
                    else if (this.wWin.tabCont.SelectedTab.Text == "Restore")
                    {
                        LoadRestoreClass();

                        this.wWin.lblRestoreStatus.Visible = true;
                        this.wWin.lblRestoreStatus.Text = "Please Wait...";
                        this.btnNext.Enabled = false;

                        ThreadStart ts = delegate() { this.RestOp.RestoreDatabase(this.wWin.txtRestDbName.Text, this.wWin.txtRestFileLocation.Text, this.wWin.txtRestServerName.Text, this.wWin.txtRestoreLocation.Text); };
                        Thread backupThread = new Thread(ts);
                        backupThread.Start();
                    }
                    #endregion
                    #region FTP
                    else if (this.wWin.tabCont.SelectedTab.Text == "FTP")
                    {
                        this.wWin.lblFTPError.Visible = false;

                        LoadFTPClass(); //load FTP class

                        this.btnNext.Enabled = false;

                        ThreadStart ts = delegate() { this.FtpOp.UploadFile(this.wWin.txtFTPServer.Text, this.wWin.txtFTPFileBrowse.Text, this.wWin.txtFTPUser.Text, this.wWin.txtFTPPass.Text); };
                        Thread FTPThread = new Thread(ts);
                        FTPThread.Name = "FTP Thread";
                        FTPThread.Start();

                        if (FTPThread.IsAlive)
                        {
                            this.wWin.btnFTPCancel.Visible = true;
                        }

                    }
                    #endregion
                    #region Databases
                    else if (this.wWin.tabCont.SelectedTab.Text == "Databases")
                    {
                    }
                    #endregion 
                    #region Schedule
                    else if (this.wWin.tabCont.SelectedTab.Text == "Schedule")
                    {
                    }
                    #endregion 
                }
            }
            
            
        }
        

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.btnBack.Text == "Restart")
            {
                Application.Restart();
            }
            else
            {
                this.wWin.gBoxBupSelection.Visible = true;
                this.wWin.gBoxBackingUp.Visible = false;
                this.btnNext.Enabled = true;
                this.btnNext.Text = "Next";
                this.wWin.lblBackupStatus.Text = "%";
                this.btnBack.Visible = false;
                this.wWin.btnErrorpnl.Visible = false;
            }
        }

        #endregion

        #region Methods

        #region Schedule
        private void AutoDoWork()
        {
            #region Backup All
            if (commandArgs.ToUpper() == "ALL")
            {
                LoadBackupClass(); //load classes 
                LoadCompressClass();//<-|
                LoadFTPClass();//<-|
                this.wWin.GetFTPDetails();
                
                
                if (getBackupInfo())
                {
                    for (int i = 0; i < this.DBCountList.Count; i++) //loop through list to find number of databases to be backed up.
                    {
                        #region Run operations on each item in loop

                        this.commandArgs = this.DBCountList[i]; //set commandargs to 'i'.
                       
                        try
                        {

                            if (getBackupInfo()) //if information was successfully grabbed from XML
                            {
                                if (this.BackOp.AutoBackupDatabase(this.databaseName, this.ServerName, this.backupLocation + this.databaseName + this.backupDate + ".bak")) //backup database
                                {
                                    //write to eventlog
                                    WriteLog("Backup of Database: " + this.databaseName + " Completed Successfully.\r\nAttempting to compress backup file.\r\n" + DateTime.Now,0);

                                    if (this.CompOp.AutoCompressBackup(this.databaseName + this.backupDate, this.backupLocation, this.fileToBeBackedUp)) //compress file
                                    {
                                        //write to eventlog
                                        WriteLog("The file " + this.fileToBeBackedUp + " was successfully compressed.\r\nAttempting to clean up the temporary backup file.\r\n" + DateTime.Now,0);

                                        try
                                        {                                            
                                            File.Delete(this.fileToBeBackedUp); //delete backup file
                                            WriteLog(this.fileToBeBackedUp + " was deleted Successfully.\r\nStarting FTP Upload of " +this.backupLocation + this.databaseName + this.backupDate + ".7z\r\n" + DateTime.Now,0);
                                        }
                                        catch(Exception exc)
                                        {   //write error to eventlog
                                             WriteLog(this.fileToBeBackedUp + " Was not deleted!\r\n" + exc.Message,1);
                                        }

                                        try
                                        {
                                            if (File.Exists(FileToFTP))
                                            {
                                                FileToFTP = this.backupLocation + this.databaseName + this.backupDate + ".7z"; //this is the final zipped file to be FTP'd.                                           
                                                //write to eventlog
                                                WriteLog("Attempting to FTP the file: " + FileToFTP, 0);
                                                if (this.FtpOp.AutoUploadFile(this.FTPServerAddress, FileToFTP, this.FTPUsername, this.FTPPassword))
                                                {
                                                    WriteLog("The file " + FileToFTP + " was uploaded successfully.", 0);
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            //write error to eventlog
                                            WriteLog("The file : " + this.FileToFTP + " failed to upload.\r\nCheck Previous logs for details." + DateTime.Now, 2);
                                        }
                                        
                                    }
                                    else
                                    {
                                        //write error to eventlog
                                        WriteLog(this.fileToBeBackedUp + " Compress failed!", 2);
                                        Environment.Exit(0);
                                    }

                                }
                                else
                                {
                                    //write error to eventlog
                                    WriteLog("The Database backup failed for: " + this.databaseName + "\r\nSee previous logs for more details.", 2);
                                    Environment.Exit(0);
                                }
                            }
                            else
                            {
                                //write error to eventlog
                                WriteLog("Database information could not be found in the Info.XML file.", 1);
                                Environment.Exit(0);
                            }
                        }
                        catch(Exception ex)
                        {
                            //write error to eventlog
                            WriteLog(ex.Message, 2);
                            Environment.Exit(0);
                        }

                        #endregion
                    }
                    //write error to eventlog
                    WriteLog("The process has completed successfully.\r\n" + DateTime.Now, 0);
                    Environment.Exit(0);
                }
            }
            #endregion
            #region Individual Backups
            else
            {
                
                LoadBackupClass(); //load classes and methods 
                LoadCompressClass();//<-|
                LoadFTPClass(); //<-|

                try
                {

                    if (getBackupInfo()) //if information was successfully grabbed from XML
                    {
                        if (this.BackOp.AutoBackupDatabase(this.databaseName, this.ServerName, this.backupLocation + this.databaseName + this.backupDate + ".bak")) //backup database
                        {
                            //write to eventlog
                            WriteLog("Backup of Database: " + this.databaseName + " Completed Successfully.\r\nAttempting to compress backup file.\r\n" + DateTime.Now, 0);

                            if (this.CompOp.AutoCompressBackup(this.databaseName + this.backupDate, this.backupLocation, this.fileToBeBackedUp)) //compress file
                            {
                                //write to eventlog
                                WriteLog("The file " + this.fileToBeBackedUp + " was successfully compressed.\r\nAttempting to clean up the temporary backup file.\r\n" + DateTime.Now, 0);

                                try
                                {                                    
                                    File.Delete(this.fileToBeBackedUp); //delete backup file
                                    WriteLog(this.fileToBeBackedUp + " was deleted Successfully.\r\nStarting FTP Upload of " + this.backupLocation + this.databaseName + this.backupDate + ".7z\r\n" + DateTime.Now, 0);
                                }
                                catch (Exception exc)
                                {
                                    //write error to eventlog
                                    WriteLog(this.fileToBeBackedUp + " Was not deleted!\r\n" + exc.Message, 1);
                                }

                                try
                                {
                                    if (File.Exists(FileToFTP))
                                    {
                                        FileToFTP = this.backupLocation + this.databaseName + this.backupDate + ".7z"; //this is the final zipped file to be FTP'd.                                           
                                        //write to eventlog
                                        WriteLog("Attempting to FTP the file: " + FileToFTP, 0);
                                        if (this.FtpOp.AutoUploadFile(this.FTPServerAddress, FileToFTP, this.FTPUsername, this.FTPPassword))
                                        {
                                            WriteLog("The file " + FileToFTP + " was uploaded successfully.", 0);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //write error to eventlog
                                    WriteLog("The file : " + this.FileToFTP + " failed to upload.\r\nCheck Previous logs for details." + DateTime.Now, 2);
                                }

                            }
                            else
                            {
                                //write error to eventlog
                                WriteLog(this.fileToBeBackedUp + " Compress failed!", 2);
                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            //write error to eventlog
                            WriteLog("The Database backup failed for: " + this.databaseName + "\r\nSee previous logs for more details.", 2);
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        //write error to eventlog
                        WriteLog("Database information could not be found in the Info.XML file.", 1);
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    //write error to eventlog
                    WriteLog(ex.Message, 2);
                    Environment.Exit(0);
                }
                //write error to eventlog
                WriteLog("The process has completed successfully.\r\n" + DateTime.Now, 0);
                Environment.Exit(0);
            }
                #endregion
        }
        #endregion

        #region Get XML Info
        internal bool getBackupInfo()
        {
            #region Scheduled Backup
            if (this.commandArgs != null) //if arguments exist (Scheduled Backup).
            {
                #region Backup ALL add to List
                if (this.commandArgs.ToUpper() == "ALL")
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Backups));
                    TextReader reader = new StreamReader(xmlPath);
                    Backups backups = (Backups)xs.Deserialize(reader);
                    reader.Close();

                    for (int i = 0; i < backups.Databases.Length; i++) //loop through XML
                    {
                        DBCountList.Add(backups.Databases[i].ID.ToString());     //add ID's to list.                   
                    }
                    if (DBCountList.Count != 0)
                    {
                        return true;
                    }
                }
                #endregion
                else
                {
                    try
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(Backups));
                        TextReader reader = new StreamReader(xmlPath);
                        Backups backups = (Backups)xs.Deserialize(reader);
                        reader.Close();

                        for (int i = 0; i < backups.Databases.Length; i++) //loop through XML
                        {
                            if (backups.Databases[i].ID.ToString() == commandArgs)
                            {
                                this.backupLocation = backups.Databases[i].BackupLocation; //Get and Set Backuplocation, servername, databasename(Respectively).
                                this.ServerName = backups.Databases[i].ServerName;
                                this.databaseName = backups.Databases[i].DBName;
                                ////
                                this.fileToBeBackedUp = this.backupLocation + this.databaseName + this.backupDate + ".bak"; //Local variable.
                                ////
                                if (this.backupLocation != "" && this.ServerName != "" && this.databaseName != "")
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    catch
                    {
                        return false;
                    }
            #endregion
                }
            }
            #region UI Displayed
            else //if no arguments exist (UI Displayed).
            {
                try
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Backups));
                    TextReader reader = new StreamReader(xmlPath);
                    Backups backups = (Backups)xs.Deserialize(reader);
                    reader.Close();

                    for (int i = 0; i < backups.Databases.Length; i++) //loop through XML
                    {
                        this.databaseName = backups.Databases[i].DBName;
                        this.wWin.lboxDatabases.Items.Add(databaseName); //populates listbox 
                        this.backupLocation = backups.Databases[i].BackupLocation;  //sets backupLocation local string with XML data.

                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
            #endregion
        }
        internal void CreateXML()
        {
            Assembly A = Assembly.GetExecutingAssembly();
            string[] names = A.GetManifestResourceNames();

            foreach (string filename in names)
            {
                Stream S = A.GetManifestResourceStream(filename);
                byte[] rawFile = new byte[S.Length];
                S.Read(rawFile, 0, (int)S.Length);

                if (filename.Equals("SecondChance.Info.xml"))
                {
                    string rename = filename.Replace("SecondChance.", "");

                    using (FileStream fs = new FileStream(this.xmlPath,FileMode.Create))
                    {
                        fs.Write(rawFile,0,(int)S.Length);
                    }
                }
            }
        }
        #endregion        

        internal void ExtractsevenZip()
        {
            Assembly A = Assembly.GetExecutingAssembly();
            string[] names = A.GetManifestResourceNames();

            foreach (string filename in names)
            {
                Stream S = A.GetManifestResourceStream(filename);
                byte[] rawFile = new byte[S.Length];
                S.Read(rawFile, 0, (int)S.Length);

                if (filename.Equals("SecondChance.7za.exe"))
                {
                    string rename = filename.Replace("SecondChance.", "");

                    using (FileStream fs = new FileStream(backupLocation + "7za.exe",FileMode.Create))
                    {
                        fs.Write(rawFile,0,(int)S.Length);
                    }
                }
            }
        }

        internal void ManualBackupThreadCallBack()
        {
            //DBNAME = this.wWin.txtBackupLocation.Text + this.wWin.txtDbName.Text + this.backupDate;
            DBNAME = this.wWin.txtDbName.Text + this.backupDate;
            this.fileToBeBackedUp = this.wWin.txtBackupLocation.Text + this.wWin.txtDbName.Text + this.backupDate + ".bak";

            if (this.wWin.chkBoxCompress.Checked)
            {
                if (this.CompOp != null)
                {
                    ThreadStart ts = delegate() { this.CompOp.ManualCompressBackup(DBNAME, backupLocation, fileToBeBackedUp); };
                    Thread compressThread = new Thread(ts);
                    compressThread.Name = "ManualCompression Thread";
                    compressThread.Start();

                }
                else
                {
                    LoadCompressClass(); //load compress class

                    //start compress in new thread and pass params.
                    ThreadStart ts = delegate() { this.CompOp.ManualCompressBackup(DBNAME, backupLocation, fileToBeBackedUp); };
                    Thread compressThread = new Thread(ts);
                    compressThread.Name = "ManualCompression Thread";
                    compressThread.Start();

                }
            }
        }
        internal void ManualCompressCallBack(int exitCode)
        {
            string FileToFTP = DBNAME + ".7z"; //this is the final zipped file to be FTP'd.

            if (exitCode == 0)
            {
                this.updateStatusLabel("Compression Complete!", 0);                
                try
                {
                    File.Delete(fileToBeBackedUp); //delete backup file
                    File.Delete(backupLocation + "7za.exe");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (FTP)
                {
                    try
                    {
                        this.LoadFTPClass();
                        this.updateStatusLabel("Uploading to FTP Server..", 0);
                        ChangeSelectedTab(2);
                        this.FtpOp.UploadFile(this.wWin.txtFTPServer.Text, FileToFTP, this.wWin.txtFTPUser.Text, this.wWin.txtFTPPass.Text);                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                
            }
            else
            {
                MessageBox.Show("An error has occured!\n\rThe file could not be compressed.\n\rZip Error Code: " + exitCode, "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region EventLog
        internal void WriteLog(string LogMessage,int EventType)
        {
            EventLog log = new EventLog();
            log.Log = "Application";
            log.Source = "Second Chance";

            if (EventType == 0)
            {
                log.WriteEntry(LogMessage, EventLogEntryType.Information);
            }
            else if (EventType == 1)
            {
                log.WriteEntry(LogMessage, EventLogEntryType.Warning);
            }
            else if (EventType == 2)
            {
                log.WriteEntry(LogMessage, EventLogEntryType.Error);
            }
    
            
        }
        #endregion

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string proc = "7za";
            Process[] processes = Process.GetProcessesByName(proc);

            if (processes.Length > 0)
            {
                foreach (Process p in processes)
                {
                    try
                    {
                        p.Kill();
                    }
                    catch
                    {

                    }
                }
            }
        }

        #endregion
    }
}
