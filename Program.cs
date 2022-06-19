using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SecondChance
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            
            if (args.Length == 0) //if no args have been passed eg. not scheduled.
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainForm(null));
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mainForm(args[0]));
                //MessageBox.Show(args[0]);                
            }
        }
    }
}
