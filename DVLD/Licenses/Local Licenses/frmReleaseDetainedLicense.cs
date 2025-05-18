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
    public partial class frmReleaseDetainedLicense : Form
    {
        private int _LicenseID = -1;
        public frmReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        private void frmReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            btnRelease.Enabled = false;
            lblReleasedBy.Text = clsGlobal.GlobalUser.Username;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelectedHandler;
        }
        private void OnLicenseSelectedHandler(int LicenseID)
        {
            _LicenseID = LicenseID;
            clsDetainedLicense detainedLicense = clsDetainedLicense.GetDetainedLicenseInfoByLicenseID(LicenseID);
            lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();
            lblDetainedBy.Text = detainedLicense.CreatedByUserID.ToString();
            lblDetainID.Text = detainedLicense.DetainID.ToString();
            lblLicenseID.Text = detainedLicense.LicenseID.ToString();
            clsApplicationType appType = clsApplicationType.Find(5);
            lblApplicationFees.Text = appType.Fees.ToString();
            lblFineFees.Text = "50";
            lblTotalFees.Text = (appType.Fees + 50).ToString();
            if (detainedLicense.IsReleased)
            {
                MessageBox.Show("License Already Released.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnRelease.Enabled = true;
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            clsDetainedLicense detainedLicense = clsDetainedLicense.GetDetainedLicenseInfoByLicenseID(_LicenseID);
            clsLicense license = clsLicense.GetLicenseInfoByID(_LicenseID);
            clsDriver driver = clsDriver.GetDriverByID(license.DriverID);
            clsApplicationType apptype = clsApplicationType.Find(5);
            clsApplication application = new clsApplication();
            application.ApplicantPersonID = driver.PersonID;
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            application.ApplicationTypeID = 5;
            application.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            application.LastStatusDate = DateTime.Now;
            application.PaidFees = apptype.Fees;
            if (application.Save())
            {
                detainedLicense.IsReleased = true;
                detainedLicense.ReleaseApplicationID = application.ApplicationID;
                detainedLicense.ReleaseDate = DateTime.Now;
                detainedLicense.ReleasedByUserID = clsGlobal.GlobalUser.UserID;
                if (detainedLicense.Save())
                    MessageBox.Show("License Was Release Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed To Release License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Failed To Create Application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnRelease.Enabled = false;
        }
    }
}
