using DVLD.Global_Classes;
using DVLD.Licenses.Local_Licenses;
using DVLD_B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_Licenses
{
    public partial class frmInternationalLicenseApplication : Form
    {
        private int _LicenseID = -1;
        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }
        private void frmInternationalLicenseApplication_Load(object sender, EventArgs e)
        {
            btnIssueLicense.Enabled = false;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += LicenseSelectedHandler;
        }
        private void LicenseSelectedHandler(int licenseID)
        {
            _LicenseID = licenseID;
            clsLicense localLicense = clsLicense.GetLicenseInfoByID(_LicenseID);
            if (localLicense == null)
            {
                MessageBox.Show("Local License Not Found. Choose Another One.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!localLicense.IsActive)
            {
                MessageBox.Show("Local License Not Active. Issue A New One.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsInternationalLicense lastActiveInternationalLicense = clsInternationalLicense.GetLastActiveInternationalLicense(localLicense.DriverID);
            if (lastActiveInternationalLicense != null)
            {
                MessageBox.Show("Current License Is Active. Can't Issue Another One.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
            // REMEMBER : check for detained === after i finish detained classes
            btnIssueLicense.Enabled = true;
        }
        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsInternationalLicense iLicense = clsInternationalLicense.GetInternationalLicenseInfo(_LicenseID);
            if (iLicense == null)
            {
                MessageBox.Show("License Not Found. Choose Another One.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmLicenseHistory frm = new frmLicenseHistory(iLicense.IssuedUsingLocalLicenseID);
            frm.ShowDialog();
        }
        private void llblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //
        }
        private void btnIssueLicense_Click(object sender, EventArgs e)
        {
            clsLicense localLicense = clsLicense.GetLicenseInfoByID(_LicenseID);
            clsApplication application = new clsApplication();
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            application.ApplicationTypeID = 6;
            application.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            application.LastStatusDate = DateTime.Now;
            clsApplicationType appType = clsApplicationType.Find(6);
            application.PaidFees = appType.Fees;
            clsDriver driver = clsDriver.GetDriverByID(localLicense.DriverID);
            application.ApplicantPersonID = driver.PersonID;
            if (application.Save())
            {
                clsInternationalLicense iLicense = new clsInternationalLicense();
                iLicense.ApplicationID = application.ApplicationID;
                iLicense.DriverID = localLicense.DriverID;
                iLicense.CreatedByUserID = clsGlobal.GlobalUser.UserID;
                iLicense.IssuedUsingLocalLicenseID = localLicense.LicenseID;
                iLicense.IssueDate = DateTime.Now;
                clsLicenseClass licenseClass = clsLicenseClass.GetLicenseClassByID(localLicense.LicenseClass);
                iLicense.ExpirationDate = iLicense.IssueDate.AddYears(licenseClass.DefaultValidityLength);
                iLicense.IsActive = true;
                if (iLicense.Save())
                {
                    MessageBox.Show("License Registered Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblInternationalLicenseApplicationID.Text = application.ApplicationID.ToString();
                    lblInternationalLicenseID.Text = iLicense.InternationalLicenseID.ToString();
                    lblApplicationDate.Text = application.ApplicationDate.ToShortDateString();
                    lblLocalLicenseID.Text = _LicenseID.ToString();
                    lblIssueDate.Text = iLicense.IssueDate.ToShortDateString();
                    lblExpirationDate.Text = iLicense.ExpirationDate.ToShortDateString();
                    lblFees.Text = application.PaidFees.ToString();
                    lblCreatedBy.Text = iLicense.CreatedByUserID.ToString();

                }
                else
                    MessageBox.Show("Error Registering New I.License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Application Not Saved.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnIssueLicense.Enabled = false;
            llblShowLicenseInfo.Enabled = true;
        }
    }
}
