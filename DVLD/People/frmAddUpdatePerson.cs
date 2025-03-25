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
using System.IO;
using System.Net.Sockets;
using DVLD.Global_Classes;

namespace DVLD.People
{
    public partial class frmAddUpdatePerson: Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler OnDataBack; 
        public enum enMode { AddNew = 0, Update };
        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        clsPerson _Person;
        ErrorProvider ep = new ErrorProvider();
        private void _LoadPersonDataFromDB()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show($"No Person With ID [{_PersonID}]", "Person Not Found!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            if (_Person.Gender == 0) rbMale.Checked = true;
            else rbFemale.Checked = true;
            cbCountries.SelectedIndex = cbCountries.FindString(_Person.CountryInfo.CountryName);
            if (_Person.ImagePath != "") pbPersonImage.ImageLocation = _Person.ImagePath;
            llblRemoveImage.Visible = (_Person.ImagePath != "");
        }
        private void _LoadPersonDataFromForm()
        {
            int NationalityCountryID = clsCountry.Find(cbCountries.Text).CountryID;
            _Person.CountryID = NationalityCountryID;
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Gender = (rbFemale.Checked) ? (short)1 : (short)0;
            _Person.ImagePath = (pbPersonImage.ImageLocation == null) ? "" : pbPersonImage.ImageLocation;
        }
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _PersonID = -1;
            _Mode = enMode.AddNew; 
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.Update;
        }
        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            cbCountries.DataSource = clsCountry.GetAllCountries();
            cbCountries.DisplayMember = "CountryName";
            cbCountries.ValueMember = "CountryID";
            cbCountries.SelectedIndex = cbCountries.FindString("Jordan");

            if (rbMale.Checked) pbPersonImage.Image = Properties.Resources.male;
            else if (rbFemale.Checked) pbPersonImage.Image = Properties.Resources.female;

            llblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else if (_Mode == enMode.Update)
            {
                lblTitle.Text = "Edit Person Info";
                _LoadPersonDataFromDB();
            }
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Properties.Resources.female;
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Properties.Resources.male;
        }
        private bool _HandlePersonImage()
        {
            if(pbPersonImage.ImageLocation != _Person.ImagePath)
            {
                if(_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show("Failed To Delete Image From File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if(pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                    if (clsUtils.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourcePath = openFileDialog.FileName;
                pbPersonImage.Load(sourcePath);
                llblRemoveImage.Visible = true;
            }
        }
        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbFemale.Checked) pbPersonImage.Image = Properties.Resources.female;
            else if (rbMale.Checked) pbPersonImage.Image = Properties.Resources.male;
            llblRemoveImage.Visible = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("One or more fields are not valid, put mouse over red icon(s) to see error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!_HandlePersonImage()) return;
            _LoadPersonDataFromForm();
            if (_Person.Save())
            {
                lblTitle.Text = "Update Person";
                lblPersonID.Text = _Person.PersonID.ToString();
                _Mode = enMode.Update;
                MessageBox.Show("Person Info Saved Successfuly", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnDataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error Saving Person Info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void  _ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (string.IsNullOrEmpty(tb.Text.Trim()))
            {
                e.Cancel = true;
                ep.SetError(tb, "This Field Is Required!");
            }
            else
                ep.SetError(tb, "");
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text.Trim() == "") return;
            else if (!clsValidation.IsValidEmail(tb.Text.Trim()))
            {
                e.Cancel = true;
                ep.SetError(tb, "Invalid Email Format!");
            }
            else
            {
                e.Cancel = false;
                ep.SetError(tb, "");
            } 
        }
        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                ep.SetError(txtNationalNo, "National Number Is A Required Field!");
                e.Cancel = true;
                return;
            }
            else if (txtNationalNo.Text.Trim() == _Person.NationalNo) 
            {
                e.Cancel = false;
                ep.SetError(txtNationalNo, "");
                return;
            }
            else if (clsPerson.IsPersonExist(txtNationalNo.Text.Trim()) && txtNationalNo.Text.Trim() != _Person.NationalNo)
            {
                ep.SetError(txtNationalNo, "This National Number Is Used For Someone Else!");
                e.Cancel = true;
                return;
            }
            else
            {
                e.Cancel = false;
                ep.SetError(txtNationalNo, null);
                return;
            }
        }
    }
}
