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
    public partial class ctrlScheduledTest : UserControl
    {
        private int _TestID = -1;
        public int TestID
        {
            set
            {
                _TestID = value;
            }
        }
        public ctrlScheduledTest()
        {
            InitializeComponent();
        }
        public void LoadInfoInControl(int AppointmentID)
        {
            clsTestAppointment appointment = clsTestAppointment.Find(AppointmentID);
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(appointment.LocalDrivingLicenseApplicationID);
            switch (appointment.TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestImage.Image = Properties.Resources.eye64;
                        gbTestInfo.Text = "Vision Test";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        pbTestImage.Image = Properties.Resources.test64;
                        gbTestInfo.Text = "Written Test";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        pbTestImage.Image = Properties.Resources.car64;
                        gbTestInfo.Text = "Street Test";
                        break;
                    }
            }
            lblLocalAppID.Text = appointment.LocalDrivingLicenseApplicationID.ToString();
            localApp.LicenseClassInfo = clsLicenseClass.GetLicenseClassByID(localApp.LicenseClassID);
            lblLicenseClass.Text = localApp.LicenseClassInfo.ClassName;
            localApp.PersonInfo = clsPerson.Find(localApp.ApplicantPersonID);
            lblName.Text = localApp.PersonInfo.FullName;
            DataTable dt = clsTestAppointment.GetApplicationTestAppointmentPerTestType(localApp.LocalDrivingLicenseApplicationID, appointment.TestTypeID);
            lblTrials.Text = ((dt.Rows.Count) - 1).ToString();
            lblDate.Text = appointment.AppointmentDate.ToShortDateString();
            lblFees.Text = appointment.PaidFees.ToString();
            lblTestID.Text = (_TestID == -1) ? "Not Taken Yet." : _TestID.ToString();
        }
    }
}
