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
            btnDetain.Enabled = true;
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            clsLicense license = clsLicense.GetLicenseInfoByID(_LicenseID);
            //if()
            btnDetain.Enabled = false;
        }
    }
}
