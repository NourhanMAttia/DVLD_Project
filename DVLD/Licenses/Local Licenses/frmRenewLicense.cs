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
    public partial class frmRenewLicense : Form
    {
        public frmRenewLicense()
        {
            InitializeComponent();
        }
        private int _OldLicenseID = -1;
        private void frmRenewLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelectedHandler;
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplicationDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.GlobalUser.UserID.ToString();
            llblShowNewLicenseInfo.Enabled = false;
            llblShowLicenseHistory.Enabled = false;
            btnRenew.Enabled = false;
        }
        private void OnLicenseSelectedHandler(int LicenseID)
        {
            _OldLicenseID = LicenseID;
            clsLicense localLicense = clsLicense.GetLicenseInfoByID(LicenseID);
            if(localLicense == null)
            {
                MessageBox.Show("License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(localLicense.ExpirationDate < DateTime.Now)
            {
                btnRenew.Enabled = true;
                clsApplicationType appType = clsApplicationType.Find((int)clsApplicationType.enApplicationType.RenewLicense);
                lblApplicationFees.Text = appType.Fees.ToString();
                lblLicenseFees.Text = localLicense.PaidFees.ToString();
                lblTotalFees.Text = (localLicense.PaidFees + appType.Fees).ToString();
                lblOldLicenseID.Text = LicenseID.ToString();
                llblShowLicenseHistory.Enabled = true;
            }
            else
                MessageBox.Show("License Is Still Active. Can't Renew.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicense oldLicense = clsLicense.GetLicenseInfoByID(_OldLicenseID);
            clsDriver driver = clsDriver.GetDriverByID(oldLicense.DriverID);
            clsApplication app = new clsApplication();
            app.ApplicationDate = DateTime.Now;
            app.ApplicantPersonID = driver.PersonID;
            app.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            app.ApplicationTypeID = (int)clsApplicationType.enApplicationType.RenewLicense;
            app.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            app.LastStatusDate = DateTime.Now;
            clsApplicationType appType = clsApplicationType.Find(app.ApplicationTypeID);
            app.PaidFees = appType.Fees;
            if (app.Save())
            {
                clsLicense newLicense = new clsLicense();
                newLicense.ApplicationID = app.ApplicationID;
                newLicense.CreatedByUserID = clsGlobal.GlobalUser.UserID;
                newLicense.DriverID = driver.DriverID;
                newLicense.IssueDate = DateTime.Now;
                newLicense.ExpirationDate = newLicense.IssueDate.AddYears(clsLicenseClass.GetDefaultValidityLengthPerClass(oldLicense.LicenseClass));
                newLicense.IsActive = true;
                newLicense.IssueReason = (int)clsLocalDrivingLicenseApplication.enApplicationType.RenewDrivingLicense;
                newLicense.LicenseClass = oldLicense.LicenseClass;
                newLicense.Notes = txtNotes.Text;
                newLicense.PaidFees = oldLicense.PaidFees;
                oldLicense.DeactivateLicense();
                if (newLicense.Save())
                {
                    MessageBox.Show("Saved Application Data.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblRenewAppID.Text = app.ApplicationID.ToString();
                    lblRenewLicenseID.Text = newLicense.LicenseID.ToString();
                    lblExpirationDate.Text = newLicense.ExpirationDate.ToShortDateString();
                    llblShowNewLicenseInfo.Enabled = true;
                    btnRenew.Enabled = false;
                }
                else
                    MessageBox.Show("Failed To Save New License Data.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Failed To Save Application Data.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void llblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblRenewLicenseID.Text, out int NewLicenseID))
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(NewLicenseID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Error Loading.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void llblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                frmLicenseHistory frm = new frmLicenseHistory(_OldLicenseID);
                frm.ShowDialog();
        }
    }
}
