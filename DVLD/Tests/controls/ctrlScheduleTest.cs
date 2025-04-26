using DVLD.People;
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
    public partial class ctrlScheduleTest : UserControl
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public ctrlScheduleTest()
        {
            InitializeComponent();
        }
        public void LoadInfo(int LocalDrivingLicenseApplicationID, clsTest.enTestType TestType, int AppointmentID=-1)
        {
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            clsLocalDrivingLicenseApplication localApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if(localApplication == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsApplication application = clsApplication.FindBaseApplicaiton(localApplication.ApplicationID);
            if(application == null)
            {
                MessageBox.Show("Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblLocalApplicationID.Text = localApplication.LocalDrivingLicenseApplicationID.ToString();
            lblLicenseClass.Text = localApplication.LicenseClassInfo.ClassName;
            lblPassedTests.Text = clsTest.PassedTestCount(_LocalDrivingLicenseApplicationID).ToString();

            lblID.Text = application.ApplicationID.ToString();
            lblStatus.Text = application.StatusText;
            lblFees.Text = application.PaidFees.ToString();
            lblType.Text = application.ApplicationTypeInfo.Name;
            lblApplicant.Text = application.PersonInfo.FullName;
            lblDate.Text = application.ApplicationDate.ToShortDateString();
            lblStatusDate.Text = application.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = application.CreatedByUserInfo.Username;
        }
        private void llblShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLocalDrivingLicenseApplication localApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if (localApplication == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowPersonInfo frm = new frmShowPersonInfo(localApplication.ApplicantPersonID);
            frm.ShowDialog();
        }
        private void llblShowLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
