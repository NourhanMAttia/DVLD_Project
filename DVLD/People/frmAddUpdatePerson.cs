using System;
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
    public partial class frmAddUpdatePerson: Form
    {
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        enum enMode { AddNew = 0, Update };
        enMode Mode = enMode.AddNew;
        private void _Load()
        {
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _Load();
        }

    }
}
