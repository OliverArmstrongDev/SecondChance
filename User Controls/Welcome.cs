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
    public partial class Welcome : UserControl
    {
        private mainForm _mF;

        public Welcome(mainForm main)
        {
            this._mF = main;
            InitializeComponent();
        }
    }
}
