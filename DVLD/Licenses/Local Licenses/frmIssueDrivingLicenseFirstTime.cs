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

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmIssueDrivingLicenseFirstTime : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmIssueDrivingLicenseFirstTime(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmIssueDrivingLicenseFirstTime_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            clsDriver driver = new clsDriver();
            driver.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            driver.CreatedDate = DateTime.Now;
            driver.PersonID = localApp.ApplicantPersonID;
            if (driver.Save())
            {
                MessageBox.Show("Driver Added Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsLicense license = new clsLicense();
                license.ApplicationID = localApp.ApplicationID;
                license.DriverID = driver.DriverID;
                license.LicenseClass = localApp.LicenseClassID;
                license.IssueDate = DateTime.Now;
                localApp.LicenseClassInfo = clsLicenseClass.GetLicenseClassByID(localApp.LicenseClassID);
                license.ExpirationDate = license.IssueDate.AddYears(localApp.LicenseClassInfo.DefaultValidityLength);
                license.Notes = txtNotes.Text;
                license.PaidFees = localApp.PaidFees;
                license.IsActive = true;
                license.IssueReason = 1;
                license.CreatedByUserID = clsGlobal.GlobalUser.UserID;
                if (license.Save())
                    MessageBox.Show("License Created Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed To Create License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Failed To Add Driver.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
