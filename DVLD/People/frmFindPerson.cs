﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People
{
    public partial class frmFindPerson: Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }
        public delegate void FormClosedDelegate(object sender, int PersonID);
        public event FormClosedDelegate OnFormClosed;

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnFormClosed?.Invoke(this, ctrlPersonCardInfoWithFilter1.PersonID);
            this.Close();
        }
    }
}
