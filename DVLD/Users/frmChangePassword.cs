using DVLD.Global_Classes;
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
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private ErrorProvider ep = new ErrorProvider();
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Required Are Empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlUserCard1.SelectedUserInfo.Password = txtConfirmPassword.Text.Trim();
            if (ctrlUserCard1.SelectedUserInfo.Save())
                MessageBox.Show("Saved Password Info Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error Saving Password Info.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtCurrentPassword.Text.Trim() != ctrlUserCard1.SelectedUserInfo.Password)
            {
                ep.SetError(txtCurrentPassword, "Wrong Password!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtCurrentPassword, "");
                e.Cancel = false;
            }
        }
        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                ep.SetError(txtNewPassword, "This Field Is Required!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtNewPassword, "");
                e.Cancel = false;
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                ep.SetError(txtConfirmPassword, "Password Doesn't Match!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtConfirmPassword, "");
                e.Cancel = false;
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.UserID = _UserID;
            if(ctrlUserCard1.UserID != -1)
                ctrlUserCard1.LoadUserInfo();
        }
    }
}
