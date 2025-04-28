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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Tests.controls
{
    public partial class frmAddAppointment : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID;
        clsLocalDrivingLicenseApplication _localApp;
        public frmAddAppointment(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }
        private void frmAddAppointment_Load(object sender, EventArgs e)
        {
            _localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if(_localApp == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLocalID.Text = _localApp.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = _localApp.LicenseClassInfo.ClassName;
            _localApp.PersonInfo = clsPerson.Find(_localApp.ApplicantPersonID);
            lblName.Text = _localApp.PersonInfo.FullName;
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
            clsApplication application = clsApplication.FindBaseApplicaiton(_localApp.ApplicationID);
            
            if (_dtAllAppointmentsPerTest.Rows.Count > 0)
            {
                application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                application.ApplicationTypeInfo = clsApplicationType.Find((int)clsApplication.enApplicationType.RetakeTest);
                lblRetakeAppFees.Text = application.ApplicationTypeInfo.Fees.ToString();
                lblTotalFees.Text = (TestTypeInfo.Fees + application.ApplicationTypeInfo.Fees).ToString();
                gbRetakeTest.Enabled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTestAppointment appointment = new clsTestAppointment();
            appointment.AppointmentDate = dtpTestAppointment.Value;
            appointment.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            appointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
            appointment.TestTypeID = _TestTypeID;
            appointment.PaidFees = int.Parse(lblFees.Text);
            appointment.RetakeTestApplicationID = -1;
            DataTable _dtAllAppointmentsPerTest = clsTestAppointment.GetApplicationTestAppointmentPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            if (_dtAllAppointmentsPerTest.Rows.Count > 0)
            {
                clsTestAppointment lastAppointment = clsTestAppointment.GetLastTestAppointment(_TestTypeID, _LocalDrivingLicenseApplicationID);
                if (!lastAppointment.IsLocked)
                {
                    MessageBox.Show("Error : Can't Set New Appointment When You Still A Valid One.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                clsTestType testTypeInfo = clsTestType.GetTestTypeByID(_TestTypeID);
                clsApplication application = clsApplication.FindBaseApplicaiton(_localApp.ApplicationID);
                _localApp.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                appointment.PaidFees = testTypeInfo.Fees + application.ApplicationTypeInfo.Fees;
            }
            if (appointment.Save())
                MessageBox.Show("Appointment Set Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error Setting Test Appointment.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
