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
    public partial class frmShowLicenseInfo : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmShowLicenseInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if(localApp == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            clsLicense license = clsLicense.GetLicenseInfoByApplicationID(localApp.ApplicationID);
            if (license == null)
            {
                MessageBox.Show("License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlLicenseInfo1.LoadInfo(license.LicenseID);
        }
    }
}
