using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_B;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardInfoWithFilter: UserControl
    {
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }
        private bool _EnableFilter = true;
        public bool EnableFilter
        {
            get { return _EnableFilter; }
            set
            {
                _EnableFilter = value;
                gbFilter.Enabled = _EnableFilter;
            }
        }
        private int _PersonID = -1;
        public int PersonID
        {
            get { return ctrlPersonCardInfo1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCardInfo1.SelectedPersonInfo; }
        }
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
                handler(PersonID); 
        }
        private void _FindNow() 
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    {
                        ctrlPersonCardInfo1.LoadPersonInfo(int.Parse(txtFilterValue.Text));
                        break;
                    }
                case "National No":
                    {
                        ctrlPersonCardInfo1.LoadPersonInfo(txtFilterValue.Text);
                        break;
                    }
                default:
                    break;
            }
            OnPersonSelected?.Invoke(ctrlPersonCardInfo1.PersonID);
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            _FindNow();
        }
        public void FilterFocus()
        {
            gbFilter.Focus();
        }
        public ctrlPersonCardInfoWithFilter()
        {
            InitializeComponent();
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if((cbFilterBy.Text != "National No." && cbFilterBy.Text != "Person ID") || txtFilterValue.Text == "")
            {
                MessageBox.Show("Invalid Filter Or Value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbFilterBy.Text == "National No.")
            {
                ctrlPersonCardInfo1.LoadPersonInfo(txtFilterValue.Text);
                if(ctrlPersonCardInfo1.SelectedPersonInfo != null)
                    OnPersonSelected?.Invoke(ctrlPersonCardInfo1.SelectedPersonInfo.PersonID);
            }    
            else if (cbFilterBy.Text == "Person ID")
            {
                if (int.TryParse(txtFilterValue.Text, out int PersonID))
                {
                    ctrlPersonCardInfo1.LoadPersonInfo(PersonID);
                    if(ctrlPersonCardInfo1.SelectedPersonInfo != null)
                        OnPersonSelected?.Invoke(ctrlPersonCardInfo1.SelectedPersonInfo.PersonID);
                }
                else
                    MessageBox.Show("Invalid Person ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.OnDataBack += _DataBackHandler;
            frm.ShowDialog();
        }
        private void _DataBackHandler(object sender, int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCardInfo1.LoadPersonInfo(PersonID);
        }
        private void ctrlPersonCardInfoWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
                MessageBox.Show("This Field Is Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                btnFindPerson.PerformClick();
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
