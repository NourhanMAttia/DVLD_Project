﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_B;

namespace DVLD
{
    public partial class frmMain: Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private frmPeopleManagement ManagePeopleForm = new frmPeopleManagement();
        private void tsmMangePeople_Click(object sender, EventArgs e)
        {
            ManagePeopleForm.Show();
            ManagePeopleForm.MdiParent = this;
        }
    }
}
