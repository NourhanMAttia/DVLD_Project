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
    public partial class frmDetainLicense : Form
    {
        private int _LicenseID = -1;
        public frmDetainLicense()
        {
            InitializeComponent();
        }
        private void frmDetainLicense_Load(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            ctrlLicenseInfoWithFilter1.OnLicenseSelected += OnLicenseSelectedHandler;
            lblCreatedBy.Text = clsGlobal.GlobalUser.Username;
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblFineFees.Text = "50";
        }
        private void OnLicenseSelectedHandler(int LicenseID)
        {
            _LicenseID = LicenseID;
            lblLicenseID.Text = _LicenseID.ToString();
            clsLicense license = clsLicense.GetLicenseInfoByID(_LicenseID);
            if (!license.IsActive)
            {
                MessageBox.Show("This License Is Not Active.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (clsDetainedLicense.IsLicenseDetained(license.LicenseID))
            {
                MessageBox.Show("This License Is Already Detained.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnDetain.Enabled = true;
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.GetLicenseInfoByID(_LicenseID);
            clsDetainedLicense detainedLicense = new clsDetainedLicense();
            detainedLicense.LicenseID = license.LicenseID;
            detainedLicense.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = 50;
            detainedLicense.IsReleased = false;
            detainedLicense.ReleaseApplicationID = -1;
            detainedLicense.ReleaseDate = null;
            detainedLicense.ReleasedByUserID = -1;
            if (detainedLicense.Save())
            {
                MessageBox.Show("Detained License Done.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDetainID.Text = detainedLicense.DetainID.ToString();
            }
            else
                MessageBox.Show("Failed To Detain License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnDetain.Enabled = false;
        }
    }
}
