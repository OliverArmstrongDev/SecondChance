using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using TaskScheduler;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;



namespace SecondChance
{
    public class Schedule
    {
        internal TaskService ts;        
        private mainForm _mF;


        public Schedule(mainForm main)
        {
            this._mF = main;
        }
        internal bool CreateSchedule()
        {
            try
            {
                string time = this._mF.WWin.timePickSched.Text;
                string date = this._mF.WWin.datePickSched.Value.ToShortDateString();


                DateTime dt = Convert.ToDateTime(date + " " + time);


                // Get the service on the local machine
                ts = new TaskService();

                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Backs up specified SQL databases, compresses and FTP's!";
                               


                if (this._mF.WWin.cBDaily.Checked)
                {
                    // Create a trigger that will fire the task at this time every N day
                    td.Triggers.Add(new DailyTrigger { StartBoundary = dt, DaysInterval = short.Parse(_mF.WWin.txtDaily.Text) });
                }
             
                if (this._mF.WWin.cBWeekly.Checked)
                {
                    td.Triggers.Add(new WeeklyTrigger { StartBoundary = dt, DaysOfWeek = this._mF.WWin.dayofweek });
                }
                
                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(this._mF.ScheduleExeLocation, this._mF.WWin.ArgsToPass, null));

                // Register the task in the root folder
                //ts.RootFolder.RegisterTaskDefinition(this._mF.WWin.lboxDatabases.SelectedItem.ToString(), td);
                ts.RootFolder.RegisterTaskDefinition(this._mF.WWin.lboxDatabases.SelectedItem.ToString(), td, TaskCreation.CreateOrUpdate, "secondchance", "#Secondch@nc3", TaskLogonType.Password, null);

                ts.Dispose();
                td.Dispose();
                return true;
                

            }
            catch(Exception ex)
            {
                this._mF.WriteLog(ex.Message, 2); //writes to event log.
                return false;
            }
        }
        internal bool CreateScheduleForALL()
        {
            try
            {
                string time = this._mF.WWin.timePickSched.Text;
                string date = this._mF.WWin.datePickSched.Value.ToShortDateString();


                DateTime dt = Convert.ToDateTime(date + " " + time);


                // Get the service on the local machine
                ts = new TaskService();

                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Backs up specified SQL databases, compresses and FTP's!";
                                


                if (this._mF.WWin.cBDaily.Checked)
                {
                    // Create a trigger that will fire the task at this time every N day
                    td.Triggers.Add(new DailyTrigger { StartBoundary = dt, DaysInterval = short.Parse(_mF.WWin.txtDaily.Text) });
                }

                if (this._mF.WWin.cBWeekly.Checked)
                {
                    td.Triggers.Add(new WeeklyTrigger { StartBoundary = dt, DaysOfWeek = this._mF.WWin.dayofweek });
                }

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(this._mF.ScheduleExeLocation, this._mF.WWin.ArgsToPass, null));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition("ALL", td, TaskCreation.CreateOrUpdate, "secondchance", "#Secondch@nc3", TaskLogonType.Password, null);

                ts.Dispose();
                td.Dispose();
                return true;


            }
            catch (Exception ex)
            {
                this._mF.WriteLog(ex.Message, 2); //writes to event log.
                return false;
            }
        }
        internal string GetSchedule()
        {
            
                     Process p = new Process();
                     p.StartInfo.WorkingDirectory = Environment.SystemDirectory;
                     p.StartInfo.UseShellExecute = false;
                     p.StartInfo.RedirectStandardOutput = true;
                     p.StartInfo.CreateNoWindow = true;
                     p.StartInfo.FileName = "schtasks";
                     p.StartInfo.Arguments = "/Query /FO CSV /TN myapp";
                     p.Start();
                     
                     // p.WaitForExit();
                     
                     string output = p.StandardOutput.ReadToEnd();
                     p.WaitForExit();
                     return output;


                     //Process pro = new Process();
                     //pro.StartInfo.FileName = "schtasks";
                     //pro.StartInfo.WorkingDirectory = Environment.SystemDirectory;
                     //pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                     //pro.StartInfo.Arguments = "/create /tn MyApp /tr C:\\SQLbackups\\7za.exe /sc daily /st 08:00 /ed 31/12/2010";
                     //pro.Start();
                     //pro.WaitForExit();

        }
    }
}
