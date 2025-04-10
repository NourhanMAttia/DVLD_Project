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
    public partial class frmListTestTypes : Form
    {
        public frmListTestTypes()
        {
            InitializeComponent();
        }
        private DataTable _dtAllTestTypes = clsTestType.GetAllTestTypes();
        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestTypes = clsTestType.GetAllTestTypes();
            dgvTestTypesList.DataSource = _dtAllTestTypes;
            dgvTestTypesList.Columns["TestTypeTitle"].Width = 200;
            dgvTestTypesList.Columns["TestTypeDescription"].Width = 250;
            lblRecordsCount.Text = dgvTestTypesList.Rows.Count.ToString();
        }
        private void tsmEditTestTypes_Click(object sender, EventArgs e)
        {
            frmEditTestTypes frm = new frmEditTestTypes((int)dgvTestTypesList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestTypes_Load(null, null);
        }
    }
}
