using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Applications.Application_Types;
using DVLD.Applications.Local_Driving_Licenses;
using DVLD.Drivers;
using DVLD.Global_Classes;
using DVLD.Login;
using DVLD.Tests.Test_Types;
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

        private void tsmManageApplicationTypes_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _frmLogin.Close();
        }

        private void tsmManageTestTypes_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicense frm = new frmAddUpdateLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void localDriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalLicenseApplications frm = new frmManageLocalLicenseApplications();
            frm.ShowDialog();
        }

        private void tsmDrivers_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }
    }
}
