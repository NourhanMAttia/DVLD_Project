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
    public partial class ctrlUserCard : UserControl
    {
        private int _UserID = -1;
        private clsUser _User;
        public int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        public clsUser SelectedUserInfo
        {
            get
            {
                return _User;
            }
        }
        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void LoadUserInfo()
        {
            _User = clsUser.FindByUserID(_UserID);
            if(_User == null)
            {
                MessageBox.Show($"User With ID [{_UserID}] Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }          
            ctrlPersonCardInfo2.LoadPersonInfo(_User.PersonID);
            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.Username;
            lblIsActive.Text = (_User.isActive) ? "YES" : "NO";
        }
    }
}
