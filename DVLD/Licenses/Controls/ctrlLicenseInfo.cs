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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlLicenseInfo : UserControl
    {
        public ctrlLicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadInfo(int LicenseID, bool isLocalLicense = true)
        {
            if (isLocalLicense)
            {
                clsLicense license = clsLicense.GetLicenseInfoByID(LicenseID);
                if (license == null)
                {
                    MessageBox.Show("License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsLicenseClass licenseClass = clsLicenseClass.GetLicenseClassByID(license.LicenseClass);
                lblClass.Text = licenseClass.ClassName;
                lblLicenseID.Text = license.LicenseID.ToString();
                lblIssueDate.Text = license.IssueDate.ToShortDateString();
                switch (license.IssueReason)
                {
                    case 1:
                        {
                            lblIssueReason.Text = "First Time";
                            break;
                        }
                    case 2:
                        {
                            lblIssueReason.Text = "Renew";
                            break;
                        }
                    case 3:
                        {
                            lblIssueReason.Text = "Replacement For Damage";
                            break;
                        }
                    case 4:
                        {
                            lblIssueReason.Text = "Replacement For Lost";
                            break;
                        }
                }
                lblNotes.Text = license.Notes == "" ? "None" : license.Notes;
                lblIsActive.Text = license.IsActive ? "YES" : "NO";
                lblDriverID.Text = license.DriverID.ToString();
                lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();
                lblIsDetained.Text = (clsDetainedLicense.IsLicenseDetained(license.LicenseID)) ? "YES" : "NO";
                clsDriver driver = clsDriver.GetDriverByID(license.DriverID);
                clsPerson person = clsPerson.Find(driver.PersonID);
                lblName.Text = person.FullName;
                lblNationalNo.Text = person.NationalNo;
                lblGender.Text = (person.Gender == 0) ? "Male" : "Female";
                lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                if (person.ImagePath == "")
                    pbPersonImage.Image = person.Gender == 0 ? Properties.Resources.male : Properties.Resources.female;
                else
                    pbPersonImage.ImageLocation = person.ImagePath;
            }
            else
            {
                label1.Visible = false;
                label13.Visible = false;
                label15.Visible = false;
                lblClass.Visible = false;
                lblIssueReason.Visible = false;
                lblNotes.Visible = false;
                label25.Visible = false;
                lblIsDetained.Visible = false;
                clsInternationalLicense iLicense = clsInternationalLicense.GetInternationalLicenseInfo(LicenseID);
                if(iLicense == null)
                {
                    MessageBox.Show("International License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsDriver driver = clsDriver.GetDriverByID(iLicense.DriverID);
                if (driver == null)
                {
                    MessageBox.Show("Driver Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsPerson person = clsPerson.Find(driver.PersonID);
                if (person == null)
                {
                    MessageBox.Show("Person Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblName.Text = person.FullName;
                lblLicenseID.Text = iLicense.InternationalLicenseID.ToString();
                lblNationalNo.Text = person.NationalNo;
                lblGender.Text = (person.Gender == 0) ? "Male" : "Female";
                lblIssueDate.Text = iLicense.IssueDate.ToShortDateString();
                lblIsActive.Text = iLicense.IsActive ? "YES" : "NO";
                lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                lblDriverID.Text = iLicense.DriverID.ToString();
                lblExpirationDate.Text = iLicense.ExpirationDate.ToShortDateString();
                if (person.ImagePath == "")
                    pbPersonImage.Image = person.Gender == 0 ? Properties.Resources.male : Properties.Resources.female;
                else
                    pbPersonImage.ImageLocation = person.ImagePath;
            }
        }
    }
}
