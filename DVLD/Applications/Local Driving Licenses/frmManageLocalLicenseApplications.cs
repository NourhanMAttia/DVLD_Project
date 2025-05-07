using DVLD.Licenses.Local_Licenses;
using DVLD.Tests;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.Applications.Local_Driving_Licenses
{
    public partial class frmManageLocalLicenseApplications : Form
    {
        public frmManageLocalLicenseApplications()
        {
            InitializeComponent();
        }
        private DataTable _dtAllLocalApplications;
        private void _RefreshList()
        {
            _dtAllLocalApplications = clsLocalDrivingLicenseApplication.GetAllLocalLicenseApplications();
            dgvLocalLicensesApplications.DataSource = _dtAllLocalApplications;
            lblRecordsCount.Text = dgvLocalLicensesApplications.Rows.Count.ToString();
            if (dgvLocalLicensesApplications.Rows.Count > 0)
            {

                dgvLocalLicensesApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalLicensesApplications.Columns[0].Width = 70;

                dgvLocalLicensesApplications.Columns[1].HeaderText = "Driving Class";
                dgvLocalLicensesApplications.Columns[1].Width = 190;

                dgvLocalLicensesApplications.Columns[2].HeaderText = "National No.";
                dgvLocalLicensesApplications.Columns[2].Width = 70;

                dgvLocalLicensesApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalLicensesApplications.Columns[3].Width = 220;

                dgvLocalLicensesApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalLicensesApplications.Columns[4].Width = 140;

                dgvLocalLicensesApplications.Columns[5].HeaderText = "Passed Tests";
                dgvLocalLicensesApplications.Columns[5].Width = 70;
            }
        }
        private void frmManageLocalLicenseApplications_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            _RefreshList();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 0)
            {
                _RefreshList();
                txtFilterValue.Visible = false;
                return;
            }
            txtFilterValue.Visible = true;
            txtFilterValue.Focus();
            txtFilterValue.Text = "";
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterValue.Text == "")
            {
                _RefreshList();
                return;
            }
            string column = "";
            switch (cbFilterBy.Text)
            {
                case "L.D.L AppID":
                    {
                        column = "LocalDrivingLicenseApplicationID";
                        break;
                    }
                case "National No.":
                    {
                        column = "NationalNo";
                        break;
                    }
                case "Full Name":
                    {
                        column = "FullName";
                        break;
                    }
                case "Status":
                    {
                        column = "Status";
                        break;
                    }
            }
            if(column == "LocalDrivingLicenseApplicationID")
                _dtAllLocalApplications.DefaultView.RowFilter = $"{column}={txtFilterValue.Text}";
            else
                _dtAllLocalApplications.DefaultView.RowFilter = $"{column} LIKE '{txtFilterValue.Text}%'";
            lblRecordsCount.Text = _dtAllLocalApplications.DefaultView.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 1 && !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnAddNewLocalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicense frm = new frmAddUpdateLocalDrivingLicense();
            frm.ShowDialog();
            _RefreshList();
        }
        
        private void tsmShowApplicationDetails_Click(object sender, EventArgs e)
        {
            int localAppID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmShowApplicationDetails frm = new frmShowApplicationDetails(localAppID);
            frm.ShowDialog();
        }

        private void tsmEditApplication_Click(object sender, EventArgs e)
        {
            int localAppID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmAddUpdateLocalDrivingLicense frm = new frmAddUpdateLocalDrivingLicense(localAppID);
            frm.ShowDialog();
            _RefreshList();
        }
        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {
            int localAppID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(localAppID);
            if(localApplication == null)
            {
                MessageBox.Show("Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            DialogResult res = MessageBox.Show("Are You Sure You Want To Delete This Application?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(res == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.DeleteLocalLicenseApplication(localAppID))
                {
                    MessageBox.Show("Application Deleted Successfuly.", "Inform!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshList();
                }
                else
                    MessageBox.Show("Failed To Delete Application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsmCancelApplication_Click(object sender, EventArgs e)
        {
            int localAppID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication localApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(localAppID);
            if (localApplication == null)
            {
                MessageBox.Show("Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            localApplication.ApplicationStatus = (clsApplication.enApplicationStatus)2;
            DialogResult res = MessageBox.Show("Are You Sure You Want To Cancel This Application?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                if (localApplication.UpdateStatus())
                {
                    MessageBox.Show("Application Cancelled.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshList();
                }
                else
                    MessageBox.Show("Error Cancelling Application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        private void tsmIssueLicenseFirstTime_Click(object sender, EventArgs e)
        {
            int localAppID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmIssueDrivingLicenseFirstTime frm = new frmIssueDrivingLicenseFirstTime(localAppID);
            frm.ShowDialog();
            _RefreshList();
        }
        private void tsmShowLicense_Click(object sender, EventArgs e)
        {
            int localAppID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmShowLicenseInfo frm = new frmShowLicenseInfo(localAppID);
            frm.ShowDialog();
        }
        private void tsmLicenseHistory_Click(object sender, EventArgs e)
        {
            //
        }

        private void tsmVisionTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmScheduleTestAppointments frm = new frmScheduleTestAppointments(LocalDrivingLicenseApplicationID, (clsTest.enTestType)1);
            frm.ShowDialog();
            _RefreshList();
        }
        private void tsmWrittenTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmScheduleTestAppointments frm = new frmScheduleTestAppointments(LocalDrivingLicenseApplicationID, (clsTest.enTestType)2);
            frm.ShowDialog();
            _RefreshList();
        }
        private void tsmStreetTest_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            frmScheduleTestAppointments frm = new frmScheduleTestAppointments(LocalDrivingLicenseApplicationID, (clsTest.enTestType)3);
            frm.ShowDialog();
            _RefreshList();
        }

        private void cmLocalLicensesApplications_Opening(object sender, CancelEventArgs e)
        {
            int appID = (int)dgvLocalLicensesApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingLicenseApplication application = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLocalApplicationID(appID);
            if(application == null)
            {
                MessageBox.Show("Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tsmShowApplicationDetails.Enabled = true;
            tsmEditApplication.Enabled = true;
            tsmDeleteApplication.Enabled = true;
            tsmCancelApplication.Enabled = true;
            tsmScheduleTest.Enabled = true;
            tsmIssueLicenseFirstTime.Enabled = true;
            tsmShowLicense.Enabled = true;
            tsmLicenseHistory.Enabled = true;
            if(application.ApplicationStatus == (clsApplication.enApplicationStatus)1)
            {
                tsmIssueLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;
                byte passedTestCount = clsTest.PassedTestCount(appID);
                switch (passedTestCount)
                {
                    case 0:
                        {
                            tsmVisionTest.Enabled = true;
                            tsmWrittenTest.Enabled = false;
                            tsmStreetTest.Enabled = false;
                            break;
                        }
                    case 1:
                        {
                            tsmVisionTest.Enabled = false;
                            tsmWrittenTest.Enabled = true;
                            tsmStreetTest.Enabled = false;
                            break;
                        }
                    case 2:
                        {
                            tsmVisionTest.Enabled = false;
                            tsmWrittenTest.Enabled = false;
                            tsmStreetTest.Enabled = true;
                            break;
                        }
                    case 3:
                        {
                            tsmScheduleTest.Enabled = false;
                            break;
                        }
                }
                return;
            }
            if(application.ApplicationStatus == (clsApplication.enApplicationStatus)2)
            {
                tsmEditApplication.Enabled = false;
                tsmDeleteApplication.Enabled = false;
                tsmCancelApplication.Enabled = false;
                tsmScheduleTest.Enabled = false;
                tsmIssueLicenseFirstTime.Enabled = false;
                tsmShowLicense.Enabled = false;
                return;
            }
            if (application.ApplicationStatus == (clsApplication.enApplicationStatus)3)
            {
                tsmEditApplication.Enabled = false;
                tsmDeleteApplication.Enabled = false;
                tsmCancelApplication.Enabled = false;
                tsmScheduleTest.Enabled = false;
            }
            if (application.HasPassedAllTests())
            {
                tsmEditApplication.Enabled = false;
                tsmDeleteApplication.Enabled = false;
                tsmCancelApplication.Enabled = false;
                tsmScheduleTest.Enabled = false;
                clsLicense license = clsLicense.GetLicenseInfoByApplicationID(application.ApplicationID);
                if(license == null)
                {
                    tsmIssueLicenseFirstTime.Enabled = true;
                    tsmShowLicense.Enabled = false;
                }
                else
                {
                    tsmIssueLicenseFirstTime.Enabled = false;
                    tsmShowLicense.Enabled = true;
                }
            }
        }
    }
}
