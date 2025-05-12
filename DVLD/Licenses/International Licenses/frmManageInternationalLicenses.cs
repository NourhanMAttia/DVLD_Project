using DVLD.Licenses.Local_Licenses;
using DVLD.People;
using DVLD_B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.International_Licenses
{
    public partial class frmManageInternationalLicenses : Form
    {
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
        }
        private DataTable _dtAllInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
        private void _RefreshList()
        {
            _dtAllInternationalLicenses = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenses.DataSource = _dtAllInternationalLicenses;
            lblRecordsCount.Text = _dtAllInternationalLicenses.Rows.Count.ToString();
        }
        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            _RefreshList();
            txtFilterValue.Visible = false;
            cbFilter.SelectedIndex = 0;
            cbIsActive.Visible = false;

        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
            {
                _RefreshList();
                cbIsActive.Visible = false;
                txtFilterValue.Visible = false;
                return;
            }
            if(cbFilter.SelectedItem.ToString() == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                return;
            }
            cbIsActive.Visible = false;
            txtFilterValue.Visible = true;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtAllInternationalLicenses.DefaultView.RowFilter = $"IsActive={cbIsActive.SelectedIndex}";
            lblRecordsCount.Text = _dtAllInternationalLicenses.DefaultView.Count.ToString();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterValue.Text == "")
            {
                _RefreshList();
                return;
            }
            string column = "";
            switch (cbFilter.SelectedItem.ToString())
            {
                case "International License ID":
                    {
                        column = "InternationalLicenseID";
                        break;
                    }
                case "Local ID":
                    {
                        column = "IssuedUsingLocalLicenseID";
                        break;
                    }
                case "Driver ID":
                    {
                        column = "DriverID";
                        break;
                    }
            }
            _dtAllInternationalLicenses.DefaultView.RowFilter = $"{column} = {txtFilterValue.Text}";
            lblRecordsCount.Text = _dtAllInternationalLicenses.DefaultView.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsDriver driver = clsDriver.GetDriverByID((int)dgvInternationalLicenses.CurrentRow.Cells[2].Value);
            frmShowPersonInfo frm = new frmShowPersonInfo(driver.PersonID);
            frm.ShowDialog();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(-1, (int)dgvInternationalLicenses.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = (int)dgvInternationalLicenses.CurrentRow.Cells[2].Value;
            frmLicenseHistory frm = new frmLicenseHistory(driverID, -1);
            frm.ShowDialog();
        }
    }
}
