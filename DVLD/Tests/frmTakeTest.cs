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

namespace DVLD.Tests
{
    public partial class frmTakeTest : Form
    {
        private int _appointmentID = -1;
        public frmTakeTest(int AppointmentID)
        {
            InitializeComponent();
            _appointmentID = AppointmentID;
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            clsTestAppointment appointment = clsTestAppointment.Find(_appointmentID);
            if(appointment == null)
            {
                MessageBox.Show("Appointment Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlScheduledTest1.LoadInfoInControl(_appointmentID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTest test = new clsTest();
            test.TestAppointmentID = _appointmentID;
            test.TestResult = (rbPass.Checked) ? true : false;
            test.Notes = txtNotes.Text;
            test.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            clsTestAppointment appointment = clsTestAppointment.Find(_appointmentID);
            appointment.IsLocked = true;
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(appointment.LocalDrivingLicenseApplicationID);
            if (appointment.TestTypeID == clsTestType.enTestType.StreetTest && test.TestResult)
            {
                localApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                localApp.LastStatusDate = DateTime.Now;
            }
            if (test.Save() && appointment.Save() && localApp.Save())
                MessageBox.Show("Data Saved Successfuly.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error Saving Data.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
