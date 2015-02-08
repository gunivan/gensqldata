using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PopulateSqlData
{
    public partial class MGridView : DataGridView
    {
        public MGridView()
        {
            InitializeComponent();
            //DoubleBuffered = true;
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
                DoubleBuffered = true;
        }

        private void MGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

    }
}
