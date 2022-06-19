using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data.SqlClient;

namespace SecondChance
{
    public class RestoreOperations
    {
        private mainForm _mF;

        public RestoreOperations(mainForm main)
        {
            this._mF = main;
        }
        internal void RestoreDatabase(String databaseName, String filePath, String serverName, String dataFilePath)//, String logFilePath)
        {
            try
            {
                Server srv = default(Server);
                srv = new Server(serverName);
                Database db = new Database(srv, databaseName); //srv.Databases["mydb"]; 
                Restore rstDatabase = new Restore();

                string dataB = db.ToString().Remove(0, 1);
                rstDatabase.Database = dataB.Remove(dataB.Length - 1, 1);

                BackupDeviceItem bkpDevice = new BackupDeviceItem(filePath, DeviceType.File);

                rstDatabase.Devices.AddDevice(bkpDevice.Name, DeviceType.File);

                rstDatabase.Action = RestoreActionType.Database;

                rstDatabase.ReplaceDatabase = true;

                rstDatabase.ContinueAfterError = true;
                RelocateFile rf = new RelocateFile(databaseName, dataFilePath + databaseName + ".mdf");
                rstDatabase.RelocateFiles.Add(new RelocateFile(databaseName, dataFilePath + databaseName + ".mdf"));
                rstDatabase.RelocateFiles.Add(new RelocateFile(databaseName + "_log", dataFilePath + databaseName + ".ldf"));
                rstDatabase.PercentCompleteNotification = 1;
                rstDatabase.PercentComplete += new PercentCompleteEventHandler(Restore_PercentComplete);
                
                try
                {
                    rstDatabase.SqlRestore(srv);
                }
                catch(Exception ex)
                {
                    this._mF.updateStatusLabel(ex.Message, 1);
                }
                db.SetOnline();
                db.Refresh();
                this._mF.WWin.RestoreProgBarUpdate(100, false);


                //Restore sqlRestore = new Restore();

                //BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
                //sqlRestore.Devices.Add(deviceItem);
                //sqlRestore.Database = databaseName;

                //ServerConnection connection = new ServerConnection(serverName);
                //Server sqlServer = new Server(connection);

                //Database db = sqlServer.Databases[databaseName];
                //sqlRestore.Action = RestoreActionType.Database;
                //String dataFileLocation = dataFilePath + databaseName + ".mdf";
                //String logFileLocation = dataFilePath + databaseName + "_Log.ldf";
                //db = sqlServer.Databases[databaseName];
                //RelocateFile rf = new RelocateFile(databaseName, dataFileLocation);

                //sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName, dataFileLocation));
                //sqlRestore.RelocateFiles.Add(new RelocateFile(databaseName + "_log", logFileLocation));
                //sqlRestore.ReplaceDatabase = true;               
                //sqlRestore.PercentCompleteNotification = 1;
                //sqlRestore.PercentComplete += new PercentCompleteEventHandler(Restore_PercentComplete);
                //try
                //{
                //    sqlRestore.SqlRestore(sqlServer);
                //}
                //catch(Exception ex)
                //{
                //    this._mF.updateStatusLabel(ex.Message, 1);
                //}

                //db = sqlServer.Databases[databaseName];

                //db.SetOnline();

                //sqlServer.Refresh();
                //this._mF.WWin.RestoreProgBarUpdate(100, false);

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

                this._mF.WriteLog(str, 2);
                this._mF.updateStatusLabel("Restore Failed, Check event logs for more info.",1);                
                //MessageBox.Show(str);
            }
                #endregion
        }
        internal void Restore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            this._mF.WWin.RestoreProgBarUpdate(e.Percent,true);

        }
    }
}
