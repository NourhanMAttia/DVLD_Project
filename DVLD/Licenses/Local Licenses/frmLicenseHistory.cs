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
        private int _DriverID = -1;
        public frmLicenseHistory(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        public frmLicenseHistory(int DriverID, int LocalDrivingLicenseApplicationID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _DriverID = DriverID;
        }
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if(_DriverID != -1)
            {
                clsDriver driver = clsDriver.GetDriverByID(_DriverID);
                if (driver == null)
                {
                    MessageBox.Show("Driver Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                ctrlPersonCardInfoWithFilter1.LoadPersonInfo(driver.PersonID);
                ctrlPersonCardInfoWithFilter1.EnableFilter = false;

                DataTable dtLocalLicensesPerDriver = clsLicense.GetDriverLicenses(driver.DriverID);
                dgvLocalLicenses.DataSource = dtLocalLicensesPerDriver;
                lblLocalRecordsCount.Text = dtLocalLicensesPerDriver.Rows.Count.ToString();

                DataTable dtInternationalLicensesPerDriver = clsInternationalLicense.GetInternationalLicensesPerDriver(driver.DriverID);
                dgvInternationalLicenses.DataSource = dtInternationalLicensesPerDriver;
                lblInternationalRecordsCount.Text = dtInternationalLicensesPerDriver.Rows.Count.ToString();
                return;
            }
            else
            {
                clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(_LocalDrivingLicenseApplicationID);
                if (localApp == null)
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

                DataTable dtInternationalLicensesPerDriver = clsInternationalLicense.GetInternationalLicensesPerDriver(driver.DriverID);
                dgvInternationalLicenses.DataSource = dtInternationalLicensesPerDriver;
                lblInternationalRecordsCount.Text = dtInternationalLicensesPerDriver.Rows.Count.ToString();
            }
        }
    }
}
