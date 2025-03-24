using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.People.Controls
{
    public partial class ctrlPersonCardInfo: UserControl
    {
        public ctrlPersonCardInfo()
        {
            InitializeComponent();
        }
        public int PersonID
        {
            set { lblPersonID.Text = value.ToString(); }
        }
        public string Name
        {
            set { lblName.Text = value; }
        }
        public string NationalNo
        {
            set { lblNationalNo.Text = value; }
        }
        public string Gender
        {
            set 
            { 
                lblGender.Text = value;
                if (value == "Male") pbPersonImage.Image = Properties.Resources.male;
                else if (value == "Female") pbPersonImage.Image = Properties.Resources.female;
            }
        }
        public string Email
        {
            set { lblEmail.Text = value; }
        }
        public string Address
        {
            set { lblAddress.Text = value; }
        }
        public string DateOfBirth
        {
            set { lblDateOfBirth.Text = value; }
        }
        public string Phone
        {
            set { lblPhone.Text = value; }
        }
        public string Country
        {
            set { lblCountry.Text = value; }
        }
        public string PersonImage
        {
            set
            {
                try
                {
                    pbPersonImage.Image = Image.FromFile(value);
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error Loading Image: " + e.Message);
                }
            }
        }
        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(lblPersonID.Text, out int PersonID))
            { 
                frmAddUpdatePerson form = new frmAddUpdatePerson(PersonID);
                form.ShowDialog();
            }
        }
    }
}
