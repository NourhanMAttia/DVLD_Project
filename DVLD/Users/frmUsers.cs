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

namespace DVLD.Users
{
    public partial class frmUsers : Form
    {
        private static DataTable _dtAllUsers = clsUser.GetAllUsers();
        private DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable(true, "UserID", "PersonID", "FullName", "Username", "isActive");
        private void _Load()
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Visible = false;
            cbIsActiveOptions.Visible = false;
            _dtAllUsers = clsUser.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(true, "UserID", "PersonID", "FullName", "Username", "isActive");
            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
            dgvUsers.DataSource = _dtUsers;
            dgvUsers.Columns[2].Width = 250;
        }
        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            _dtUsers = _dtAllUsers.DefaultView.ToTable(true, "UserID", "PersonID", "FullName", "Username", "isActive");
            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
            dgvUsers.DataSource = _dtUsers;
            dgvUsers.Columns[2].Width = 250;
        }
        public frmUsers()
        {
            InitializeComponent();
            _Load();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.Show();
            _RefreshUsersList();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 0 = none
            if(cbFilterBy.SelectedIndex == 0)
            {
                txtFilterValue.Visible = false;
                cbIsActiveOptions.Visible = false;
                _RefreshUsersList();
                return;
            }
            // 5 = isActive
            if (cbFilterBy.SelectedIndex == 5)
            {
                txtFilterValue.Visible = false;
                cbIsActiveOptions.Visible = true;
                cbIsActiveOptions.SelectedIndex = 0;
                lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
                return;
            }
            txtFilterValue.Visible = true;
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
            cbIsActiveOptions.Visible = false;
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterValue.Text.Trim() == "") 
            {
                _RefreshUsersList();
                return;
            }
            string column = "";
            switch (cbFilterBy.Text)
            {
                case "User ID":
                    {
                        column = "UserID";
                        break;
                    }
                case "Person ID":
                    {
                        column = "PersonID";
                        break;
                    }
                case "User Name":
                    {
                        column = "Username";
                        break;
                    }
                case "Full Name":
                    {
                        column = "FullName";
                        break;
                    }
                default:
                    {
                        column = "";
                        break;
                    }
            }
            switch (column)
            {
                case "UserID":
                        _dtUsers.DefaultView.RowFilter = $"UserID={int.Parse(txtFilterValue.Text.Trim())}";
                        break;
                case "PersonID":
                        _dtUsers.DefaultView.RowFilter = $"PersonID={int.Parse(txtFilterValue.Text.Trim())}";
                        break;
                case "Username":
                        _dtUsers.DefaultView.RowFilter = $"Username LIKE '{txtFilterValue.Text}%'";
                        break;
                case "FullName":
                        _dtUsers.DefaultView.RowFilter = $"FullName LIKE '{txtFilterValue.Text}%'";
                        break;
            }
            dgvUsers.DataSource = _dtUsers;
            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
        }
        private void cbIsActiveOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            // all =0
            if (cbIsActiveOptions.SelectedIndex == 0)
                _dtUsers.DefaultView.RowFilter = "isActive=0 OR isActive=1";
            else
            {
                // yes=1, no =2 in cb index, while yes =1, no =0 in db
                int isActive = (cbIsActiveOptions.SelectedIndex == 1) ? 1 : 0;
                _dtUsers.DefaultView.RowFilter = $"isActive={isActive}";
            }
            dgvUsers.DataSource = _dtUsers;
            lblRecordsCount.Text = _dtUsers.DefaultView.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmShowUserDetails frm = new frmShowUserDetails(UserID);
            frm.Show();
        }
        private void tsmAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.Show();
            _RefreshUsersList();
        }
        private void tsmEditUserInfo_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            frmAddUpdateUser frm = new frmAddUpdateUser(UserID);
            frm.Show();
            _RefreshUsersList();
        }
        private void tsmDeleteUser_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;
            MessageBox.Show($"Are You Sure You Want To DELETE User With ID [{UserID}]?", "Confirm!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);           
            if(DialogResult == DialogResult.OK)
            {
                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show($"User With ID [{UserID}] Deleted Successfuly", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersList();
                }
                else
                    MessageBox.Show($"Failed To DELETE User With ID [{UserID}]", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Hasn't Been Implemented Yet.", "Coming Soon!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Hasn't Been Implemented Yet.", "Coming Soon!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
