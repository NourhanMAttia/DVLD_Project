using DVLD.Global_Classes;
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

namespace DVLD.Login
{
    public partial class frmLogin : Form
    {// two features to add later : permissions for users and password encryption
        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            string _username = "", _password = "";
            if (clsGlobal.GetStoredCredentials(ref _username, ref _password))
            {
                txtUsername.Text = _username;
                txtPassword.Text = _password;
                chkRememberMe.Checked = true;
            }
            else
            {
                txtUsername.Text = _username;
                txtPassword.Text = _password;
                chkRememberMe.Checked = false;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // isRememberMe checked(if yes fill info), check username, check password, check isActive===> login or not
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Required Fields Are Empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsGlobal.GlobalUser = clsUser.FindByUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if(clsGlobal.GlobalUser == null)
            {
                MessageBox.Show("Wrong Credentials. Try Again.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }
            if (!clsGlobal.GlobalUser.isActive)
            {
                MessageBox.Show("Your User Account Is NOT Active. Contact Your Admin For More Info.", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (chkRememberMe.Checked)
                clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            else
                clsGlobal.RememberUsernameAndPassword("", "");

            this.Hide();
            frmMain frm = new frmMain(this);
            frm.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
