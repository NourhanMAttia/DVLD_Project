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
    public partial class frmLicenseHistory : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmLicenseHistory(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
            if(localApp == null)
            {
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlPersonCardInfoWithFilter1.LoadPersonInfo(localApp.ApplicantPersonID);
            ctrlPersonCardInfoWithFilter1.EnableFilter = false;

            clsDriver driver = clsDriver.GetDriverByPersonID(localApp.ApplicantPersonID);
            if (driver == null)
            {
                MessageBox.Show("Driver Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            DataTable dtLocalLicensesPerDriver = clsLicense.GetDriverLicenses(driver.DriverID);
            dgvLocalLicenses.DataSource = dtLocalLicensesPerDriver;
            lblLocalRecordsCount.Text = dtLocalLicensesPerDriver.Rows.Count.ToString();
            // international
        }
    }
}
