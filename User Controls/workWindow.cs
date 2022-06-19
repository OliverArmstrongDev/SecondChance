using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32.TaskScheduler;
using System.Xml;

namespace SecondChance
{
    public partial class workWindow : UserControl
    {
        private mainForm _mF;
        Timer errTm;
        internal DaysOfTheWeek dayofweek;
        internal string ArgsToPass;
        internal delegate void FTPProgBarUpdateSafe(int max, int val);
        internal delegate void RestoreProgBarUpdateSafe(int val, bool visible);


        public workWindow(mainForm main)
        {
            this._mF = main;
            InitializeComponent();
            GetFTPDetails(); 
        }

        #region Dialog Boxes
        private void btnSaveBrowse_Click(object sender, EventArgs e)
        {
            if (this.txtDbName.Text != "" && this.txtServerName.Text != "") //if textboxes are not empty..
            {
                this.backupLocationDialog.RootFolder = Environment.SpecialFolder.MyComputer;
                this.backupLocationDialog.ShowNewFolderButton = true;
                this.backupLocationDialog.Description = "Select a folder to save the backup to...";

                if (this.backupLocationDialog.ShowDialog() == DialogResult.OK) //if ok is clicked..
                {
                    this.txtBackupLocation.Text = backupLocationDialog.SelectedPath + "\\"; //set backuplocation as selected path
                   // this.btnSaveNew.Visible = true;
                    this._mF.btnNext.Enabled = true;    //set text and enable button.
                    this._mF.btnNext.Text = "Backup";
                }
                else
                {
                    //this.btnSaveNew.Visible = false;    //Don't enable button.
                    this._mF.btnNext.Enabled = false;
                }
            }
            else
            {
                //if textboxes are empty
                MessageBox.Show("You must specifiy a Database Name and a Server Name before you can select a Backup Location!", "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }
        private void btnRestoreBrowse_Click(object sender, EventArgs e)
        {
            if (this.txtRestDbName.Text != "" && this.txtRestServerName.Text != "" && this.txtRestoreLocation.Text != "")
            {
                this.RestoreBrowserDialog.InitialDirectory = "C:\\";
                this.RestoreBrowserDialog.Multiselect = false;
                this.RestoreBrowserDialog.Filter = "BAK files (*.bak)|*.bak";
                this.RestoreBrowserDialog.FileName = "";
                if (this.RestoreBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.txtRestFileLocation.Text = RestoreBrowserDialog.FileName; //set restorefile as selected file
                    _mF.btnNext.Enabled = true;
                    _mF.btnNext.Text = "Restore";       //set text and enable button.
                }
                else
                {
                    //this.btnSaveNew.Visible = false;    //Don't enable button.
                }
            }
            else
            {
                //if textboxes are empty
                MessageBox.Show("You must specifiy a Database Name a Server Name and a Restore Location before you can select a file to Restore!", "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }        
        #endregion

        #region Delegates
        internal void FTPProgBarUpdate(int max, int val)
        {
            if (this.pbarFTP.InvokeRequired)
            {
                this.pbarFTP.Invoke(new FTPProgBarUpdateSafe(this.FTPProgBarUpdate), new object[] { max, val });
            }
            else
            {
                if (val == max)
                {
                    this.pbarFTP.Visible = false;
                    this.lblFTPPercent.Visible = false;
                    this.btnFTPCancel.Visible = false;
                    this._mF.updateStatusLabel("Upload Complete!", 0);
                    this._mF.btnNext.Text = "Done";
                    this._mF.btnNext.Enabled = true;
                }
                else
                {
                    this.lblFTPPercent.Visible = true;
                    this.lblFTPPercent.Text = (val * 100 / max).ToString() + " %";
                    this.pbarFTP.Visible = true;
                    this.pbarFTP.Maximum = max;
                    this.pbarFTP.Value = val;
                }
            }
        }
        internal void RestoreProgBarUpdate(int val, bool visible)
        {
            if (this.pBarRestore.InvokeRequired)
            {
                this.pBarRestore.Invoke(new RestoreProgBarUpdateSafe(this.RestoreProgBarUpdate), new object[] { val, visible });
            }
            else
            {
                if (this.pBarRestore.Value == pBarRestore.Maximum)
                {
                    this.lblRestoreStatus.Visible = true;
                    this.lblRestoreStatus.Text = "Restore Complete";
                    this._mF.btnNext.Enabled = true;
                    this._mF.btnNext.Text = "Done";
                }
                else
                {

                    this.lblRestoreStatus.Text = "Restoring...";
                    this.pBarRestore.Visible = visible;
                    this.pBarRestore.Value = val;
                }


            }
        }
        #endregion

        #region listbox
        private void lboxDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lboxDatabases.SelectedItem != null)
            {
                if (this.cBBackupAll.Checked)
                {
                    this.cBBackupAll.Checked = false;
                }
                if(!this.gBoxSchedule.Enabled)
                {
                    this.gBoxSchedule.Enabled = true;
                }
                this.lblSchedSelectedDB.Visible = true;
                this.lblSchedSelectedDB.Text = "Schedule for " + this.lboxDatabases.SelectedItem.ToString(); //edits a label in the schedule tab.
                GetScheduleInfo(this.lboxDatabases.SelectedItem.ToString());

                #region Populate textboxes from selected item...
                XmlSerializer xs = new XmlSerializer(typeof(Backups));
                TextReader reader = new StreamReader(_mF.xmlPath);
                Backups backups = (Backups)xs.Deserialize(reader);
                reader.Close();

                for (int i = 0; i < backups.Databases.Length; i++) //loop through XML
                {
                    if (backups.Databases[i].DBName.ToString() == this.lboxDatabases.SelectedItem.ToString())
                    {
                        this.txtDbName.Text = backups.Databases[i].DBName;            //populates backup textboxes.. 
                        this.txtServerName.Text = backups.Databases[i].ServerName;    //..depending on selected item in listbox.
                        this.txtBackupLocation.Text = backups.Databases[i].BackupLocation;
                       
                        

                        /////////////////Restore Tab TextBoxes/////////////
                        this.txtRestDbName.Text = backups.Databases[i].DBName;           //also populates restore textboxes.
                        this.txtRestServerName.Text = backups.Databases[i].ServerName;

                        /////////////////Databases Tab TextBoxes/////////////
                        this.txtDbaseID.Text = backups.Databases[i].ID.ToString();
                        this.txtDbaseDBName.Text = backups.Databases[i].DBName; 
                        this.txtDbaseServer.Text = backups.Databases[i].ServerName;                        
                        this.txtDbaseLocation.Text = backups.Databases[i].BackupLocation;


                        ////////////////////////////////////////////////////
                        this._mF.fileToBeBackedUp = txtDbName.Text + this._mF.backupDate + ".bak"; //Local variables.
                        this._mF.databaseName = txtDbName.Text;
                        this.ArgsToPass = backups.Databases[i].ID.ToString();
                    }
                }
                #endregion 

                //checks which tab is currently selected
                if (this.tabCont.SelectedTab.Text == "Backup")
                {
                    ///if all textboxes are populated.
                    if (this.txtBackupLocation.Text != "" && this.txtDbName.Text != "" && this.txtServerName.Text != "")
                    {
                        _mF.btnNext.Enabled = true; //enable next button
                        this.chkBoxFTP.Visible = true;
                        this.chkBoxCompress.Visible = true;
                    }
                    else
                    {
                        _mF.btnNext.Enabled = false; //Don't enable next button
                        this.chkBoxFTP.Visible = false;
                        this.chkBoxCompress.Visible = false;
                    }
                }
                else if (this.tabCont.SelectedTab.Text == "Schedule")
                {
                    if (this.lBoxSchedTimes.Items.Count != 0)
                    {
                        this.btnDelete.Enabled = true;
                    }
                    else
                    {
                        this.btnDelete.Enabled = false;
                    }
                }
                else if (this.tabCont.SelectedTab.Text == "Databases")
                {
                    this.btnDBDelete.Enabled = true;
                    this.btnDBSave.Enabled = true;
                    this.txtDbaseID.Enabled = true;
                }
                else
                {
                    ///if all textboxes are empty display messagebox.
                    if (this.txtRestFileLocation.Text != "" && this.txtRestDbName.Text != "" && this.txtRestServerName.Text != "")
                    {
                        MessageBox.Show("No fields can be empty!", "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }        
        #endregion 

        #region Tab Change
        private void tabClick(object sender, EventArgs e)
        {
            //checks which tab is currently selected(Backup or Restore)
            if (this.tabCont.SelectedTab.Text == "Backup")
            {
                this._mF.btnNext.Text = "Backup"; //sets button text

                if (this.txtBackupLocation.Text != "") //if backuplocation is not empty
                {
                    this._mF.btnNext.Enabled = true; //enable button
                    this.chkBoxFTP.Visible = true;
                    this.chkBoxCompress.Visible = true;
                }
                else
                {
                    this._mF.btnNext.Enabled = false; //Don't enable button
                    this.chkBoxFTP.Visible = false;
                    this.chkBoxCompress.Visible = false;

                }
            }
            else if (this.tabCont.SelectedTab.Text == "Restore")
            {
                this._mF.btnNext.Text = "Restore"; //sets button text

                if (this.txtRestFileLocation.Text != "") //if restore file selection is not empty
                {
                    this._mF.btnNext.Enabled = true; //enable button
                }
                else
                {
                    this._mF.btnNext.Enabled = false; //Don't enable button
                }
            }
            else if (this.tabCont.SelectedTab.Text == "FTP")
            {
                GetFTPDetails();
                this.txtFTPServer.Text = this._mF.FTPServerAddress;
                this.txtFTPUser.Text = this._mF.FTPUsername;
                this.txtFTPPass.Text = this._mF.FTPPassword;

                this._mF.btnNext.Text = "Upload";
                if (this.txtFTPFileBrowse.Text != "") //if restore file selection is not empty
                {
                    this._mF.btnNext.Enabled = true; //enable button
                }
                else
                {
                    this._mF.btnNext.Enabled = false; //Don't enable button
                }

            }
            else if (this.tabCont.SelectedTab.Text == "Schedule")
            {
                this._mF.btnNext.Enabled = true;
                this._mF.btnNext.Text = "Done";
                if (this.lboxDatabases.SelectedItem != null)
                {
                    this.gBoxSchedule.Enabled = true;                    
                }
                else
                {
                    this.gBoxSchedule.Enabled = false;                    
                    MessageBox.Show("Select a Database from the left to create a schedule.","Second Chance",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    
                }
            }
            else if (this.tabCont.SelectedTab.Text == "Databases")
            {
                this._mF.btnNext.Enabled = true;
                this._mF.btnNext.Text = "Done";
                if (this.txtDbaseDBName.Text == string.Empty)
                {
                    this.btnDBDelete.Enabled = false;
                    this.btnDBSave.Enabled = false;

                    if (this.lboxDatabases.SelectedItem == null)
                    {
                        this.txtDbaseID.Enabled = false;
                    }
                }
                else
                {
                    this.btnDBDelete.Enabled = true;
                    this.btnDBSave.Enabled = true;
                    this.txtDbaseID.Enabled = true;
                }
            }
        }
        #endregion

        #region SaveButton
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Backups));
            TextReader reader = new StreamReader(this._mF.xmlPath);
            Backups backups = (Backups)xs.Deserialize(reader);
            reader.Close();



        }
        #endregion

        #region FTP
        internal void GetFTPDetails()
        {

            if (File.Exists(this._mF.FTPConf))
            {
                StreamReader file = new StreamReader(this._mF.FTPConf);
                string[] line = file.ReadLine().Split('^');

                this._mF.FTPServerAddress = line[0].ToString();
                this._mF.FTPUsername = line[1].ToString();
                this._mF.FTPPassword = line[2].ToString();

                file.Close();
            }
        }        
        private void btnFTPBrowse_Click(object sender, EventArgs e)
        {
            this.FTPSelectFileDialog.InitialDirectory = "C:\\";
            this.FTPSelectFileDialog.Multiselect = false;
            this.FTPSelectFileDialog.Filter = "All files (*.*)|*.*";
            this.FTPSelectFileDialog.FileName = "";
            if (this.FTPSelectFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtFTPFileBrowse.Text = FTPSelectFileDialog.FileName; //set FTP file as selected file
                this._mF.btnNext.Enabled = true;
            }
            else
            {

            }
        }
        private void btnFTPCancel_Click(object sender, EventArgs e)
        {
            this.pbarFTP.Visible = false;
            this.lblFTPPercent.Visible = false;
            this._mF.FtpOp.IsCancelPending = true;
            this.btnFTPCancel.Visible = false;
            this.lblFTPError.Visible = true;
            this.lblFTPError.Text = "The upload has been canceled";
        }
        private void chkBoxFTP_CheckedChanged(object sender, EventArgs e)
        {
            GetFTPDetails();
            this.txtFTPServer.Text = this._mF.FTPServerAddress;
            this.txtFTPUser.Text = this._mF.FTPUsername;
            this.txtFTPPass.Text = this._mF.FTPPassword;

            if (this.txtFTPServer.Text == "" || this.txtFTPUser.Text == "" || this.txtFTPPass.Text == "")
            {
                if (this.chkBoxFTP.Checked)
                {
                    DialogResult DR = MessageBox.Show("All FTP Details must be entered on the FTP tab.\r\nWould you like to do this now?", "Second Chance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DR == DialogResult.Yes)
                    {
                        this._mF.ChangeSelectedTab(2);
                    }
                    else if (DR == DialogResult.No)
                    {
                        MessageBox.Show("The Selected Database will be backed up and compressed\r\nhowever it cannot be FTP'd until All FTP details have been entered on the FTP tab.", "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.chkBoxFTP.Checked = false;
                    }
                }
            }

        }
        private void btnFTPSave_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"C:\Second_Chance\"))
            {
                Directory.CreateDirectory(@"C:\Second Chance\");
            }

            try
            {
                FileInfo save = new FileInfo(@"C:\Second Chance\FTP.conf");
                StreamWriter s = save.CreateText();
                s.WriteLine(this.txtFTPServer.Text + "^" + this.txtFTPUser.Text + "^" + this.txtFTPPass.Text);
                s.Close();
                lblFTPError.Visible = true;
                lblFTPError.Text = "FTP Details Saved!.";
            }
            catch
            {

            }
        }
        #endregion

        #region Schedule
        private void btnSchedGet_Click(object sender, EventArgs e)
        {
            this._mF.LoadScheduleClass();
            this._mF.SchedOp.CreateSchedule();
            //string tmp = this._mF.SchedOp.GetSchedule();
            //string[] tasks = tmp.Split(',');

            //this.textBox1.Text = tasks[0] + " " + tasks[1];
            //this.textBox2.Text = tasks[3];
            //this.textBox3.Text = tasks[2] + tasks[4];
        }
        private void cBDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cBDaily.Checked)
            {
                txtDaily.Enabled = true;
            }
            else
            {
                txtDaily.Enabled = false;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if ((this.cBDaily.Checked == false) && (this.cBWeekly.Checked == false))
            {
                MessageBox.Show("You must select a Daily or Weekly Schedule Type!",
                 "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if(!File.Exists("C:\\Second_Chance\\Second_Chance.exe"))
                {
                    //MessageBox.Show("You need 
                }
                this._mF.LoadScheduleClass();

                if (this.cBBackupAll.Checked)
                {
                    if (this._mF.SchedOp.CreateScheduleForALL())
                    {
                        DialogResult saved = MessageBox.Show("Schedule for ALL databases saved!",
                         "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (saved == DialogResult.OK)
                        {
                            this._mF.btnNext.Enabled = true;
                            GetScheduleInfo("ALL");
                        }
                    }
                    else
                    {
                        this.lblSchedStatus.Text = "An error occured!\r\nCheck the Windows Application Event logs for details on the error.";
                        this.lblSchedStatus.Visible = true;
                    }
                }
                else
                {

                    if (this._mF.SchedOp.CreateSchedule())
                    {
                        DialogResult saved = MessageBox.Show("Schedule for " + this.lboxDatabases.SelectedItem.ToString() + " saved!",
                         "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (saved == DialogResult.OK)
                        {
                            this._mF.btnNext.Enabled = true;
                            GetScheduleInfo(this.lboxDatabases.SelectedItem.ToString());
                        }
                    }
                    else
                    {
                        this.lblSchedStatus.Text = "An error occured!\r\nCheck the Windows Application Event logs for details on the error.";
                        this.lblSchedStatus.Visible = true;
                    }
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.cBBackupAll.Checked)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the schedule(s) for ALL databases?",
                     "Second Chance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        this._mF.SchedOp.ts = new TaskService();
                        this._mF.SchedOp.ts.RootFolder.DeleteTask("ALL");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    GetScheduleInfo("ALL"); //refreshes listbox containing schedules.
                    this.btnDelete.Enabled = false;
                }
            }
            else
            {

                DialogResult dr = MessageBox.Show("Are you sure you want to delete the schedule(s) for "
                    + this.lboxDatabases.SelectedItem.ToString() + "?", "Second Chance", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        this._mF.SchedOp.ts = new TaskService();
                        this._mF.SchedOp.ts.RootFolder.DeleteTask(this.lboxDatabases.SelectedItem.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    GetScheduleInfo(this.lboxDatabases.SelectedItem.ToString()); //refreshes listbox containing schedules.
                    this.btnDelete.Enabled = false;
                }
            }
        }
        private void rBEveryDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rBEveryDay.Checked)
            {
                txtDaily.Text = "1";
                txtDaily.Enabled = true;
                this.cBDaily.Checked = true;
                this.cBWeekly.Checked = false;
            }
            else
            {
                txtDaily.Text = string.Empty;
                txtDaily.Enabled = false;
                this.cBDaily.Checked = false;
            }
        }
        internal void GetScheduleInfo(string DB_Item)
        {
            if (this.lBoxSchedTimes.Items.Count != 0)
            {
                this.lBoxSchedTimes.Items.Clear();
            }


            this._mF.LoadScheduleClass();

            this._mF.SchedOp.ts = new TaskService();

            List<string> list = new List<string>();


            for (int i = 0; i < this._mF.SchedOp.ts.RootFolder.Tasks.Count; i++)
            {
                if (this._mF.SchedOp.ts.RootFolder.Tasks[i].Name == DB_Item)
                {
                    try
                    {
                        for (int j = 0; j < this._mF.SchedOp.ts.RootFolder.Tasks[i].Definition.Triggers.Count; j++)
                        {
                            list.Add(this._mF.SchedOp.ts.RootFolder.Tasks[i].Definition.Triggers[j].ToString());
                        }

                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (string s in list)
            {
                lBoxSchedTimes.Items.Add(s);
            }
        }
        private void cBBackupAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cBBackupAll.Checked)
            {
                this.ArgsToPass = "ALL";
                this.lblSchedSelectedDB.Text = "All databases will be backed up";
                this.lboxDatabases.SelectedItem = null;

                GetScheduleInfo("ALL");

                if (this.lBoxSchedTimes.Items.Count != 0)
                {
                    this.btnDelete.Enabled = true;
                }
                else
                {
                    this.btnDelete.Enabled = false;
                }
            }
            else
            {
                this.lboxDatabases.SelectedIndex = 0;
                this.lblSchedSelectedDB.Text = "Schedule for " + this.lboxDatabases.SelectedItem.ToString(); //edits a label in the schedule tab.
            }
        }
        #region DayOfTheWeekSelection
        private void rBMonday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Monday;
        }

        private void rBTuesday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Tuesday;
        }

        private void rBWednesday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Wednesday;
        }

        private void rBThursday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Thursday;
        }

        private void rbFriday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Friday;
        }

        private void rBSaturday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Saturday;
        }

        private void rBSunday_CheckedChanged(object sender, EventArgs e)
        {
            dayofweek = DaysOfTheWeek.Sunday;
        }
        #endregion  
        #endregion

        #region Restore        
        private void btnRestoreLocationBrowse_Click(object sender, EventArgs e)
        {
            this.RestoreLocationDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            this.RestoreLocationDialog.ShowNewFolderButton = true;
            this.RestoreLocationDialog.Description = "Select a folder to restore to...";

            if (this.RestoreLocationDialog.ShowDialog() == DialogResult.OK) //if ok is clicked..
            {
                this.txtRestoreLocation.Text = RestoreLocationDialog.SelectedPath + "\\"; //set Restore location as selected path

                this._mF.btnNext.Enabled = true;    //set text and enable button.
                this._mF.btnNext.Text = "Restore";
            }
            else
            {                   //Don't enable button.
                this._mF.btnNext.Enabled = false;
            }
        }
        #endregion

        #region Databases
        private void btnDBSave_Click(object sender, EventArgs e)
        {
            if (this.txtDbaseDBName.Text != "" && this.txtDbaseServer.Text != "" && this.txtDbaseLocation.Text != "" && this.txtDbaseID.Text != "")
            {               
                bool isAmended = false;

                XmlSerializer serializer = new XmlSerializer(typeof(Backups));

                XmlSerializer xs = new XmlSerializer(typeof(Backups)); //get array of databases from XML
                TextReader reader = new StreamReader(_mF.xmlPath);
                Backups bb = (Backups)xs.Deserialize(reader);
                reader.Close();

                string backupString = txtDbaseLocation.Text.Substring(txtDbaseLocation.Text.Length - 1, 1);
                if (backupString != "\\")
                {
                    backupString = txtDbaseLocation.Text + "\\";
                }
                else
                {
                    backupString = txtDbaseLocation.Text;
                }

                if (bb.Databases != null)
                {
                    List<BackupsDatabases> bdList = bb.Databases.ToList(); //convert the array to a list


                    for (int i = 0; i < bdList.Count; i++) //iterate through list
                    {
                        if (bdList[i].ID == Convert.ToByte(this.txtDbaseID.Text)) //if ID in list matches ID in textbox
                        {
                            bdList[i].DBName = this.txtDbaseDBName.Text;
                            bdList[i].BackupLocation = backupString; //append data.
                            bdList[i].ServerName = this.txtDbaseServer.Text;
                            isAmended = true;
                            break; //break loop
                        }
                    }


                    if (!isAmended) //if data was not amended..
                    {
                        BackupsDatabases bd = new BackupsDatabases();  //gets textbox info.
                        bd.DBName = this.txtDbaseDBName.Text;
                        bd.BackupLocation = backupString;
                        bd.ServerName = this.txtDbaseServer.Text;
                        bd.ID = Convert.ToByte(this.txtDbaseID.Text);

                        bdList.Add(bd); //adds bd to list
                    }


                    bb.Databases = bdList.ToArray(); //converts list back to array.
                }
                else
                {
                    List<BackupsDatabases> bdList = new List<BackupsDatabases>();

                    BackupsDatabases bd = new BackupsDatabases();  //gets textbox info.
                    bd.DBName = this.txtDbaseDBName.Text;                    
                    //bd.BackupLocation = this.txtDbaseLocation.Text;
                    bd.BackupLocation = backupString;
                    bd.ServerName = this.txtDbaseServer.Text;
                    bd.ID = Convert.ToByte(this.txtDbaseID.Text);

                    bdList.Add(bd); //adds bd to list
                    bb.Databases = bdList.ToArray();
                }


                TextWriter writer = new StreamWriter(_mF.xmlPath);
                serializer.Serialize(writer, bb);     //writes data back to XML
                writer.Close();

                this.lboxDatabases.Items.Clear(); //clears items from listbox
                this._mF.getBackupInfo(); //refreshes listbox

            }
            else
            {
                MessageBox.Show("All fields must be filled out before you can save!", "Second Chance", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnDBDelete_Click(object sender, EventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Backups));

            XmlSerializer xs = new XmlSerializer(typeof(Backups)); //get array of databases from XML
            TextReader reader = new StreamReader(_mF.xmlPath);
            Backups bb = (Backups)xs.Deserialize(reader);
            reader.Close();


            List<BackupsDatabases> bdList = bb.Databases.ToList(); //convert the array to a list


            for (int i = 0; i < bdList.Count; i++) //iterate through list
            {
                if (bdList[i].ID == Convert.ToByte(this.txtDbaseID.Text)) //if ID in list matches ID in textbox
                {
                    bdList.Remove(bb.Databases[i]);
                }
            }

            bb.Databases = bdList.ToArray(); //converts list back to array.


            TextWriter writer = new StreamWriter(_mF.xmlPath);
            serializer.Serialize(writer, bb);     //writes data back to XML
            writer.Close();

            this.lboxDatabases.Items.Clear(); //clears items from listbox
            this._mF.getBackupInfo(); //refreshes listbox

            this.txtDbaseID.Text = string.Empty;
            this.txtDbaseDBName.Text = string.Empty;    //clears textboxes
            this.txtDbaseServer.Text = string.Empty;
            this.txtDbaseLocation.Text = string.Empty;

        }
        private void btnDBNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(_mF.xmlPath))
                {
                    this._mF.CreateXML();
                }
                this.btnDBDelete.Enabled = false; //disable buttons as a new db is being created.
                this.btnDBSave.Enabled = false;
                this.txtDbaseID.Enabled = true;
                this.lboxDatabases.SelectedItem = null;


                XmlSerializer xs = new XmlSerializer(typeof(Backups)); //get array of databases from XML
                TextReader reader = new StreamReader(_mF.xmlPath);
                Backups bb = (Backups)xs.Deserialize(reader);
                reader.Close();

                int newDbID = 0; //= Convert.ToByte(bb.Databases.Length + 1);

                if (bb.Databases != null)
                {
                    List<BackupsDatabases> bdList = bb.Databases.ToList(); //convert the array to a list


                    for (int i = 0; i < bdList.Count; i++) //iterate through list
                    {

                        newDbID = bdList[i].ID + 1;

                    }
                }
                else
                {
                    newDbID = 1;
                }

                this.txtDbaseID.Text = newDbID.ToString();
                this.txtDbaseDBName.Text = string.Empty;
                this.txtDbaseServer.Text = string.Empty;
                this.txtDbaseLocation.Text = string.Empty;

            }
            catch
            {

            }            
        }
        private void txtDbaseDBName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtDbaseDBName.Text.Length > 0)
            {
                this.btnDBDelete.Enabled = true;
                this.btnDBSave.Enabled = true;
            }
            else
            {
                this.btnDBDelete.Enabled = false;
                this.btnDBSave.Enabled = false;
            }
        }
        private void btnDBBrowse_Click(object sender, EventArgs e)
        {
            this.DatabaseBrowserLocationDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            this.DatabaseBrowserLocationDialog.ShowNewFolderButton = true;
            this.DatabaseBrowserLocationDialog.Description = "Select a folder to save the backup to...";

            if (this.DatabaseBrowserLocationDialog.ShowDialog() == DialogResult.OK) //if ok is clicked..
            {
                this.txtDbaseLocation.Text = DatabaseBrowserLocationDialog.SelectedPath + "\\"; //set database backuplocation as selected path

            }

        }
        #endregion

        private void btnErrorpnl_Click(object sender, EventArgs e) //displays error panel.
        {
            if (errTm == null)
            {
                errTm = new Timer();
                errTm.Interval = 100;
                errTm.Tick += new EventHandler(errTm_Tick);
            }

            errTm.Enabled = true;

        }
        private void errTm_Tick(object sender, EventArgs e)
        {

            if (this.pnlError.Height == 260)
            {
                this.btnErrorpnl.Text = "Show Details..";
                this.pnlError.Height = 0;
                errTm.Enabled = false;
            }

            else if (this.pnlError.Height == 0)
            {
                this.btnErrorpnl.Text = "Hide Details..";
                this.pnlError.Height = 260;
                errTm.Enabled = false;
            }
        }       

       
      
    }
}
