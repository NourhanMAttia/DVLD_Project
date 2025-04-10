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

namespace DVLD.Tests.Test_Types
{
    public partial class frmEditTestTypes : Form
    {
        private int _TestTypeID = -1;
        private clsTestType _TestTypeInfo;
        private ErrorProvider ep = new ErrorProvider();
        public frmEditTestTypes(int TestTypeID)
        {
            InitializeComponent();
            _TestTypeID = TestTypeID;
        }
        private void frmEditTestTypes_Load(object sender, EventArgs e)
        {
            _TestTypeInfo = clsTestType.GetTestTypeByID(_TestTypeID);
            if(_TestTypeInfo != null)
            {
                lblTestTypeID.Text = _TestTypeInfo.ID.ToString();
                txtTitle.Text = _TestTypeInfo.Name;
                txtDescription.Text = _TestTypeInfo.Description;
                txtFees.Text = _TestTypeInfo.Fees.ToString();
                return;
            }
            MessageBox.Show("Test Type Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Required Fields Are Empty.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _TestTypeInfo.Name = txtTitle.Text;
            _TestTypeInfo.Description = txtDescription.Text;
            _TestTypeInfo.Fees = Convert.ToSingle(txtFees.Text);
            if (_TestTypeInfo.UpdateTestType())
                MessageBox.Show("Changes Saved Successfuly.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed Saving Changes.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void _EmptyTextBoxValidation(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                ep.SetError(tb, "This Filed Is Required!");
                e.Cancel = true;
                return;
            }
            ep.SetError(tb, "");
            e.Cancel = false;
        }
        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                ep.SetError(txtFees, "This Filed Is Required!");
                e.Cancel = true;
                return;
            }
            if (!clsValidation.IsNumber(txtFees.Text))
            {
                ep.SetError(txtFees, "This Filed Should Be A Number!");
                e.Cancel = true;
                return;
            }
            ep.SetError(txtFees, "");
            e.Cancel = false;
        }
    }
}
