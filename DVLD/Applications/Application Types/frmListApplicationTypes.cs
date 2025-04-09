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
    public partial class frmListApplicationTypes : Form
    {
        private DataTable _dtApplicationTypesList;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }
        private void _RefreshList()
        {
            _dtApplicationTypesList = clsApplicationTypes.GetApplicationTypesList();
            dgvApplicationTypes.DataSource = _dtApplicationTypesList;
            dgvApplicationTypes.Columns["ApplicationTypeTitle"].Width = 500;
            lblRecordsCount.Text = dgvApplicationTypes.Rows.Count.ToString();
        }
        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _RefreshList();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmEditApplicationTypes_Click(object sender, EventArgs e)
        {
            int ApplicationTypeID = Convert.ToInt32(dgvApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value);
            frmEditAppliactionTypes frm = new frmEditAppliactionTypes(ApplicationTypeID);
            frm.ShowDialog();
            _RefreshList();
        }
    }
}
