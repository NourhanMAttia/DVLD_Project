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
        ///
        private void tsmShowApplicationDetails_Click(object sender, EventArgs e)
        {

        }

        private void tsmEditApplication_Click(object sender, EventArgs e)
        {

        }
        private void tsmDeleteApplication_Click(object sender, EventArgs e)
        {

        }
        private void tsmCancelApplication_Click(object sender, EventArgs e)
        {

        }

        private void tsmIssueLicenseFirstTime_Click(object sender, EventArgs e)
        {

        }
        private void tsmShowLicense_Click(object sender, EventArgs e)
        {

        }
        private void tsmLicenseHistory_Click(object sender, EventArgs e)
        {

        }

        private void tsmVisionTest_Click(object sender, EventArgs e)
        {

        }
        private void tsmWrittenTest_Click(object sender, EventArgs e)
        {

        }
        private void tsmStreetTest_Click(object sender, EventArgs e)
        {

        }
    }
}
