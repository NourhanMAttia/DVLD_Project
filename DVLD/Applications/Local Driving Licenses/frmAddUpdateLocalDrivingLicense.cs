using DVLD.Global_Classes;
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
        private int _LocalLicenseApplicaitonID = -1;
        private clsLocalDrivingLicenseApplication _obj;
        private void _FillLicenseClassesComboBox()
        {

        }
        private void _RefreshApplicationForm()
        {
            _Person = new clsPerson();
            _obj = new clsLocalDrivingLicenseApplication();
            lblLocalDrivingLicenseApplicationID.Text = "???";
            lblApplicationID.Text = "???";
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationFee.Text = "???";
            lblCreatedBy.Text = clsGlobal.GlobalUser.Username;
            _FillLicenseClassesComboBox();
        }
        private void _LoadApplicationInfo()
        {
            _obj = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalLicenseApplicaitonID);
            if(_obj == null)
            {
                MessageBox.Show("Invalid Local License Applicaiton ID.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblLocalDrivingLicenseApplicationID.Text = _obj.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationID.Text = _obj.ApplicationID.ToString();
            //lblApplicationDate.Text = _obj.

        }
        public frmAddUpdateLocalDrivingLicense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicense(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalLicenseApplicaitonID = LocalLicenseApplicationID;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Person == null)
            {
                MessageBox.Show("Select A Person First.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
