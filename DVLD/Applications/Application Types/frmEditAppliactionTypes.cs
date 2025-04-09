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

namespace DVLD.Applications.Application_Types
{
    public partial class frmEditAppliactionTypes : Form
    {
        private int _ApplicationTypeID = -1;
        private clsApplicationTypes _obj;
        private ErrorProvider ep = new ErrorProvider();
        public frmEditAppliactionTypes(int ApplicationTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicationTypeID;
        }
        private void frmEditAppliactionTypes_Load(object sender, EventArgs e)
        {
            _obj = clsApplicationTypes.Find(_ApplicationTypeID);
            if(_obj == null)
            {
                MessageBox.Show("Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            lblApplicationTypeID.Text = _ApplicationTypeID.ToString();
            txtName.Text = _obj.Name;
            txtFees.Text = _obj.Fees.ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Empty Fields Are Required.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _obj.Name = txtName.Text.Trim();
            _obj.Fees = Convert.ToDecimal(txtFees.Text.Trim());
            if (_obj.UpdateApplicationTypes())
                MessageBox.Show("Saved Info Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed To Save Info.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if(txtName.Text.Trim() == "")
            {
                ep.SetError(txtName, "This Field Is Required!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtName, "");
                e.Cancel = false;
            }
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (txtFees.Text.Trim() == "")
            {
                ep.SetError(txtFees, "This Field Is Required!");
                e.Cancel = true;
            }
            else
            {
                ep.SetError(txtFees, "");
                e.Cancel = false;
            }
        }
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
