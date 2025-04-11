using DVLD_B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_Licenses
{
    public partial class frmAddUpdateLocalDrivingLicense : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private clsPerson _Person;
        private void _RefreshApplicationForm()
        {
            _Person = new clsPerson();
        }
        private void _LoadApplicationInfo()
        {
            ctrlPersonCardInfoWithFilter1.LoadPersonInfo()
        }
        public frmAddUpdateLocalDrivingLicense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicense(int ApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Person == null)
            {
                MessageBox.Show("Choose A Person First.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            tcApplication.SelectedTab = tpApplicationInfo;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _RefreshApplicationForm();
            if (_Mode == enMode.Update)
                _LoadApplicationInfo();
        }
        private void tcApplication_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(tcApplication.SelectedTab == tpApplicationInfo && _Person == null)
            {
                MessageBox.Show("Select A Person First.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
