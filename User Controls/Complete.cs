using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SecondChance
{
    public partial class Complete : UserControl
    {
        private mainForm _mF;

        public Complete(mainForm main)
        {
            this._mF = main;
            InitializeComponent();
        }

        private void Complete_Load(object sender, EventArgs e)
        {
            this.lblCompleteTitle.Text = "All operations are complete.\r\nIf you would like to perform more tasks check the Restart checkbox.";
        }
    }
}
