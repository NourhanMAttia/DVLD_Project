using DVLD.People;
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

namespace DVLD
{
    public partial class frmListPeople: Form
    {
        public frmListPeople()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        private void _RefreshPeopleList()
        {
             _dtAllPeople = clsPerson.GetAllPeople();
             _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
            dgvManagePeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvManagePeople.Rows.Count.ToString();
            if(dgvManagePeople.Rows.Count > 0)
            {
                dgvManagePeople.Columns[0].HeaderText = "Person ID";
                dgvManagePeople.Columns[0].Width = 110;
                dgvManagePeople.Columns[1].HeaderText = "National No.";
                dgvManagePeople.Columns[1].Width = 120;
                dgvManagePeople.Columns[2].HeaderText = "First Name";
                dgvManagePeople.Columns[2].Width = 120;
                dgvManagePeople.Columns[3].HeaderText = "Second Name";
                dgvManagePeople.Columns[3].Width = 140;
                dgvManagePeople.Columns[4].HeaderText = "Third Name";
                dgvManagePeople.Columns[4].Width = 120;
                dgvManagePeople.Columns[5].HeaderText = "Last Name";
                dgvManagePeople.Columns[5].Width = 120;
                dgvManagePeople.Columns[6].HeaderText = "Gendor";
                dgvManagePeople.Columns[6].Width = 120;
                dgvManagePeople.Columns[7].HeaderText = "Date Of Birth";
                dgvManagePeople.Columns[7].Width = 140;
                dgvManagePeople.Columns[8].HeaderText = "Nationality";
                dgvManagePeople.Columns[8].Width = 120;
                dgvManagePeople.Columns[9].HeaderText = "Phone";
                dgvManagePeople.Columns[9].Width = 120;
                dgvManagePeople.Columns[10].HeaderText = "Email";
                dgvManagePeople.Columns[10].Width = 170;
            }

        }
        private void _Load()
        {
            _RefreshPeopleList();
            cbFilterPeople.SelectedIndex = 0;
        }
        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            _Load();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cbFilterPeople.Text)
            {
                case "Person ID":
                    {
                        FilterColumn = "PersonID";
                        break;
                    }
                case "National No":
                    {
                        FilterColumn = "NationalNo";
                        break;
                    }
                case "First Name":
                    {
                        FilterColumn = "FirstName";
                        break;
                    }
                case "Second Name":
                    {
                        FilterColumn = "SecondName";
                        break;
                    }
                case "Third Name":
                    {
                        FilterColumn = "ThirdName";
                        break;
                    }
                case "Last Name":
                    {
                        FilterColumn = "LastName";
                        break;
                    }
                case "Gender":
                    {
                        FilterColumn = "Gender";
                        break;
                    }
                case "Date Of Birth":
                    {
                        FilterColumn = "DateOfBirth";
                        break;
                    }
                case "Country":
                    {
                        FilterColumn = "CountryName";
                        break;
                    }
                case "Phone":
                    {
                        FilterColumn = "Phone";
                        break;
                    }
                case "Email":
                    {
                        FilterColumn = "Email";
                        break;
                    }
                default:
                    {
                        FilterColumn = "None";
                        break;
                    }
            }
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _RefreshPeopleList();
                return;
            }
            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = $"{FilterColumn} = {txtFilter.Text.Trim()}";
            else
                _dtPeople.DefaultView.RowFilter = $"{FilterColumn} LIKE '{txtFilter.Text.Trim()}%'";
        }
        private void cbFilterPeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cbFilterPeople.Text != "None");
            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();
            _RefreshPeopleList();
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterPeople.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tsmShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvManagePeople.CurrentRow.Cells[0].Value;
            frmShowPersonInfo form = new frmShowPersonInfo(PersonID);
            form.ShowDialog();
        }
        private void tsmAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson form = new frmAddUpdatePerson();
            form.ShowDialog();
            _RefreshPeopleList();
        }
        private void tsmEditPersonInfo_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvManagePeople.CurrentRow.Cells[0].Value;
            frmAddUpdatePerson form = new frmAddUpdatePerson(PersonID);
            form.ShowDialog();
            _RefreshPeopleList();
        }
        private void tsmDeletePerson_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvManagePeople.CurrentRow.Cells[0].Value;
            if(MessageBox.Show($"Are You Sure You Want To Delete This Person [{PersonID}]?","Confirm!",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show($"Person With ID [{PersonID}] Deleted Successfuly", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                    MessageBox.Show($"Failed To Delete Person With ID [{PersonID}]", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tsmSendEmail_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Isn't Implemented Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void tsmPhoneCall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Isn't Implemented Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvManagePeople_DoubleClick(object sender, EventArgs e)
        {
            int PersonID = (int)dgvManagePeople.CurrentRow.Cells[0].Value;
            frmShowPersonInfo form = new frmShowPersonInfo(PersonID);
            form.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
