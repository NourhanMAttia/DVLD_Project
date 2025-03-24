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

namespace DVLD.People
{
    public partial class frmAddUpdatePerson: Form
    {
        public enum enMode { AddNew = 0, Update };
        private enMode _Mode = enMode.AddNew;
        private int _PersonID = -1;
        clsPerson _Person;
        private void _LoadPersonData()
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
                _LoadPersonData();
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
        ///// below is not stable
        private void _FormValidation(object sender, CancelEventArgs e)
        {
            //third name, email and image can be null
            
        }
        ///  
        private bool _HandlePersonImage()
        {
            const string destFolder = @"C:\DVLD-People-Images";
            if(pbPersonImage.ImageLocation != _Person.ImagePath)
            {
                if(_Person.ImagePath != "")
                {
                    //delete old image from file, copy new to file, update db to new image
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

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
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
            if(_Mode == enMode.AddNew)
            {
                if (_Person.Save())
                {
                    MessageBox.Show($"Person With ID [{_Person.PersonID}] Added Successfuly", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Mode = enMode.Update;
                    lblTitle.Text = "Edit Person Info";
                }
                else
                    MessageBox.Show($"Failed To Add Person With ID [{_Person.PersonID}]", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(_Mode == enMode.Update)
            {
                if (_Person.Save())
                    MessageBox.Show($"Person With ID [{_Person.PersonID}] Updated Successfuly", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Failed To Update Person With ID [{_Person.PersonID}]", "Failure!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
