using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace SecondChance
{
    public class CompressOperations
    {
        private mainForm _mF;

        public CompressOperations(mainForm main)
        {
            this._mF = main;
        }

        internal bool AutoCompressBackup(string backupName, string backupLocation, string fileToBeBackedUp)
        {
            try
            {
                if (!File.Exists(backupLocation + "7za.exe"))
                {
                    this._mF.ExtractsevenZip();
                }
                Process pro = new Process();
                pro.StartInfo.FileName = "7za.exe";
                pro.StartInfo.WorkingDirectory = backupLocation;
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pro.StartInfo.Arguments = " -mx9 a " + backupName + ".7z \"" + fileToBeBackedUp + "";                
                pro.Start();
                pro.WaitForExit();

                int extCode = pro.ExitCode;

                File.Delete(backupLocation + "7za.exe");

                #region handle the exitcode.
                if (extCode == 0)
                {

                    return true;
                }
                else if (extCode == 1)
                {

                    return false;
                }
                else if (extCode == 2)
                {

                    return false;
                }
                else if (extCode == 7)
                {

                    return false;
                }
                else if (extCode == 8)
                {

                    return false;
                }
                else if (extCode == 255)
                {

                    return false;
                }
                else
                {

                    return false;
                }
            }
                #endregion
            catch (Exception ex)
            {
                return false;
            }
                

        }
        internal void ManualCompressBackup(string backupName, string backupLocation, string fileToBeBackedUp)
        {
            try
            {
                if(!File.Exists(backupLocation + ".7za.exe"))
                {
                    this._mF.ExtractsevenZip();
                }

                this._mF.updateStatusLabel("Preparing to compress " + this._mF.WWin.txtDbName.Text + " backup", 0);


                Process pro = new Process();
                pro.StartInfo.FileName = "7za.exe";
                pro.StartInfo.WorkingDirectory = backupLocation;               
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pro.StartInfo.Arguments = " -mx9 a " + backupName  + ".7z \"" + fileToBeBackedUp + "";

                this._mF.updateStatusLabel("Compressing Database: " + this._mF.WWin.txtDbName.Text, 0); //update status label.                  
                pro.Start();

                pro.WaitForExit();
                int extCode = pro.ExitCode;
                this._mF.ManualCompressCallBack(extCode);  //returns exit code   
                
            }
            catch(Exception ex)
            {
                this._mF.updateStatusLabel("Compression Failed!\r\n" + ex.Message, 1); 
            }

        }
        
    }
}
