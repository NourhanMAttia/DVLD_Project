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
using DVLD.Global_Classes;
namespace DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _UserID = -1;
        private clsUser _User;
        private ErrorProvider ep = new ErrorProvider();
        private void _ResetDefaultValues()
        {
            if(_Mode == enMode.AddNew)
            {
                this.Text = "Add New User";
                lblTitle.Text = "Add New User";
                _EnableOrDisableLoginPage(false);
                _User = new clsUser();
                ctrlPersonCardInfoWithFilter1.FilterFocus();
            }
            else
            {
                this.Text = "Edit User Info";
                lblTitle.Text = "Edit User Info";
                _EnableOrDisableLoginPage(true);
                btnSave.Enabled = true;
            }
            lblUserID.Text = "???";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = false;
        }
        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }
        private void _EnableOrDisableLoginPage(bool enable)
        {
            lblUserID.Enabled = enable;
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;
            txtConfirmPassword.Enabled = enable;
            chkIsActive.Enabled = enable;
        }
        private void _LoadUserInfo()
        {
            _User = clsUser.FindByUserID(_UserID);
            ctrlPersonCardInfoWithFilter1.EnableFilter = false;
            if (_User == null)
            {
                MessageBox.Show($"User With ID [{_UserID}] Not Found", "User Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            } 
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.isActive;
            ctrlPersonCardInfoWithFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();
            if (_Mode == enMode.Update)
                _LoadUserInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                _EnableOrDisableLoginPage(true);
                tcUser.SelectedTab = tpLoginInfo;
            }
            if(ctrlPersonCardInfoWithFilter1.SelectedPersonInfo.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(_User.PersonID))
                {
                    MessageBox.Show("This Person Already Has A User Account.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctrlPersonCardInfoWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    _EnableOrDisableLoginPage(true);
                    tcUser.SelectedTab = tpLoginInfo;
                }
            }
            else
            {
                MessageBox.Show("Please Select A Person.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlPersonCardInfoWithFilter1.FilterFocus();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Empty Fields Are Required!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _User.PersonID = ctrlPersonCardInfoWithFilter1.SelectedPersonInfo.PersonID;
            _User.Username = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.isActive = chkIsActive.Checked;
            if (_User.Save())
            {
                MessageBox.Show("Saved User Info Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblUserID.Text = _User.UserID.ToString();
                lblTitle.Text = "Edit User Info";
                this.Text = "Edit User Info";
                _Mode = enMode.Update;
            }
            else
                MessageBox.Show("Failed At Saving User Info.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                ep.SetError(txtPassword, "This Field Is Required!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtPassword, "");
                e.Cancel = false;
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                ep.SetError(txtConfirmPassword, "Password Doesn't Match");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtConfirmPassword, "");
                e.Cancel = false;
            }
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                ep.SetError(txtUserName, "This Field Is Required!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtUserName, "");
                e.Cancel = false;
            }

            if(_Mode == enMode.AddNew)
            {
                if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                {
                    ep.SetError(txtUserName, "This Username Is Already Used By Someone Else");
                    e.Cancel = true;
                }
                else
                {
                    ep.SetError(txtUserName, "");
                    e.Cancel = false;
                }
            }
            else
            {
                if(txtUserName.Text.Trim() != _User.Username)
                {
                    if (clsUser.IsUserExist(txtUserName.Text.Trim()))
                    {
                        ep.SetError(txtUserName, "This Username Is Already Used By Someone Else");
                        e.Cancel = true;
                    }
                    else
                    {
                        ep.SetError(txtUserName, "");
                        e.Cancel = false;
                    }
                }
            }
        }
        private void tcUser_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(tcUser.SelectedTab == tpLoginInfo && ctrlPersonCardInfoWithFilter1.SelectedPersonInfo.PersonID == -1)
            {
                tcUser.SelectedTab = tpPersonalInfo;
                MessageBox.Show("Please Select A Person First.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardInfoWithFilter1.FilterFocus();
        }
    }
}
