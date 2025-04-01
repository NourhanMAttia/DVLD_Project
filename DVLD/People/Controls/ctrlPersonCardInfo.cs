using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_B;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardInfo: UserControl
    {
        public ctrlPersonCardInfo()
        {
            InitializeComponent();
        }
        private int _PersonID = -1;
        private clsPerson _Person = new clsPerson();
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get
            {
                return _Person;
            }
        }
        private void _LoadPersonImage()
        {
            if (_Person.ImagePath == "")
                pbPersonImage.Image = (_Person.Gender == 0) ? Properties.Resources.male: Properties.Resources.female;
            else
            {
                if (File.Exists(_Person.ImagePath))
                    pbPersonImage.ImageLocation = _Person.ImagePath;
                else
                    MessageBox.Show("Couldn't Find Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }
        private void _FillPersonInfo()
        {
            llblEditPersonInfo.Enabled = true;
            lblPersonID.Text = _Person.PersonID.ToString();
            lblName.Text = _Person.FullName;
            lblNationalNo.Text = _Person.NationalNo;
            lblGender.Text = (_Person.Gender == (short)0) ? "Male" : "Female";
            lblPhone.Text = _Person.Phone;
            lblEmail.Text = _Person.Email;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = _Person.CountryInfo.CountryName;
            _LoadPersonImage();
        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"Couldn't Find Person With ID [{PersonID}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if(_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show($"Couldn't Find Person With National Number [{NationalNo}]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[???]";
            lblName.Text = "[???]";
            lblNationalNo.Text = "[???]";
            lblGender.Text = "[???]";
            lblEmail.Text = "[???]";
            lblPhone.Text = "[???]";
            lblAddress.Text = "[???]";
            lblCountry.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            pbPersonImage.Image = Properties.Resources.male;
        }
        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
                frmAddUpdatePerson form = new frmAddUpdatePerson(_Person.PersonID);
                form.ShowDialog();
                LoadPersonInfo(_Person.PersonID);
        }
    }
}
