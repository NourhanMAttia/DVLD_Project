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

namespace DVLD.People
{
    public partial class frmShowPersonInfo: Form
    {
        private int _PersonID;
        public frmShowPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.Find(_PersonID);
            if (Person != null)
            {
                ctrlPersonCardInfo1.PersonID = Person.PersonID;
                ctrlPersonCardInfo1.NationalNo = Person.NationalNo;
                ctrlPersonCardInfo1.Name = Person.FirstName + " " + Person.SecondName + " " + Person.ThirdName + " " + Person.LastName;
                ctrlPersonCardInfo1.Gender = Person.Gender == 0 ? "Male" : "Female";
                ctrlPersonCardInfo1.Email = Person.Email;
                ctrlPersonCardInfo1.Address = Person.Address;
                ctrlPersonCardInfo1.DateOfBirth = Person.DateOfBirth.ToShortDateString();
                ctrlPersonCardInfo1.Phone = Person.Phone;
                ctrlPersonCardInfo1.Country = Person.CountryInfo.CountryName;
                ctrlPersonCardInfo1.PersonImage = Person.ImagePath;
            }
            else
                MessageBox.Show($"Person With ID [{_PersonID}] Not Found", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
