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
    public partial class frmPeopleManagement: Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
        public frmPeopleManagement()
        {
            InitializeComponent();
        }
        private void _RefreshPeopleList()
        {
             _dtAllPeople = clsPerson.GetAllPeople();
             _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "Gender", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
            dgvManagePeople.DataSource = _dtPeople;
            lblRecordsCount.Text = dgvManagePeople.Rows.Count.ToString();
        }
        private void _Load()
        {
            _RefreshPeopleList();
        }

        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            
            //btnAddPerson.Image = new Bitmap(Properties.Resources.addUser, btnAddPerson.Width, btnAddPerson.Height);
        }
    }
}
