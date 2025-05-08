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
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int licenseID = int.Parse(txtSearchValue.Text);
            clsLicense license = clsLicense.GetLicenseInfoByID(licenseID);
            if (license != null)
            {
                ctrlLicenseInfo1.LoadInfo(license.LicenseID);
            }
            else
                MessageBox.Show("License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }
        private void txtSearchValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
