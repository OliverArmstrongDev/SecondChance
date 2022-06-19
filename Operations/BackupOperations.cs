using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Diagnostics;
using System.Threading;
using System.Xml;
using System.IO;
using System.Xml.Serialization;

namespace SecondChance
{       
   public class BackupOperations
    {
       private mainForm _mF;
       internal bool BackupCompletedSuccess;

       public BackupOperations(mainForm main)
        {
            this._mF = main;
        }

       internal bool AutoBackupDatabase(String databaseName, String serverName, String destinationPath)
        {
            try
            {

                Backup sqlBackup = new Backup();

                sqlBackup.Action = BackupActionType.Database;
                sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Today.ToString();
                sqlBackup.BackupSetName = "Archive";

                sqlBackup.Database = databaseName;

                BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
                ServerConnection connection = new ServerConnection(serverName);//, userName, password);
                Server sqlServer = new Server(connection);

                Database db = sqlServer.Databases[databaseName];

                sqlBackup.Initialize = true;
                sqlBackup.Checksum = true;
                sqlBackup.ContinueAfterError = true;

                sqlBackup.Devices.Add(deviceItem);
                sqlBackup.Incremental = false;

                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(1);
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

                sqlBackup.FormatMedia = false;
                try
                {
                    sqlBackup.SqlBackup(sqlServer);

                    return true;
                }

                catch (Exception ex)
                {

                   
                    #region catchBackupErrors
                    //use below code for debugging..


                    String str = "Error for backup " + ex.Message + Environment.NewLine;

                    str += "StackTrace : " + ex.StackTrace + Environment.NewLine;

                    if (ex.InnerException != null)
                    {

                        str += "Inner1 : " + ex.InnerException.Message + Environment.NewLine;

                        if (ex.InnerException.InnerException != null)
                        {

                            str += "Inner2 : " + ex.InnerException.InnerException.Message + Environment.NewLine;

                        }

                    }

                    //write error to eventlog
                    this._mF.WriteLog(str, 2);
                    return false;
                }
                    #endregion
            }
            catch (Exception ex)
            {
                this._mF.WriteLog(ex.Message, 2);
                return false;
            }
        }
       internal void ManualBackupDatabase(String databaseName, String serverName, String destinationPath)
        {
            try
            {

                Backup sqlBackup = new Backup();

                sqlBackup.Action = BackupActionType.Database;
                sqlBackup.BackupSetDescription = "ArchiveDataBase:" + DateTime.Today.ToString();
                sqlBackup.BackupSetName = "Archive";

                sqlBackup.Database = databaseName;

                BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
                ServerConnection connection = new ServerConnection(serverName);//, userName, password);
                Server sqlServer = new Server(connection);

                Database db = sqlServer.Databases[databaseName];

                sqlBackup.Initialize = true;
                sqlBackup.Checksum = true;
                sqlBackup.ContinueAfterError = true;

                sqlBackup.Devices.Add(deviceItem);
                sqlBackup.Incremental = false;

                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(1);
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

                sqlBackup.FormatMedia = false;
                try
                {
                    this._mF.updateStatusLabel("Backing up " + databaseName, 0);
                    sqlBackup.PercentCompleteNotification = 1;
                    sqlBackup.PercentComplete += new PercentCompleteEventHandler(bkp_PercentComplete);
                    sqlBackup.SqlBackup(sqlServer);
                    this._mF.updateStatusLabel("Backup of " + databaseName + " Successful", 0);

                    BackupCompletedSuccess = true;
                }

                catch (Exception ex)
                {
                    //this._mF.updateStatusLabel(ex.Message, 1);
                    //BackupCompletedSuccess = false;

                    #region catchBackupErrors
                    //use below code for debugging..


                    String str = "Error for backup " + ex.Message + Environment.NewLine;

                    str += "StackTrace : " + ex.StackTrace + Environment.NewLine;

                    if (ex.InnerException != null)
                    {

                        str += "Inner1 : " + ex.InnerException.Message + Environment.NewLine;

                        if (ex.InnerException.InnerException != null)
                        {

                            str += "Inner2 : " + ex.InnerException.InnerException.Message + Environment.NewLine;

                        }

                    }
                    //write error to eventlog
                    this._mF.WriteLog(str, 2);
                        this._mF.updateErrorText(str,true);
                        BackupCompletedSuccess = false;
                    
                    #endregion
                }
                if (BackupCompletedSuccess)
                {
                    _mF.ManualBackupThreadCallBack(); // calls compression method if backup was successful
                }
            }
            catch (Exception ex)
            {
                this._mF.WriteLog(ex.Message, 2); 
                BackupCompletedSuccess = false;
            }
        }
       internal void bkp_PercentComplete(object sender, PercentCompleteEventArgs e)
       {
           this._mF.updateProgressBar(e.Percent);

       }
    }
}
