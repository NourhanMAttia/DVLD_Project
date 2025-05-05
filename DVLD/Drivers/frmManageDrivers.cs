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

namespace DVLD.Drivers
{
    public partial class frmManageDrivers : Form
    {
        public frmManageDrivers()
        {
            InitializeComponent();
        }
        private DataTable _dtAllDrivers;
        private void _RefreshDriversList()
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = _dtAllDrivers;
            lblRecordsCount.Text = _dtAllDrivers.Rows.Count.ToString();
        }
        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            txtFilterValue.Visible = false;
            cbFilter.SelectedIndex = 0;
            _RefreshDriversList();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0) 
            {
                _RefreshDriversList();
                txtFilterValue.Visible = false;
                return;
            } 
            txtFilterValue.Visible = true;
            txtFilterValue.Enabled = true;
            txtFilterValue.Focus();
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterValue.Text == "")
            {
                _RefreshDriversList();
                return;
            }
            string column = "";
            switch (cbFilter.Text)
            {
                case "Driver ID":
                    {
                        column = "DriverID";
                        break;
                    }
                case "Person ID":
                    {
                        column = "PersonID";
                        break;
                    }
                case "National No.":
                    {
                        column = "NationalNo";
                        break;
                    }
                case "Full Name":
                    {
                        column = "FullName";
                        break;
                    }
            }
            if (column == "DriverID" || column == "PersonID")
                _dtAllDrivers.DefaultView.RowFilter = $"{column} = {txtFilterValue.Text}";
            else
                _dtAllDrivers.DefaultView.RowFilter = $"{column} LIKE '{txtFilterValue.Text}%'";
            lblRecordsCount.Text = _dtAllDrivers.DefaultView.Count.ToString();
        }
    }
}
