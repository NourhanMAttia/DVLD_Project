using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Login;
using DVLD.Users;
using DVLD_B;

namespace DVLD
{
    public partial class frmMain: Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void tsmMangePeople_Click(object sender, EventArgs e)
        {
                frmListPeople ManagePeopleForm = new frmListPeople();
                ManagePeopleForm.Show();
                ManagePeopleForm.MdiParent = this;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.Show();
            frm.MdiParent = this;
        }

        private void tsmUsers_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.Show();
            frm.MdiParent = this;
        }
    }
}
