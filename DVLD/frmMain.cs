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
using DVLD.Login;
using DVLD.Users;
using DVLD_B;

namespace DVLD
{
    public partial class frmMain: Form
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }
        private void tsmMangePeople_Click(object sender, EventArgs e)
        {
                frmListPeople ManagePeopleForm = new frmListPeople();
                ManagePeopleForm.Show();
                ManagePeopleForm.MdiParent = this;
        }

        private void tsmUsers_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.Show();
            frm.MdiParent = this;
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frm = new frmShowUserDetails(clsGlobal.GlobalUser.UserID);
            frm.ShowDialog();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.GlobalUser.UserID);
            frm.ShowDialog();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.GlobalUser = null;
            _frmLogin.Show();
            this.Close();
        }
    }
}
