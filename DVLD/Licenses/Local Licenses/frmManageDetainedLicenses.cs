﻿using DVLD.Global_Classes;
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

namespace DVLD.Licenses.Local_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }
        private DataTable _dtAllDetainedLicenses;
        private bool _AllowNumbersOnly = false;
        private void _RefreshList()
        {
            _dtAllDetainedLicenses = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = _dtAllDetainedLicenses;
            lblRecordsCount.Text = _dtAllDetainedLicenses.Rows.Count.ToString();
        }
        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _RefreshList();
            txtFilterValue.Visible = false;
            cbIsReleased.Visible = false;
            cbFilter.SelectedIndex = 0;
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Selected = cbFilter.SelectedItem.ToString();
            if(Selected == "None")
            {
                txtFilterValue.Visible = false;
                _RefreshList();
                return;
            }
            if(Selected == "Is Released")
            {
                txtFilterValue.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.SelectedIndex = 0;
                return;
            }
            txtFilterValue.Visible = true;
            txtFilterValue.Focus();
            cbIsReleased.Visible = false;
            if (Selected == "Detain ID" || Selected == "Release Application ID")
                _AllowNumbersOnly = true;
            else
                _AllowNumbersOnly = false;
        }
        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbIsReleased.SelectedItem.ToString();
            if (selected == "NO")
                _dtAllDetainedLicenses.DefaultView.RowFilter = $"IsReleased = 0";
            else
                _dtAllDetainedLicenses.DefaultView.RowFilter = $"IsReleased = 1";
            lblRecordsCount.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_AllowNumbersOnly)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    e.Handled = true;
            }
        }
        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterValue.Text == "")
            {
                _RefreshList();
                return;
            }
            string column = "";
            string Selected = cbFilter.SelectedItem.ToString();
            switch (Selected)
            {
                case "Detain ID":
                    {
                        column = "DetainID";
                        break;
                    }
                case "Release Application ID":
                    {
                        column = "ReleaseApplicationID";
                        break;
                    }
                case "Full Name":
                    {
                        column = "FullName";
                        break;
                    }
                case "National No.":
                    {
                        column = "NationalNo";
                        break;
                    }
            }
            if (column == "DetainID" || column == "ReleaseApplicationID")
                _dtAllDetainedLicenses.DefaultView.RowFilter = $"{column} = {txtFilterValue.Text}";
            else
                _dtAllDetainedLicenses.DefaultView.RowFilter = $"{column} LIKE '{txtFilterValue.Text}%'";
            lblRecordsCount.Text = _dtAllDetainedLicenses.DefaultView.Count.ToString();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshList();
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
            _RefreshList();
        }

        private void tsmShowPersonInfo_Click(object sender, EventArgs e)
        {
            string NationalNo = (string)dgvDetainedLicenses.CurrentRow.Cells[6].Value;
            clsPerson person = clsPerson.Find(NationalNo);
            frmShowPersonInfo frm = new frmShowPersonInfo(person.PersonID);
            frm.ShowDialog();
        }
        private void tsmShowLicenseInfo_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            clsLicense license = clsLicense.GetLicenseInfoByID(LicenseID);
            clsLocalDrivingLicenseApplication localApp = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByApplicationID(license.ApplicationID);
            if (localApp != null)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(localApp.LocalDrivingLicenseApplicationID);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Local Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void tsmShowLicenseHistory_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvDetainedLicenses.CurrentRow.Cells[1].Value;
            clsLicense license = clsLicense.GetLicenseInfoByID(LicenseID);
            clsDriver driver = clsDriver.GetDriverByID(license.DriverID);
            frmLicenseHistory frm = new frmLicenseHistory(driver.DriverID, -1);
            frm.ShowDialog();
        }
        private void tsmReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            int DetainID = (int)dgvDetainedLicenses.CurrentRow.Cells[0].Value;
            clsDetainedLicense detainedLicense = clsDetainedLicense.GetDetainedLicenseInfo(DetainID);
            clsLicense license = clsLicense.GetLicenseInfoByID(detainedLicense.LicenseID);
            clsDriver driver = clsDriver.GetDriverByID(license.DriverID);

            clsApplication releaseApplication = new clsApplication();
            releaseApplication.ApplicantPersonID = driver.PersonID;
            releaseApplication.PersonInfo = clsPerson.Find(releaseApplication.ApplicantPersonID);
            releaseApplication.ApplicationDate = DateTime.Now;
            releaseApplication.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            releaseApplication.ApplicationTypeID = (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            releaseApplication.ApplicationTypeInfo = clsApplicationType.Find(releaseApplication.ApplicationTypeID);
            releaseApplication.CreatedByUserID = clsGlobal.GlobalUser.UserID;
            releaseApplication.CreatedByUserInfo = clsUser.FindByUserID(releaseApplication.CreatedByUserID);
            releaseApplication.PaidFees = releaseApplication.ApplicationTypeInfo.Fees;
            if (releaseApplication.Save())
            {
                detainedLicense.IsReleased = true;
                detainedLicense.ReleaseDate = DateTime.Now;
                detainedLicense.ReleasedByUserID = clsGlobal.GlobalUser.UserID;
                detainedLicense.ReleaseApplicationID = releaseApplication.ApplicationID;
                if (detainedLicense.Save())
                {
                    MessageBox.Show("Rleased Detained License Successfuly.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshList();
                }
                else
                    MessageBox.Show("Failed To Release Detained License.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Failed To Complete Release License Application.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cmManageDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            int DetainID = (int)dgvDetainedLicenses.CurrentRow.Cells[0].Value;
            clsDetainedLicense detainedLicense = clsDetainedLicense.GetDetainedLicenseInfo(DetainID);
            if (detainedLicense == null)
            {
                MessageBox.Show("Detained License Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (detainedLicense.IsReleased)
                tsmReleaseDetainedLicense.Enabled = false;
        }
    }
}
