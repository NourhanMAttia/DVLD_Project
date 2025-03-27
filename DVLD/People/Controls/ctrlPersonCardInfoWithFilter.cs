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
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
                handler(PersonID); 
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
                OnPersonSelected?.Invoke(ctrlPersonCardInfo1.SelectedPersonInfo.PersonID);
            }    
            else if (cbFilterBy.Text == "Person ID")
            {
                if (int.TryParse(txtFilterValue.Text, out int PersonID))
                {
                    ctrlPersonCardInfo1.LoadPersonInfo(PersonID);
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
    }
}
