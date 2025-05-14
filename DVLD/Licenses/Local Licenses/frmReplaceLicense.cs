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
    public partial class frmReplaceLicense : Form
    {
        public frmReplaceLicense()
        {
            InitializeComponent();
        }
        private void frmReplaceLicense_Load(object sender, EventArgs e)
        {
            llblShowLicenseHistory.Enabled = false;
            llblShowNewLicenseInfo.Enabled = false;
            btnReplace.Enabled = false;
            rbDamage.Checked = true;
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.GlobalUser.Username;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int LicenseID = int.Parse(txtFilterValue.Text);
            ctrlLicenseInfo1.LoadInfo(LicenseID, true);
            clsLicense license = clsLicense.GetLicenseInfoByID(LicenseID);
            if(license == null)
            {
                MessageBox.Show("License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!license.IsActive)
            {
                MessageBox.Show("Can't Replace Inactive License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReplace.Enabled = true;
            lblOldLicenseID.Text = txtFilterValue.Text;
        }
        private void btnReplace_Click(object sender, EventArgs e)
        {
            gbFilter.Enabled = false;
            int oldLicenseID = int.Parse(txtFilterValue.Text);
            clsLicense oldLicense = clsLicense.GetLicenseInfoByID(oldLicenseID);
            clsDriver driver = clsDriver.GetDriverByID(oldLicense.DriverID);
            clsLocalDrivingLicenseApplication localApp = new clsLocalDrivingLicenseApplication();
            localApp.ApplicantPersonID = driver.PersonID;
            localApp.ApplicationDate = DateTime.Now;
            localApp.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            localApp.ApplicationTypeID = (rbDamage.Checked) ?(int)clsApplicationType.enApplicationType.ReplaceForDamage: (int)clsApplicationType.enApplicationType.ReplaceForLost;
            localApp.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            localApp.LastStatusDate = DateTime.Now;
            localApp.LicenseClassID = oldLicense.LicenseClass;
            clsApplicationType appType = clsApplicationType.Find(localApp.ApplicationTypeID);
            localApp.PaidFees = appType.Fees;
            if (localApp.Save())
            {
                oldLicense.DeactivateLicense();
                oldLicense.IsActive = false;
                oldLicense.Save();
                clsLicense newLicense = new clsLicense();
                newLicense.ApplicationID = localApp.ApplicationID;
                newLicense.CreatedByUserID = clsGlobal.GlobalUser.UserID;
                newLicense.DriverID = driver.DriverID;
                newLicense.IsActive = true;
                newLicense.IssueDate = DateTime.Now;
                newLicense.ExpirationDate = newLicense.IssueDate.AddYears(clsLicenseClass.GetDefaultValidityLengthPerClass(localApp.LicenseClassID));
                newLicense.IssueReason = (byte)localApp.ApplicationTypeID;
                newLicense.LicenseClass = oldLicense.LicenseClass;
                newLicense.PaidFees = oldLicense.PaidFees;
                if (newLicense.Save())
                {
                    MessageBox.Show("New License Created Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblAppID.Text = localApp.ApplicationID.ToString();
                    lblNewLicenseID.Text = newLicense.LicenseID.ToString();
                    lblAppFees.Text = localApp.PaidFees.ToString();
                }
                else
                    MessageBox.Show("Error Creating New License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Error Creating Application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //
        }
        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
