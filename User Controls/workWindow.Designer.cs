namespace SecondChance
{
    partial class workWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCont = new System.Windows.Forms.TabControl();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.gBoxBupSelection = new System.Windows.Forms.GroupBox();
            this.chkBoxCompress = new System.Windows.Forms.CheckBox();
            this.chkBoxFTP = new System.Windows.Forms.CheckBox();
            this.btnSaveBrowse = new System.Windows.Forms.Button();
            this.txtBackupLocation = new System.Windows.Forms.TextBox();
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblBackupLocation = new System.Windows.Forms.Label();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblDbname = new System.Windows.Forms.Label();
            this.gBoxBackingUp = new System.Windows.Forms.GroupBox();
            this.pBarBackup = new System.Windows.Forms.ProgressBar();
            this.pBarComp = new System.Windows.Forms.ProgressBar();
            this.btnErrorpnl = new System.Windows.Forms.Button();
            this.pnlError = new System.Windows.Forms.Panel();
            this.txtlblError = new System.Windows.Forms.TextBox();
            this.lblBackupStatus = new System.Windows.Forms.Label();
            this.tabRestore = new System.Windows.Forms.TabPage();
            this.gBoxRestoreSelect = new System.Windows.Forms.GroupBox();
            this.lblRestoreLocation = new System.Windows.Forms.Label();
            this.txtRestoreLocation = new System.Windows.Forms.TextBox();
            this.btnRestoreLocationBrowse = new System.Windows.Forms.Button();
            this.lblRestoreStatus = new System.Windows.Forms.Label();
            this.pBarRestore = new System.Windows.Forms.ProgressBar();
            this.lblDBRestoreName = new System.Windows.Forms.Label();
            this.lblRestoreServer = new System.Windows.Forms.Label();
            this.lblRestoreFile = new System.Windows.Forms.Label();
            this.txtRestDbName = new System.Windows.Forms.TextBox();
            this.txtRestServerName = new System.Windows.Forms.TextBox();
            this.txtRestFileLocation = new System.Windows.Forms.TextBox();
            this.btnRestoreBrowse = new System.Windows.Forms.Button();
            this.tabFTP = new System.Windows.Forms.TabPage();
            this.gBoxFTP = new System.Windows.Forms.GroupBox();
            this.lblFTPFileLocation = new System.Windows.Forms.Label();
            this.lblFTPError = new System.Windows.Forms.Label();
            this.btnFTPCancel = new System.Windows.Forms.Button();
            this.txtFTPPass = new System.Windows.Forms.TextBox();
            this.txtFTPUser = new System.Windows.Forms.TextBox();
            this.txtFTPServer = new System.Windows.Forms.TextBox();
            this.btnFTPSave = new System.Windows.Forms.Button();
            this.lblFTPAddress = new System.Windows.Forms.Label();
            this.lblFTPUserName = new System.Windows.Forms.Label();
            this.lblFTPPassword = new System.Windows.Forms.Label();
            this.pbarFTP = new System.Windows.Forms.ProgressBar();
            this.lblFTPPercent = new System.Windows.Forms.Label();
            this.txtFTPFileBrowse = new System.Windows.Forms.TextBox();
            this.btnFTPBrowse = new System.Windows.Forms.Button();
            this.tabSchedule = new System.Windows.Forms.TabPage();
            this.gBoxSchedule = new System.Windows.Forms.GroupBox();
            this.cBBackupAll = new System.Windows.Forms.CheckBox();
            this.lBoxSchedTimes = new System.Windows.Forms.ListBox();
            this.lblSchedType = new System.Windows.Forms.Label();
            this.lblSchedStatus = new System.Windows.Forms.Label();
            this.lblSchedSelectedDB = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblDays1 = new System.Windows.Forms.Label();
            this.lblDays2 = new System.Windows.Forms.Label();
            this.txtDaily = new System.Windows.Forms.TextBox();
            this.cBWeekly = new System.Windows.Forms.CheckBox();
            this.cBDaily = new System.Windows.Forms.CheckBox();
            this.rBEveryDay = new System.Windows.Forms.RadioButton();
            this.rBSunday = new System.Windows.Forms.RadioButton();
            this.rBSaturday = new System.Windows.Forms.RadioButton();
            this.rbFriday = new System.Windows.Forms.RadioButton();
            this.rBThursday = new System.Windows.Forms.RadioButton();
            this.rBWednesday = new System.Windows.Forms.RadioButton();
            this.rBTuesday = new System.Windows.Forms.RadioButton();
            this.rBMonday = new System.Windows.Forms.RadioButton();
            this.timePickSched = new System.Windows.Forms.DateTimePicker();
            this.lblDateSched = new System.Windows.Forms.Label();
            this.lblTimeSched = new System.Windows.Forms.Label();
            this.datePickSched = new System.Windows.Forms.DateTimePicker();
            this.Databases = new System.Windows.Forms.TabPage();
            this.gBoxDatabases = new System.Windows.Forms.GroupBox();
            this.btnDBBrowse = new System.Windows.Forms.Button();
            this.btnDBNew = new System.Windows.Forms.Button();
            this.btnDBDelete = new System.Windows.Forms.Button();
            this.lblDbaseLocation = new System.Windows.Forms.Label();
            this.lblDbaseServer = new System.Windows.Forms.Label();
            this.lblDbaseDBName = new System.Windows.Forms.Label();
            this.lblDbaseID = new System.Windows.Forms.Label();
            this.txtDbaseLocation = new System.Windows.Forms.TextBox();
            this.txtDbaseServer = new System.Windows.Forms.TextBox();
            this.txtDbaseDBName = new System.Windows.Forms.TextBox();
            this.txtDbaseID = new System.Windows.Forms.TextBox();
            this.btnDBSave = new System.Windows.Forms.Button();
            this.lboxDatabases = new System.Windows.Forms.ListBox();
            this.backupLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.RestoreBrowserDialog = new System.Windows.Forms.OpenFileDialog();
            this.FTPSelectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RestoreLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.DatabaseBrowserLocationDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tabCont.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.gBoxBupSelection.SuspendLayout();
            this.gBoxBackingUp.SuspendLayout();
            this.pnlError.SuspendLayout();
            this.tabRestore.SuspendLayout();
            this.gBoxRestoreSelect.SuspendLayout();
            this.tabFTP.SuspendLayout();
            this.gBoxFTP.SuspendLayout();
            this.tabSchedule.SuspendLayout();
            this.gBoxSchedule.SuspendLayout();
            this.Databases.SuspendLayout();
            this.gBoxDatabases.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCont
            // 
            this.tabCont.Controls.Add(this.tabBackup);
            this.tabCont.Controls.Add(this.tabRestore);
            this.tabCont.Controls.Add(this.tabFTP);
            this.tabCont.Controls.Add(this.tabSchedule);
            this.tabCont.Controls.Add(this.Databases);
            this.tabCont.Location = new System.Drawing.Point(180, 57);
            this.tabCont.Name = "tabCont";
            this.tabCont.SelectedIndex = 0;
            this.tabCont.Size = new System.Drawing.Size(536, 377);
            this.tabCont.TabIndex = 0;
            this.tabCont.SelectedIndexChanged += new System.EventHandler(this.tabClick);
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.gBoxBupSelection);
            this.tabBackup.Controls.Add(this.gBoxBackingUp);
            this.tabBackup.Location = new System.Drawing.Point(4, 22);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(3);
            this.tabBackup.Size = new System.Drawing.Size(528, 351);
            this.tabBackup.TabIndex = 0;
            this.tabBackup.Text = "Backup";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // gBoxBupSelection
            // 
            this.gBoxBupSelection.Controls.Add(this.chkBoxCompress);
            this.gBoxBupSelection.Controls.Add(this.chkBoxFTP);
            this.gBoxBupSelection.Controls.Add(this.btnSaveBrowse);
            this.gBoxBupSelection.Controls.Add(this.txtBackupLocation);
            this.gBoxBupSelection.Controls.Add(this.txtServerName);
            this.gBoxBupSelection.Controls.Add(this.lblBackupLocation);
            this.gBoxBupSelection.Controls.Add(this.txtDbName);
            this.gBoxBupSelection.Controls.Add(this.lblServerName);
            this.gBoxBupSelection.Controls.Add(this.lblDbname);
            this.gBoxBupSelection.Location = new System.Drawing.Point(6, 9);
            this.gBoxBupSelection.Name = "gBoxBupSelection";
            this.gBoxBupSelection.Size = new System.Drawing.Size(509, 339);
            this.gBoxBupSelection.TabIndex = 10;
            this.gBoxBupSelection.TabStop = false;
            // 
            // chkBoxCompress
            // 
            this.chkBoxCompress.AutoSize = true;
            this.chkBoxCompress.Location = new System.Drawing.Point(313, 98);
            this.chkBoxCompress.Name = "chkBoxCompress";
            this.chkBoxCompress.Size = new System.Drawing.Size(140, 17);
            this.chkBoxCompress.TabIndex = 10;
            this.chkBoxCompress.Text = "Compress this Database";
            this.chkBoxCompress.UseVisualStyleBackColor = true;
            this.chkBoxCompress.Visible = false;
            // 
            // chkBoxFTP
            // 
            this.chkBoxFTP.AutoSize = true;
            this.chkBoxFTP.Location = new System.Drawing.Point(313, 33);
            this.chkBoxFTP.Name = "chkBoxFTP";
            this.chkBoxFTP.Size = new System.Drawing.Size(114, 17);
            this.chkBoxFTP.TabIndex = 9;
            this.chkBoxFTP.Tag = "";
            this.chkBoxFTP.Text = "FTP this Database";
            this.chkBoxFTP.UseVisualStyleBackColor = true;
            this.chkBoxFTP.Visible = false;
            this.chkBoxFTP.CheckedChanged += new System.EventHandler(this.chkBoxFTP_CheckedChanged);
            // 
            // btnSaveBrowse
            // 
            this.btnSaveBrowse.Location = new System.Drawing.Point(233, 186);
            this.btnSaveBrowse.Name = "btnSaveBrowse";
            this.btnSaveBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnSaveBrowse.TabIndex = 7;
            this.btnSaveBrowse.Text = "Browse...";
            this.btnSaveBrowse.UseVisualStyleBackColor = true;
            this.btnSaveBrowse.Click += new System.EventHandler(this.btnSaveBrowse_Click);
            // 
            // txtBackupLocation
            // 
            this.txtBackupLocation.Location = new System.Drawing.Point(6, 186);
            this.txtBackupLocation.Name = "txtBackupLocation";
            this.txtBackupLocation.Size = new System.Drawing.Size(221, 20);
            this.txtBackupLocation.TabIndex = 6;
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(6, 98);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(221, 20);
            this.txtServerName.TabIndex = 5;
            // 
            // lblBackupLocation
            // 
            this.lblBackupLocation.AutoSize = true;
            this.lblBackupLocation.Location = new System.Drawing.Point(3, 170);
            this.lblBackupLocation.Name = "lblBackupLocation";
            this.lblBackupLocation.Size = new System.Drawing.Size(124, 13);
            this.lblBackupLocation.TabIndex = 3;
            this.lblBackupLocation.Text = "Select Backup Location:";
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(6, 33);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(221, 20);
            this.txtDbName.TabIndex = 4;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(3, 82);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 2;
            this.lblServerName.Text = "Server Name:";
            // 
            // lblDbname
            // 
            this.lblDbname.AutoSize = true;
            this.lblDbname.Location = new System.Drawing.Point(3, 16);
            this.lblDbname.Name = "lblDbname";
            this.lblDbname.Size = new System.Drawing.Size(87, 13);
            this.lblDbname.TabIndex = 1;
            this.lblDbname.Text = "Database Name:";
            // 
            // gBoxBackingUp
            // 
            this.gBoxBackingUp.Controls.Add(this.pBarBackup);
            this.gBoxBackingUp.Controls.Add(this.pBarComp);
            this.gBoxBackingUp.Controls.Add(this.btnErrorpnl);
            this.gBoxBackingUp.Controls.Add(this.pnlError);
            this.gBoxBackingUp.Controls.Add(this.lblBackupStatus);
            this.gBoxBackingUp.Location = new System.Drawing.Point(6, 9);
            this.gBoxBackingUp.Name = "gBoxBackingUp";
            this.gBoxBackingUp.Size = new System.Drawing.Size(509, 339);
            this.gBoxBackingUp.TabIndex = 9;
            this.gBoxBackingUp.TabStop = false;
            // 
            // pBarBackup
            // 
            this.pBarBackup.Location = new System.Drawing.Point(90, 96);
            this.pBarBackup.Name = "pBarBackup";
            this.pBarBackup.Size = new System.Drawing.Size(337, 23);
            this.pBarBackup.TabIndex = 14;
            this.pBarBackup.Visible = false;
            // 
            // pBarComp
            // 
            this.pBarComp.Location = new System.Drawing.Point(90, 95);
            this.pBarComp.Name = "pBarComp";
            this.pBarComp.Size = new System.Drawing.Size(337, 23);
            this.pBarComp.TabIndex = 13;
            this.pBarComp.Visible = false;
            // 
            // btnErrorpnl
            // 
            this.btnErrorpnl.AutoSize = true;
            this.btnErrorpnl.Location = new System.Drawing.Point(217, 39);
            this.btnErrorpnl.Name = "btnErrorpnl";
            this.btnErrorpnl.Size = new System.Drawing.Size(85, 23);
            this.btnErrorpnl.TabIndex = 12;
            this.btnErrorpnl.Text = "Show Details..";
            this.btnErrorpnl.UseVisualStyleBackColor = true;
            this.btnErrorpnl.Visible = false;
            this.btnErrorpnl.Click += new System.EventHandler(this.btnErrorpnl_Click);
            // 
            // pnlError
            // 
            this.pnlError.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pnlError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlError.Controls.Add(this.txtlblError);
            this.pnlError.Location = new System.Drawing.Point(6, 76);
            this.pnlError.Name = "pnlError";
            this.pnlError.Size = new System.Drawing.Size(497, 0);
            this.pnlError.TabIndex = 11;
            // 
            // txtlblError
            // 
            this.txtlblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtlblError.Location = new System.Drawing.Point(0, 0);
            this.txtlblError.Multiline = true;
            this.txtlblError.Name = "txtlblError";
            this.txtlblError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlblError.Size = new System.Drawing.Size(495, 0);
            this.txtlblError.TabIndex = 11;
            // 
            // lblBackupStatus
            // 
            this.lblBackupStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBackupStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupStatus.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblBackupStatus.Location = new System.Drawing.Point(3, 16);
            this.lblBackupStatus.Name = "lblBackupStatus";
            this.lblBackupStatus.Size = new System.Drawing.Size(503, 20);
            this.lblBackupStatus.TabIndex = 9;
            this.lblBackupStatus.Text = "Please Wait...";
            this.lblBackupStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabRestore
            // 
            this.tabRestore.Controls.Add(this.gBoxRestoreSelect);
            this.tabRestore.Location = new System.Drawing.Point(4, 22);
            this.tabRestore.Name = "tabRestore";
            this.tabRestore.Padding = new System.Windows.Forms.Padding(3);
            this.tabRestore.Size = new System.Drawing.Size(528, 351);
            this.tabRestore.TabIndex = 1;
            this.tabRestore.Text = "Restore";
            this.tabRestore.UseVisualStyleBackColor = true;
            // 
            // gBoxRestoreSelect
            // 
            this.gBoxRestoreSelect.Controls.Add(this.lblRestoreLocation);
            this.gBoxRestoreSelect.Controls.Add(this.txtRestoreLocation);
            this.gBoxRestoreSelect.Controls.Add(this.btnRestoreLocationBrowse);
            this.gBoxRestoreSelect.Controls.Add(this.lblRestoreStatus);
            this.gBoxRestoreSelect.Controls.Add(this.pBarRestore);
            this.gBoxRestoreSelect.Controls.Add(this.lblDBRestoreName);
            this.gBoxRestoreSelect.Controls.Add(this.lblRestoreServer);
            this.gBoxRestoreSelect.Controls.Add(this.lblRestoreFile);
            this.gBoxRestoreSelect.Controls.Add(this.txtRestDbName);
            this.gBoxRestoreSelect.Controls.Add(this.txtRestServerName);
            this.gBoxRestoreSelect.Controls.Add(this.txtRestFileLocation);
            this.gBoxRestoreSelect.Controls.Add(this.btnRestoreBrowse);
            this.gBoxRestoreSelect.Location = new System.Drawing.Point(6, 9);
            this.gBoxRestoreSelect.Name = "gBoxRestoreSelect";
            this.gBoxRestoreSelect.Size = new System.Drawing.Size(509, 339);
            this.gBoxRestoreSelect.TabIndex = 9;
            this.gBoxRestoreSelect.TabStop = false;
            // 
            // lblRestoreLocation
            // 
            this.lblRestoreLocation.AutoSize = true;
            this.lblRestoreLocation.Location = new System.Drawing.Point(3, 131);
            this.lblRestoreLocation.Name = "lblRestoreLocation";
            this.lblRestoreLocation.Size = new System.Drawing.Size(124, 13);
            this.lblRestoreLocation.TabIndex = 11;
            this.lblRestoreLocation.Text = "Select Restore Location:";
            // 
            // txtRestoreLocation
            // 
            this.txtRestoreLocation.Location = new System.Drawing.Point(6, 147);
            this.txtRestoreLocation.Name = "txtRestoreLocation";
            this.txtRestoreLocation.Size = new System.Drawing.Size(221, 20);
            this.txtRestoreLocation.TabIndex = 7;
            // 
            // btnRestoreLocationBrowse
            // 
            this.btnRestoreLocationBrowse.Location = new System.Drawing.Point(233, 145);
            this.btnRestoreLocationBrowse.Name = "btnRestoreLocationBrowse";
            this.btnRestoreLocationBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreLocationBrowse.TabIndex = 13;
            this.btnRestoreLocationBrowse.Text = "Browse...";
            this.btnRestoreLocationBrowse.UseVisualStyleBackColor = true;
            this.btnRestoreLocationBrowse.Click += new System.EventHandler(this.btnRestoreLocationBrowse_Click);
            // 
            // lblRestoreStatus
            // 
            this.lblRestoreStatus.AutoSize = true;
            this.lblRestoreStatus.Location = new System.Drawing.Point(116, 280);
            this.lblRestoreStatus.Name = "lblRestoreStatus";
            this.lblRestoreStatus.Size = new System.Drawing.Size(35, 13);
            this.lblRestoreStatus.TabIndex = 10;
            this.lblRestoreStatus.Text = "status";
            this.lblRestoreStatus.Visible = false;
            // 
            // pBarRestore
            // 
            this.pBarRestore.Location = new System.Drawing.Point(9, 296);
            this.pBarRestore.Name = "pBarRestore";
            this.pBarRestore.Size = new System.Drawing.Size(300, 15);
            this.pBarRestore.TabIndex = 9;
            this.pBarRestore.Visible = false;
            // 
            // lblDBRestoreName
            // 
            this.lblDBRestoreName.AutoSize = true;
            this.lblDBRestoreName.Location = new System.Drawing.Point(3, 16);
            this.lblDBRestoreName.Name = "lblDBRestoreName";
            this.lblDBRestoreName.Size = new System.Drawing.Size(87, 13);
            this.lblDBRestoreName.TabIndex = 0;
            this.lblDBRestoreName.Text = "Database Name:";
            // 
            // lblRestoreServer
            // 
            this.lblRestoreServer.AutoSize = true;
            this.lblRestoreServer.Location = new System.Drawing.Point(3, 82);
            this.lblRestoreServer.Name = "lblRestoreServer";
            this.lblRestoreServer.Size = new System.Drawing.Size(72, 13);
            this.lblRestoreServer.TabIndex = 1;
            this.lblRestoreServer.Text = "Server Name:";
            // 
            // lblRestoreFile
            // 
            this.lblRestoreFile.AutoSize = true;
            this.lblRestoreFile.Location = new System.Drawing.Point(3, 181);
            this.lblRestoreFile.Name = "lblRestoreFile";
            this.lblRestoreFile.Size = new System.Drawing.Size(160, 13);
            this.lblRestoreFile.TabIndex = 2;
            this.lblRestoreFile.Text = "Select Database File to Restore:";
            // 
            // txtRestDbName
            // 
            this.txtRestDbName.Location = new System.Drawing.Point(6, 33);
            this.txtRestDbName.Name = "txtRestDbName";
            this.txtRestDbName.Size = new System.Drawing.Size(221, 20);
            this.txtRestDbName.TabIndex = 5;
            // 
            // txtRestServerName
            // 
            this.txtRestServerName.Location = new System.Drawing.Point(6, 98);
            this.txtRestServerName.Name = "txtRestServerName";
            this.txtRestServerName.Size = new System.Drawing.Size(221, 20);
            this.txtRestServerName.TabIndex = 6;
            // 
            // txtRestFileLocation
            // 
            this.txtRestFileLocation.Location = new System.Drawing.Point(6, 197);
            this.txtRestFileLocation.Name = "txtRestFileLocation";
            this.txtRestFileLocation.Size = new System.Drawing.Size(221, 20);
            this.txtRestFileLocation.TabIndex = 8;
            // 
            // btnRestoreBrowse
            // 
            this.btnRestoreBrowse.Location = new System.Drawing.Point(233, 195);
            this.btnRestoreBrowse.Name = "btnRestoreBrowse";
            this.btnRestoreBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnRestoreBrowse.TabIndex = 14;
            this.btnRestoreBrowse.Text = "Select...";
            this.btnRestoreBrowse.UseVisualStyleBackColor = true;
            this.btnRestoreBrowse.Click += new System.EventHandler(this.btnRestoreBrowse_Click);
            // 
            // tabFTP
            // 
            this.tabFTP.Controls.Add(this.gBoxFTP);
            this.tabFTP.Location = new System.Drawing.Point(4, 22);
            this.tabFTP.Name = "tabFTP";
            this.tabFTP.Padding = new System.Windows.Forms.Padding(3);
            this.tabFTP.Size = new System.Drawing.Size(528, 351);
            this.tabFTP.TabIndex = 2;
            this.tabFTP.Text = "FTP";
            this.tabFTP.UseVisualStyleBackColor = true;
            // 
            // gBoxFTP
            // 
            this.gBoxFTP.Controls.Add(this.lblFTPFileLocation);
            this.gBoxFTP.Controls.Add(this.lblFTPError);
            this.gBoxFTP.Controls.Add(this.btnFTPCancel);
            this.gBoxFTP.Controls.Add(this.txtFTPPass);
            this.gBoxFTP.Controls.Add(this.txtFTPUser);
            this.gBoxFTP.Controls.Add(this.txtFTPServer);
            this.gBoxFTP.Controls.Add(this.btnFTPSave);
            this.gBoxFTP.Controls.Add(this.lblFTPAddress);
            this.gBoxFTP.Controls.Add(this.lblFTPUserName);
            this.gBoxFTP.Controls.Add(this.lblFTPPassword);
            this.gBoxFTP.Controls.Add(this.pbarFTP);
            this.gBoxFTP.Controls.Add(this.lblFTPPercent);
            this.gBoxFTP.Controls.Add(this.txtFTPFileBrowse);
            this.gBoxFTP.Controls.Add(this.btnFTPBrowse);
            this.gBoxFTP.Location = new System.Drawing.Point(6, 9);
            this.gBoxFTP.Name = "gBoxFTP";
            this.gBoxFTP.Size = new System.Drawing.Size(509, 339);
            this.gBoxFTP.TabIndex = 12;
            this.gBoxFTP.TabStop = false;
            // 
            // lblFTPFileLocation
            // 
            this.lblFTPFileLocation.AutoSize = true;
            this.lblFTPFileLocation.Location = new System.Drawing.Point(3, 181);
            this.lblFTPFileLocation.Name = "lblFTPFileLocation";
            this.lblFTPFileLocation.Size = new System.Drawing.Size(94, 13);
            this.lblFTPFileLocation.TabIndex = 14;
            this.lblFTPFileLocation.Text = "Select File to FTP:";
            // 
            // lblFTPError
            // 
            this.lblFTPError.AutoSize = true;
            this.lblFTPError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFTPError.ForeColor = System.Drawing.Color.Red;
            this.lblFTPError.Location = new System.Drawing.Point(6, 294);
            this.lblFTPError.Name = "lblFTPError";
            this.lblFTPError.Size = new System.Drawing.Size(40, 17);
            this.lblFTPError.TabIndex = 13;
            this.lblFTPError.Text = "Error";
            this.lblFTPError.Visible = false;
            // 
            // btnFTPCancel
            // 
            this.btnFTPCancel.AutoSize = true;
            this.btnFTPCancel.Location = new System.Drawing.Point(384, 293);
            this.btnFTPCancel.Name = "btnFTPCancel";
            this.btnFTPCancel.Size = new System.Drawing.Size(87, 23);
            this.btnFTPCancel.TabIndex = 12;
            this.btnFTPCancel.Text = "Cancel Upload";
            this.btnFTPCancel.UseVisualStyleBackColor = true;
            this.btnFTPCancel.Visible = false;
            this.btnFTPCancel.Click += new System.EventHandler(this.btnFTPCancel_Click);
            // 
            // txtFTPPass
            // 
            this.txtFTPPass.Location = new System.Drawing.Point(6, 147);
            this.txtFTPPass.Name = "txtFTPPass";
            this.txtFTPPass.PasswordChar = '*';
            this.txtFTPPass.Size = new System.Drawing.Size(221, 20);
            this.txtFTPPass.TabIndex = 4;
            // 
            // txtFTPUser
            // 
            this.txtFTPUser.Location = new System.Drawing.Point(6, 98);
            this.txtFTPUser.Name = "txtFTPUser";
            this.txtFTPUser.Size = new System.Drawing.Size(221, 20);
            this.txtFTPUser.TabIndex = 3;
            // 
            // txtFTPServer
            // 
            this.txtFTPServer.Location = new System.Drawing.Point(6, 33);
            this.txtFTPServer.Name = "txtFTPServer";
            this.txtFTPServer.Size = new System.Drawing.Size(322, 20);
            this.txtFTPServer.TabIndex = 2;
            // 
            // btnFTPSave
            // 
            this.btnFTPSave.Location = new System.Drawing.Point(6, 252);
            this.btnFTPSave.Name = "btnFTPSave";
            this.btnFTPSave.Size = new System.Drawing.Size(75, 23);
            this.btnFTPSave.TabIndex = 0;
            this.btnFTPSave.Text = "Save Details";
            this.btnFTPSave.UseVisualStyleBackColor = true;
            this.btnFTPSave.Click += new System.EventHandler(this.btnFTPSave_Click);
            // 
            // lblFTPAddress
            // 
            this.lblFTPAddress.AutoSize = true;
            this.lblFTPAddress.Location = new System.Drawing.Point(3, 16);
            this.lblFTPAddress.Name = "lblFTPAddress";
            this.lblFTPAddress.Size = new System.Drawing.Size(71, 13);
            this.lblFTPAddress.TabIndex = 5;
            this.lblFTPAddress.Text = "FTP Address:";
            // 
            // lblFTPUserName
            // 
            this.lblFTPUserName.AutoSize = true;
            this.lblFTPUserName.Location = new System.Drawing.Point(3, 82);
            this.lblFTPUserName.Name = "lblFTPUserName";
            this.lblFTPUserName.Size = new System.Drawing.Size(58, 13);
            this.lblFTPUserName.TabIndex = 6;
            this.lblFTPUserName.Text = "Username:";
            // 
            // lblFTPPassword
            // 
            this.lblFTPPassword.AutoSize = true;
            this.lblFTPPassword.Location = new System.Drawing.Point(3, 131);
            this.lblFTPPassword.Name = "lblFTPPassword";
            this.lblFTPPassword.Size = new System.Drawing.Size(56, 13);
            this.lblFTPPassword.TabIndex = 7;
            this.lblFTPPassword.Text = "Password:";
            // 
            // pbarFTP
            // 
            this.pbarFTP.Location = new System.Drawing.Point(9, 296);
            this.pbarFTP.Name = "pbarFTP";
            this.pbarFTP.Size = new System.Drawing.Size(319, 15);
            this.pbarFTP.TabIndex = 8;
            this.pbarFTP.Visible = false;
            // 
            // lblFTPPercent
            // 
            this.lblFTPPercent.AutoSize = true;
            this.lblFTPPercent.Location = new System.Drawing.Point(334, 298);
            this.lblFTPPercent.Name = "lblFTPPercent";
            this.lblFTPPercent.Size = new System.Drawing.Size(24, 13);
            this.lblFTPPercent.TabIndex = 9;
            this.lblFTPPercent.Text = "0 %";
            this.lblFTPPercent.Visible = false;
            // 
            // txtFTPFileBrowse
            // 
            this.txtFTPFileBrowse.Location = new System.Drawing.Point(6, 197);
            this.txtFTPFileBrowse.Name = "txtFTPFileBrowse";
            this.txtFTPFileBrowse.Size = new System.Drawing.Size(221, 20);
            this.txtFTPFileBrowse.TabIndex = 10;
            // 
            // btnFTPBrowse
            // 
            this.btnFTPBrowse.Location = new System.Drawing.Point(233, 197);
            this.btnFTPBrowse.Name = "btnFTPBrowse";
            this.btnFTPBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnFTPBrowse.TabIndex = 11;
            this.btnFTPBrowse.Text = "Browse..";
            this.btnFTPBrowse.UseVisualStyleBackColor = true;
            this.btnFTPBrowse.Click += new System.EventHandler(this.btnFTPBrowse_Click);
            // 
            // tabSchedule
            // 
            this.tabSchedule.Controls.Add(this.gBoxSchedule);
            this.tabSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabSchedule.Name = "tabSchedule";
            this.tabSchedule.Size = new System.Drawing.Size(528, 351);
            this.tabSchedule.TabIndex = 3;
            this.tabSchedule.Text = "Schedule";
            this.tabSchedule.UseVisualStyleBackColor = true;
            // 
            // gBoxSchedule
            // 
            this.gBoxSchedule.Controls.Add(this.cBBackupAll);
            this.gBoxSchedule.Controls.Add(this.lBoxSchedTimes);
            this.gBoxSchedule.Controls.Add(this.lblSchedType);
            this.gBoxSchedule.Controls.Add(this.lblSchedStatus);
            this.gBoxSchedule.Controls.Add(this.lblSchedSelectedDB);
            this.gBoxSchedule.Controls.Add(this.btnDelete);
            this.gBoxSchedule.Controls.Add(this.btnCreate);
            this.gBoxSchedule.Controls.Add(this.lblDays1);
            this.gBoxSchedule.Controls.Add(this.lblDays2);
            this.gBoxSchedule.Controls.Add(this.txtDaily);
            this.gBoxSchedule.Controls.Add(this.cBWeekly);
            this.gBoxSchedule.Controls.Add(this.cBDaily);
            this.gBoxSchedule.Controls.Add(this.rBEveryDay);
            this.gBoxSchedule.Controls.Add(this.rBSunday);
            this.gBoxSchedule.Controls.Add(this.rBSaturday);
            this.gBoxSchedule.Controls.Add(this.rbFriday);
            this.gBoxSchedule.Controls.Add(this.rBThursday);
            this.gBoxSchedule.Controls.Add(this.rBWednesday);
            this.gBoxSchedule.Controls.Add(this.rBTuesday);
            this.gBoxSchedule.Controls.Add(this.rBMonday);
            this.gBoxSchedule.Controls.Add(this.timePickSched);
            this.gBoxSchedule.Controls.Add(this.lblDateSched);
            this.gBoxSchedule.Controls.Add(this.lblTimeSched);
            this.gBoxSchedule.Controls.Add(this.datePickSched);
            this.gBoxSchedule.Location = new System.Drawing.Point(6, 9);
            this.gBoxSchedule.Name = "gBoxSchedule";
            this.gBoxSchedule.Size = new System.Drawing.Size(509, 339);
            this.gBoxSchedule.TabIndex = 21;
            this.gBoxSchedule.TabStop = false;
            // 
            // cBBackupAll
            // 
            this.cBBackupAll.AutoSize = true;
            this.cBBackupAll.Location = new System.Drawing.Point(352, 60);
            this.cBBackupAll.Name = "cBBackupAll";
            this.cBBackupAll.Size = new System.Drawing.Size(128, 17);
            this.cBBackupAll.TabIndex = 27;
            this.cBBackupAll.Text = "Backup all databases";
            this.cBBackupAll.UseVisualStyleBackColor = true;
            this.cBBackupAll.CheckedChanged += new System.EventHandler(this.cBBackupAll_CheckedChanged);
            // 
            // lBoxSchedTimes
            // 
            this.lBoxSchedTimes.FormattingEnabled = true;
            this.lBoxSchedTimes.HorizontalScrollbar = true;
            this.lBoxSchedTimes.Location = new System.Drawing.Point(250, 183);
            this.lBoxSchedTimes.Name = "lBoxSchedTimes";
            this.lBoxSchedTimes.Size = new System.Drawing.Size(230, 82);
            this.lBoxSchedTimes.TabIndex = 26;
            // 
            // lblSchedType
            // 
            this.lblSchedType.AutoSize = true;
            this.lblSchedType.Location = new System.Drawing.Point(15, 41);
            this.lblSchedType.Name = "lblSchedType";
            this.lblSchedType.Size = new System.Drawing.Size(82, 13);
            this.lblSchedType.TabIndex = 23;
            this.lblSchedType.Text = "Schedule Type:";
            // 
            // lblSchedStatus
            // 
            this.lblSchedStatus.AutoSize = true;
            this.lblSchedStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedStatus.ForeColor = System.Drawing.Color.Red;
            this.lblSchedStatus.Location = new System.Drawing.Point(12, 309);
            this.lblSchedStatus.Name = "lblSchedStatus";
            this.lblSchedStatus.Size = new System.Drawing.Size(41, 13);
            this.lblSchedStatus.TabIndex = 22;
            this.lblSchedStatus.Text = "status";
            this.lblSchedStatus.Visible = false;
            // 
            // lblSchedSelectedDB
            // 
            this.lblSchedSelectedDB.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSchedSelectedDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedSelectedDB.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSchedSelectedDB.Location = new System.Drawing.Point(3, 16);
            this.lblSchedSelectedDB.Name = "lblSchedSelectedDB";
            this.lblSchedSelectedDB.Size = new System.Drawing.Size(503, 15);
            this.lblSchedSelectedDB.TabIndex = 21;
            this.lblSchedSelectedDB.Text = "Create Schedule";
            this.lblSchedSelectedDB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblSchedSelectedDB.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(309, 299);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(250, 299);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(53, 23);
            this.btnCreate.TabIndex = 18;
            this.btnCreate.Text = "Save";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblDays1
            // 
            this.lblDays1.AutoSize = true;
            this.lblDays1.Location = new System.Drawing.Point(88, 64);
            this.lblDays1.Name = "lblDays1";
            this.lblDays1.Size = new System.Drawing.Size(34, 13);
            this.lblDays1.TabIndex = 20;
            this.lblDays1.Text = "Every";
            // 
            // lblDays2
            // 
            this.lblDays2.AutoSize = true;
            this.lblDays2.Location = new System.Drawing.Point(161, 64);
            this.lblDays2.Name = "lblDays2";
            this.lblDays2.Size = new System.Drawing.Size(40, 13);
            this.lblDays2.TabIndex = 17;
            this.lblDays2.Text = "Day(s).";
            // 
            // txtDaily
            // 
            this.txtDaily.Enabled = false;
            this.txtDaily.Location = new System.Drawing.Point(128, 60);
            this.txtDaily.Name = "txtDaily";
            this.txtDaily.Size = new System.Drawing.Size(27, 20);
            this.txtDaily.TabIndex = 16;
            // 
            // cBWeekly
            // 
            this.cBWeekly.AutoSize = true;
            this.cBWeekly.Location = new System.Drawing.Point(15, 86);
            this.cBWeekly.Name = "cBWeekly";
            this.cBWeekly.Size = new System.Drawing.Size(62, 17);
            this.cBWeekly.TabIndex = 15;
            this.cBWeekly.Text = "Weekly";
            this.cBWeekly.UseVisualStyleBackColor = true;
            // 
            // cBDaily
            // 
            this.cBDaily.AutoSize = true;
            this.cBDaily.Location = new System.Drawing.Point(15, 60);
            this.cBDaily.Name = "cBDaily";
            this.cBDaily.Size = new System.Drawing.Size(49, 17);
            this.cBDaily.TabIndex = 14;
            this.cBDaily.Text = "Daily";
            this.cBDaily.UseVisualStyleBackColor = true;
            this.cBDaily.CheckedChanged += new System.EventHandler(this.cBDaily_CheckedChanged);
            // 
            // rBEveryDay
            // 
            this.rBEveryDay.AutoSize = true;
            this.rBEveryDay.Location = new System.Drawing.Point(148, 252);
            this.rBEveryDay.Name = "rBEveryDay";
            this.rBEveryDay.Size = new System.Drawing.Size(69, 17);
            this.rBEveryDay.TabIndex = 13;
            this.rBEveryDay.TabStop = true;
            this.rBEveryDay.Text = "Everyday";
            this.rBEveryDay.UseVisualStyleBackColor = true;
            this.rBEveryDay.CheckedChanged += new System.EventHandler(this.rBEveryDay_CheckedChanged);
            // 
            // rBSunday
            // 
            this.rBSunday.AutoSize = true;
            this.rBSunday.Location = new System.Drawing.Point(148, 206);
            this.rBSunday.Name = "rBSunday";
            this.rBSunday.Size = new System.Drawing.Size(61, 17);
            this.rBSunday.TabIndex = 12;
            this.rBSunday.TabStop = true;
            this.rBSunday.Text = "Sunday";
            this.rBSunday.UseVisualStyleBackColor = true;
            this.rBSunday.CheckedChanged += new System.EventHandler(this.rBSunday_CheckedChanged);
            // 
            // rBSaturday
            // 
            this.rBSaturday.AutoSize = true;
            this.rBSaturday.Location = new System.Drawing.Point(148, 183);
            this.rBSaturday.Name = "rBSaturday";
            this.rBSaturday.Size = new System.Drawing.Size(67, 17);
            this.rBSaturday.TabIndex = 11;
            this.rBSaturday.TabStop = true;
            this.rBSaturday.Text = "Saturday";
            this.rBSaturday.UseVisualStyleBackColor = true;
            this.rBSaturday.CheckedChanged += new System.EventHandler(this.rBSaturday_CheckedChanged);
            // 
            // rbFriday
            // 
            this.rbFriday.AutoSize = true;
            this.rbFriday.Location = new System.Drawing.Point(15, 275);
            this.rbFriday.Name = "rbFriday";
            this.rbFriday.Size = new System.Drawing.Size(53, 17);
            this.rbFriday.TabIndex = 10;
            this.rbFriday.TabStop = true;
            this.rbFriday.Text = "Friday";
            this.rbFriday.UseVisualStyleBackColor = true;
            this.rbFriday.CheckedChanged += new System.EventHandler(this.rbFriday_CheckedChanged);
            // 
            // rBThursday
            // 
            this.rBThursday.AutoSize = true;
            this.rBThursday.Location = new System.Drawing.Point(15, 252);
            this.rBThursday.Name = "rBThursday";
            this.rBThursday.Size = new System.Drawing.Size(69, 17);
            this.rBThursday.TabIndex = 9;
            this.rBThursday.TabStop = true;
            this.rBThursday.Text = "Thursday";
            this.rBThursday.UseVisualStyleBackColor = true;
            this.rBThursday.CheckedChanged += new System.EventHandler(this.rBThursday_CheckedChanged);
            // 
            // rBWednesday
            // 
            this.rBWednesday.AutoSize = true;
            this.rBWednesday.Location = new System.Drawing.Point(15, 229);
            this.rBWednesday.Name = "rBWednesday";
            this.rBWednesday.Size = new System.Drawing.Size(82, 17);
            this.rBWednesday.TabIndex = 8;
            this.rBWednesday.TabStop = true;
            this.rBWednesday.Text = "Wednesday";
            this.rBWednesday.UseVisualStyleBackColor = true;
            this.rBWednesday.CheckedChanged += new System.EventHandler(this.rBWednesday_CheckedChanged);
            // 
            // rBTuesday
            // 
            this.rBTuesday.AutoSize = true;
            this.rBTuesday.Location = new System.Drawing.Point(15, 206);
            this.rBTuesday.Name = "rBTuesday";
            this.rBTuesday.Size = new System.Drawing.Size(66, 17);
            this.rBTuesday.TabIndex = 7;
            this.rBTuesday.TabStop = true;
            this.rBTuesday.Text = "Tuesday";
            this.rBTuesday.UseVisualStyleBackColor = true;
            this.rBTuesday.CheckedChanged += new System.EventHandler(this.rBTuesday_CheckedChanged);
            // 
            // rBMonday
            // 
            this.rBMonday.AutoSize = true;
            this.rBMonday.Location = new System.Drawing.Point(15, 183);
            this.rBMonday.Name = "rBMonday";
            this.rBMonday.Size = new System.Drawing.Size(63, 17);
            this.rBMonday.TabIndex = 6;
            this.rBMonday.TabStop = true;
            this.rBMonday.Text = "Monday";
            this.rBMonday.UseVisualStyleBackColor = true;
            this.rBMonday.CheckedChanged += new System.EventHandler(this.rBMonday_CheckedChanged);
            // 
            // timePickSched
            // 
            this.timePickSched.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickSched.Location = new System.Drawing.Point(250, 138);
            this.timePickSched.Name = "timePickSched";
            this.timePickSched.ShowUpDown = true;
            this.timePickSched.Size = new System.Drawing.Size(112, 20);
            this.timePickSched.TabIndex = 5;
            // 
            // lblDateSched
            // 
            this.lblDateSched.AutoSize = true;
            this.lblDateSched.Location = new System.Drawing.Point(12, 122);
            this.lblDateSched.Name = "lblDateSched";
            this.lblDateSched.Size = new System.Drawing.Size(91, 13);
            this.lblDateSched.TabIndex = 2;
            this.lblDateSched.Text = "Select Start Date:";
            // 
            // lblTimeSched
            // 
            this.lblTimeSched.AutoSize = true;
            this.lblTimeSched.Location = new System.Drawing.Point(247, 122);
            this.lblTimeSched.Name = "lblTimeSched";
            this.lblTimeSched.Size = new System.Drawing.Size(91, 13);
            this.lblTimeSched.TabIndex = 1;
            this.lblTimeSched.Text = "Select Start Time:";
            // 
            // datePickSched
            // 
            this.datePickSched.Location = new System.Drawing.Point(15, 138);
            this.datePickSched.Name = "datePickSched";
            this.datePickSched.Size = new System.Drawing.Size(200, 20);
            this.datePickSched.TabIndex = 0;
            // 
            // Databases
            // 
            this.Databases.Controls.Add(this.gBoxDatabases);
            this.Databases.Location = new System.Drawing.Point(4, 22);
            this.Databases.Name = "Databases";
            this.Databases.Padding = new System.Windows.Forms.Padding(3);
            this.Databases.Size = new System.Drawing.Size(528, 351);
            this.Databases.TabIndex = 4;
            this.Databases.Text = "Databases";
            this.Databases.UseVisualStyleBackColor = true;
            // 
            // gBoxDatabases
            // 
            this.gBoxDatabases.Controls.Add(this.btnDBBrowse);
            this.gBoxDatabases.Controls.Add(this.btnDBNew);
            this.gBoxDatabases.Controls.Add(this.btnDBDelete);
            this.gBoxDatabases.Controls.Add(this.lblDbaseLocation);
            this.gBoxDatabases.Controls.Add(this.lblDbaseServer);
            this.gBoxDatabases.Controls.Add(this.lblDbaseDBName);
            this.gBoxDatabases.Controls.Add(this.lblDbaseID);
            this.gBoxDatabases.Controls.Add(this.txtDbaseLocation);
            this.gBoxDatabases.Controls.Add(this.txtDbaseServer);
            this.gBoxDatabases.Controls.Add(this.txtDbaseDBName);
            this.gBoxDatabases.Controls.Add(this.txtDbaseID);
            this.gBoxDatabases.Controls.Add(this.btnDBSave);
            this.gBoxDatabases.Location = new System.Drawing.Point(6, 9);
            this.gBoxDatabases.Name = "gBoxDatabases";
            this.gBoxDatabases.Size = new System.Drawing.Size(509, 339);
            this.gBoxDatabases.TabIndex = 0;
            this.gBoxDatabases.TabStop = false;
            // 
            // btnDBBrowse
            // 
            this.btnDBBrowse.Location = new System.Drawing.Point(243, 188);
            this.btnDBBrowse.Name = "btnDBBrowse";
            this.btnDBBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnDBBrowse.TabIndex = 12;
            this.btnDBBrowse.Text = "Browse..";
            this.btnDBBrowse.UseVisualStyleBackColor = true;
            this.btnDBBrowse.Click += new System.EventHandler(this.btnDBBrowse_Click);
            // 
            // btnDBNew
            // 
            this.btnDBNew.AutoSize = true;
            this.btnDBNew.Location = new System.Drawing.Point(164, 35);
            this.btnDBNew.Name = "btnDBNew";
            this.btnDBNew.Size = new System.Drawing.Size(73, 23);
            this.btnDBNew.TabIndex = 10;
            this.btnDBNew.Text = "Create New";
            this.btnDBNew.UseVisualStyleBackColor = true;
            this.btnDBNew.Click += new System.EventHandler(this.btnDBNew_Click);
            // 
            // btnDBDelete
            // 
            this.btnDBDelete.AutoSize = true;
            this.btnDBDelete.Location = new System.Drawing.Point(140, 262);
            this.btnDBDelete.Name = "btnDBDelete";
            this.btnDBDelete.Size = new System.Drawing.Size(97, 23);
            this.btnDBDelete.TabIndex = 9;
            this.btnDBDelete.Text = "Delete Database";
            this.btnDBDelete.UseVisualStyleBackColor = true;
            this.btnDBDelete.Click += new System.EventHandler(this.btnDBDelete_Click);
            // 
            // lblDbaseLocation
            // 
            this.lblDbaseLocation.AutoSize = true;
            this.lblDbaseLocation.Location = new System.Drawing.Point(16, 174);
            this.lblDbaseLocation.Name = "lblDbaseLocation";
            this.lblDbaseLocation.Size = new System.Drawing.Size(140, 13);
            this.lblDbaseLocation.TabIndex = 8;
            this.lblDbaseLocation.Text = "Database Backup Location:";
            // 
            // lblDbaseServer
            // 
            this.lblDbaseServer.AutoSize = true;
            this.lblDbaseServer.Location = new System.Drawing.Point(16, 124);
            this.lblDbaseServer.Name = "lblDbaseServer";
            this.lblDbaseServer.Size = new System.Drawing.Size(90, 13);
            this.lblDbaseServer.TabIndex = 7;
            this.lblDbaseServer.Text = "Database Server:";
            // 
            // lblDbaseDBName
            // 
            this.lblDbaseDBName.AutoSize = true;
            this.lblDbaseDBName.Location = new System.Drawing.Point(16, 72);
            this.lblDbaseDBName.Name = "lblDbaseDBName";
            this.lblDbaseDBName.Size = new System.Drawing.Size(87, 13);
            this.lblDbaseDBName.TabIndex = 6;
            this.lblDbaseDBName.Text = "Database Name:";
            // 
            // lblDbaseID
            // 
            this.lblDbaseID.AutoSize = true;
            this.lblDbaseID.Location = new System.Drawing.Point(16, 20);
            this.lblDbaseID.Name = "lblDbaseID";
            this.lblDbaseID.Size = new System.Drawing.Size(21, 13);
            this.lblDbaseID.TabIndex = 5;
            this.lblDbaseID.Text = "ID:";
            // 
            // txtDbaseLocation
            // 
            this.txtDbaseLocation.Location = new System.Drawing.Point(16, 190);
            this.txtDbaseLocation.Name = "txtDbaseLocation";
            this.txtDbaseLocation.Size = new System.Drawing.Size(221, 20);
            this.txtDbaseLocation.TabIndex = 4;
            // 
            // txtDbaseServer
            // 
            this.txtDbaseServer.Location = new System.Drawing.Point(16, 140);
            this.txtDbaseServer.Name = "txtDbaseServer";
            this.txtDbaseServer.Size = new System.Drawing.Size(221, 20);
            this.txtDbaseServer.TabIndex = 3;
            // 
            // txtDbaseDBName
            // 
            this.txtDbaseDBName.Location = new System.Drawing.Point(16, 88);
            this.txtDbaseDBName.Name = "txtDbaseDBName";
            this.txtDbaseDBName.Size = new System.Drawing.Size(221, 20);
            this.txtDbaseDBName.TabIndex = 2;
            this.txtDbaseDBName.TextChanged += new System.EventHandler(this.txtDbaseDBName_TextChanged);
            // 
            // txtDbaseID
            // 
            this.txtDbaseID.Location = new System.Drawing.Point(16, 38);
            this.txtDbaseID.Name = "txtDbaseID";
            this.txtDbaseID.Size = new System.Drawing.Size(35, 20);
            this.txtDbaseID.TabIndex = 1;
            // 
            // btnDBSave
            // 
            this.btnDBSave.AutoSize = true;
            this.btnDBSave.Location = new System.Drawing.Point(16, 262);
            this.btnDBSave.Name = "btnDBSave";
            this.btnDBSave.Size = new System.Drawing.Size(87, 23);
            this.btnDBSave.TabIndex = 0;
            this.btnDBSave.Text = "Save Changes";
            this.btnDBSave.UseVisualStyleBackColor = true;
            this.btnDBSave.Click += new System.EventHandler(this.btnDBSave_Click);
            // 
            // lboxDatabases
            // 
            this.lboxDatabases.FormattingEnabled = true;
            this.lboxDatabases.Location = new System.Drawing.Point(8, 79);
            this.lboxDatabases.Name = "lboxDatabases";
            this.lboxDatabases.Size = new System.Drawing.Size(166, 355);
            this.lboxDatabases.TabIndex = 0;
            this.lboxDatabases.SelectedIndexChanged += new System.EventHandler(this.lboxDatabases_SelectedIndexChanged);
            // 
            // RestoreBrowserDialog
            // 
            this.RestoreBrowserDialog.FileName = "openFileDialog1";
            // 
            // FTPSelectFileDialog
            // 
            this.FTPSelectFileDialog.FileName = "openFileDialog1";
            // 
            // workWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabCont);
            this.Controls.Add(this.lboxDatabases);
            this.Name = "workWindow";
            this.Size = new System.Drawing.Size(790, 454);
            this.tabCont.ResumeLayout(false);
            this.tabBackup.ResumeLayout(false);
            this.gBoxBupSelection.ResumeLayout(false);
            this.gBoxBupSelection.PerformLayout();
            this.gBoxBackingUp.ResumeLayout(false);
            this.gBoxBackingUp.PerformLayout();
            this.pnlError.ResumeLayout(false);
            this.pnlError.PerformLayout();
            this.tabRestore.ResumeLayout(false);
            this.gBoxRestoreSelect.ResumeLayout(false);
            this.gBoxRestoreSelect.PerformLayout();
            this.tabFTP.ResumeLayout(false);
            this.gBoxFTP.ResumeLayout(false);
            this.gBoxFTP.PerformLayout();
            this.tabSchedule.ResumeLayout(false);
            this.gBoxSchedule.ResumeLayout(false);
            this.gBoxSchedule.PerformLayout();
            this.Databases.ResumeLayout(false);
            this.gBoxDatabases.ResumeLayout(false);
            this.gBoxDatabases.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ListBox lboxDatabases;
        private System.Windows.Forms.Button btnSaveBrowse;
        private System.Windows.Forms.FolderBrowserDialog backupLocationDialog;
        internal System.Windows.Forms.Label lblBackupStatus;
        internal System.Windows.Forms.TextBox txtServerName;
        internal System.Windows.Forms.TextBox txtDbName;
        internal System.Windows.Forms.Label lblBackupLocation;
        internal System.Windows.Forms.Label lblServerName;
        internal System.Windows.Forms.Label lblDbname;
        internal System.Windows.Forms.GroupBox gBoxBupSelection;
        internal System.Windows.Forms.GroupBox gBoxBackingUp;
        internal System.Windows.Forms.TextBox txtBackupLocation;
        internal System.Windows.Forms.TextBox txtRestFileLocation;
        internal System.Windows.Forms.TextBox txtRestServerName;
        internal System.Windows.Forms.TextBox txtRestDbName;
        private System.Windows.Forms.Label lblRestoreFile;
        private System.Windows.Forms.Label lblRestoreServer;
        private System.Windows.Forms.Label lblDBRestoreName;
        internal System.Windows.Forms.TabPage tabBackup;
        internal System.Windows.Forms.TabPage tabRestore;
        internal System.Windows.Forms.TabControl tabCont;
        private System.Windows.Forms.Button btnRestoreBrowse;
        private System.Windows.Forms.GroupBox gBoxRestoreSelect;
        private System.Windows.Forms.OpenFileDialog RestoreBrowserDialog;
        private System.Windows.Forms.Panel pnlError;
        internal System.Windows.Forms.TextBox txtlblError;
        internal System.Windows.Forms.Button btnErrorpnl;
        internal System.Windows.Forms.ProgressBar pBarComp;
        internal System.Windows.Forms.ProgressBar pBarBackup;
        private System.Windows.Forms.TabPage tabFTP;
        private System.Windows.Forms.TabPage tabSchedule;
        private System.Windows.Forms.Button btnFTPSave;
        private System.Windows.Forms.Label lblFTPPassword;
        private System.Windows.Forms.Label lblFTPUserName;
        private System.Windows.Forms.Label lblFTPAddress;
        internal System.Windows.Forms.TextBox txtFTPUser;
        internal System.Windows.Forms.TextBox txtFTPServer;
        internal System.Windows.Forms.TextBox txtFTPPass;
        internal System.Windows.Forms.ProgressBar pbarFTP;
        private System.Windows.Forms.Label lblFTPPercent;
        private System.Windows.Forms.Button btnFTPBrowse;
        private System.Windows.Forms.GroupBox gBoxFTP;
        private System.Windows.Forms.OpenFileDialog FTPSelectFileDialog;
        internal System.Windows.Forms.TextBox txtFTPFileBrowse;
        internal System.Windows.Forms.Button btnFTPCancel;
        internal System.Windows.Forms.Label lblFTPError;
        internal System.Windows.Forms.CheckBox chkBoxFTP;
        internal System.Windows.Forms.Label lblDateSched;
        internal System.Windows.Forms.Label lblTimeSched;
        internal System.Windows.Forms.DateTimePicker datePickSched;
        internal System.Windows.Forms.RadioButton rBEveryDay;
        internal System.Windows.Forms.RadioButton rBSunday;
        internal System.Windows.Forms.RadioButton rBSaturday;
        internal System.Windows.Forms.RadioButton rbFriday;
        internal System.Windows.Forms.RadioButton rBThursday;
        internal System.Windows.Forms.RadioButton rBWednesday;
        internal System.Windows.Forms.RadioButton rBTuesday;
        internal System.Windows.Forms.RadioButton rBMonday;
        internal System.Windows.Forms.DateTimePicker timePickSched;
        internal System.Windows.Forms.CheckBox cBWeekly;
        internal System.Windows.Forms.CheckBox cBDaily;
        internal System.Windows.Forms.TextBox txtDaily;
        private System.Windows.Forms.Label lblDays2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblDays1;
        private System.Windows.Forms.GroupBox gBoxSchedule;
        private System.Windows.Forms.Label lblSchedSelectedDB;
        private System.Windows.Forms.Label lblSchedStatus;
        private System.Windows.Forms.Label lblSchedType;
        private System.Windows.Forms.ListBox lBoxSchedTimes;
        private System.Windows.Forms.CheckBox cBBackupAll;
        private System.Windows.Forms.ProgressBar pBarRestore;
        internal System.Windows.Forms.TextBox txtRestoreLocation;
        private System.Windows.Forms.Label lblFTPFileLocation;
        private System.Windows.Forms.FolderBrowserDialog RestoreLocationDialog;
        internal System.Windows.Forms.Label lblRestoreLocation;
        internal System.Windows.Forms.Button btnRestoreLocationBrowse;
        internal System.Windows.Forms.Label lblRestoreStatus;
        private System.Windows.Forms.TabPage Databases;
        private System.Windows.Forms.GroupBox gBoxDatabases;
        private System.Windows.Forms.Label lblDbaseLocation;
        private System.Windows.Forms.Label lblDbaseServer;
        private System.Windows.Forms.Label lblDbaseDBName;
        private System.Windows.Forms.Label lblDbaseID;
        internal System.Windows.Forms.Button btnDBSave;
        internal System.Windows.Forms.TextBox txtDbaseLocation;
        internal System.Windows.Forms.TextBox txtDbaseServer;
        internal System.Windows.Forms.TextBox txtDbaseDBName;
        internal System.Windows.Forms.TextBox txtDbaseID;
        internal System.Windows.Forms.Button btnDBDelete;
        private System.Windows.Forms.Button btnDBNew;
        private System.Windows.Forms.Button btnDBBrowse;
        private System.Windows.Forms.FolderBrowserDialog DatabaseBrowserLocationDialog;
        internal System.Windows.Forms.CheckBox chkBoxCompress;
    }
}
