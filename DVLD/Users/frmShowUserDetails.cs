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
    public partial class frmShowUserDetails : Form
    {
        private int _UserID = -1;
        public frmShowUserDetails(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ctrlUserCard1.UserID = _UserID;
            if(ctrlUserCard1.UserID != -1)
                ctrlUserCard1.LoadUserInfo();
        }
    }
}
