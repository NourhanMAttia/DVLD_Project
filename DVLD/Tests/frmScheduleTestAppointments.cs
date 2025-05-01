using DVLD.Tests.controls;
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

namespace DVLD.Tests
{
    public partial class frmScheduleTestAppointments : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTest.enTestType _TestTypeID;
        private DataTable _dtAllAppointmentsPerTestType;
        private void _RefreshAppointmentsList()
        {
            _dtAllAppointmentsPerTestType = clsTestAppointment.GetApplicationTestAppointmentPerTestType(_LocalDrivingLicenseApplicationID, (clsTestType.enTestType)_TestTypeID);
            dgvAppointments.DataSource = _dtAllAppointmentsPerTestType;
            lblRecords.Text = _dtAllAppointmentsPerTestType.Rows.Count.ToString();
        }
        public frmScheduleTestAppointments(int LocalDrivingLicenseApplicationID, clsTest.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
        }
        private void frmScheduleTestAppointments_Load(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if(localApp  == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsApplication app = clsApplication.FindBaseApplicaiton(localApp.ApplicationID);
            if (app == null)
            {
                MessageBox.Show("Base Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestTypeID);
            _RefreshAppointmentsList();
            switch (_TestTypeID)
            {
                case clsTest.enTestType.VisionTest:
                    {
                        lblTitle.Text = "Schedule Vision Test";
                        pbTestImage.Image = Properties.Resources.eye64;
                        break;
                    }
                case clsTest.enTestType.WrittenTest:
                    {
                        lblTitle.Text = "Schedule Written Test";
                        pbTestImage.Image = Properties.Resources.test64;
                        break;
                    }
                case clsTest.enTestType.StreetTest:
                    {
                        lblTitle.Text = "Schedule Street Test";
                        pbTestImage.Image = Properties.Resources.car64;
                        break;
                    }
            }
        }
        private void btnAddAppointments_Click(object sender, EventArgs e)
        {
            clsTestAppointment lastAppointment = clsTestAppointment.GetLastTestAppointment((clsTestType.enTestType)_TestTypeID, _LocalDrivingLicenseApplicationID);
            if(lastAppointment != null && !lastAppointment.IsLocked)
            {
                MessageBox.Show("Error : Can't Set New Appointment When You Still Have Another Valid One.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmAddAppointment frm = new frmAddAppointment(_LocalDrivingLicenseApplicationID, (clsTestType.enTestType)_TestTypeID);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }

        private void tsmEditTestAppointmentInfo_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmAddAppointment frm = new frmAddAppointment(_LocalDrivingLicenseApplicationID, (clsTestType.enTestType)_TestTypeID, AppointmentID);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }
        private void tsmTakeTest_Click(object sender, EventArgs e)
        {
            int AppointmentID = (int)dgvAppointments.CurrentRow.Cells[0].Value;
            frmTakeTest frm = new frmTakeTest(AppointmentID);
            frm.ShowDialog();
            _RefreshAppointmentsList();
        }
    }
}
