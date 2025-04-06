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
        private clsPerson _Person;
        private ErrorProvider ep = new ErrorProvider();
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
        private void _LoadUserInfo()
        {
            _User = clsUser.FindByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show($"User With ID [{_UserID}] Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _User.Person = clsPerson.Find(_User.PersonID);
            _Person = _User.Person;
            ctrlPersonCardInfoWithFilter1.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.isActive;
        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
                _LoadUserInfo();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tcUser.SelectedTab = tpLoginInfo;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // check if person already has user account, password hashing, 
            if (_Person == null)
            {
                MessageBox.Show("You Must Link User To A Person.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(_Mode == enMode.AddNew && clsUser.HasUser(_Person.PersonID))
            {
                MessageBox.Show("This Person Already Has A User Account.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _User.Username = txtUserName.Text;
            _User.Password = txtPassword.Text;
            _User.isActive = chkIsActive.Checked;
            _User.Person = clsPerson.Find(_User.PersonID);
            if (_User.Save())
            {
                lblTitle.Text = "Edit User Info";
                _Mode = enMode.Update;
                MessageBox.Show($"User With ID [{_User.UserID}] Saved Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show($"Error Saving User Info.", "Error!",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
                ep.SetError(txtPassword, "Password Doesn't Match!");
            else
                ep.SetError(txtPassword, "");
        }
        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
                ep.SetError(txtConfirmPassword, "Password Doesn't Match!");
            else
                ep.SetError(txtConfirmPassword, "");
        }
    }
}
