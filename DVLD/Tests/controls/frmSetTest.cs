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

namespace DVLD.Tests.controls
{
    public partial class frmAddAppointment : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID;
        public frmAddAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }
        private void frmAddAppointment_Load(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if(localApp == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLocalID.Text = localApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = localApp.LicenseClassInfo.ClassName;
            localApp.PersonInfo = clsPerson.Find(localApp.ApplicantPersonID);
            lblName.Text = localApp.PersonInfo.FullName;
            clsTestType TestTypeInfo = clsTestType.GetTestTypeByID(_TestTypeID);
            DataTable _dtAllAppointmentsPerTest = clsTestAppointment.GetApplicationTestAppointmentPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            lblTrials.Text = _dtAllAppointmentsPerTest.Rows.Count.ToString();
            lblFees.Text = TestTypeInfo.Fees.ToString();
            dtpTestAppointment.MinDate = DateTime.Today;
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        gbTestInfo.Text = "Vision Test";
                        pbTestImage.Image = Properties.Resources.eye64;
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        gbTestInfo.Text = "Written Test";
                        pbTestImage.Image = Properties.Resources.test64;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        gbTestInfo.Text = "Street Test";
                        pbTestImage.Image = Properties.Resources.car64;
                        break;
                    }
            }
            //clsApplication application = clsApplication.FindBaseApplicaiton(localApp.ApplicationID);
            //lblTotalFees.Text = (TestTypeInfo.Fees).ToString();
            
            if(_dtAllAppointmentsPerTest.Rows.Count > 0)
            {
                gbRetakeTest.Enabled = true;
            }
        }
    }
}
