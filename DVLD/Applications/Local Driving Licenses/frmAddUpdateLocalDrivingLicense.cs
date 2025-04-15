﻿using DVLD.Global_Classes;
using DVLD_B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_Licenses
{
    public partial class frmAddUpdateLocalDrivingLicense : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        private int _SelectedPersonID=-1;
        private int _LocalLicenseApplicaitonID = -1;
        private clsLocalDrivingLicenseApplication _LocalLicenseApplication;

        public frmAddUpdateLocalDrivingLicense()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicense(int LocalLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalLicenseApplicaitonID = LocalLicenseApplicationID;
        }

        private void _FillLicenseClassesComboBox()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow row in dt.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private void _RefreshApplicationForm()
        {
            _FillLicenseClassesComboBox();
            if (_Mode == enMode.AddNew)
            {
                this.Text = "New Local Driving License Applicaiton";
                lblTitle.Text = "New Local Driving License Applicaiton";
                _LocalLicenseApplicaitonID = -1;
                _LocalLicenseApplication = new clsLocalDrivingLicenseApplication();
                _SelectedPersonID = -1;
                ctrlPersonCardInfoWithFilter1.FilterFocus();
                lblApplicationFee.Text = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).Fees.ToString();
                cbLicenseClass.SelectedIndex = 2;
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.GlobalUser.Username;
                tpApplicationInfo.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                this.Text = "Update Local Driving License Applicaiton";
                lblTitle.Text = "Update Local Driving License Applicaiton";
                btnSave.Enabled = true;
                tpApplicationInfo.Enabled = true;
            }
        }
        private void _LoadApplicationInfo()
        {
            ctrlPersonCardInfoWithFilter1.EnableFilter = false;
            _LocalLicenseApplication = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByApplicationID(_LocalLicenseApplicaitonID);
            if(_LocalLicenseApplication == null)
            {
                MessageBox.Show("Application Not Found.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlPersonCardInfoWithFilter1.LoadPersonInfo(_LocalLicenseApplication.ApplicantPersonID);
            lblApplicationID.Text = _LocalLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = _LocalLicenseApplication.ApplicationDate.ToShortDateString();
            lblApplicationFee.Text = _LocalLicenseApplication.PaidFees.ToString();
            lblCreatedBy.Text = clsUser.FindByUserID(_LocalLicenseApplication.CreatedByUserID).Username;
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(clsLicenseClass.GetLicenseClassByID(_LocalLicenseApplication.LicenseClassID).ClassName);
        }

        private void frmAddUpdateLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _RefreshApplicationForm();
            if (_Mode == enMode.Update)
                _LoadApplicationInfo();
        }
        private void frmAddUpdateLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardInfoWithFilter1.Focus();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update || ctrlPersonCardInfoWithFilter1.PersonID != -1)
            {
                ctrlPersonCardInfoWithFilter1.EnableFilter = false;
                tpApplicationInfo.Enabled = true;
                tcApplication.SelectedTab = tpApplicationInfo;
                btnSave.Enabled = true;
            }
            else
            {
                ctrlPersonCardInfoWithFilter1.EnableFilter = true;
                tpApplicationInfo.Enabled = false;
                tcApplication.SelectedTab = tbPersonalInfo;
                btnSave.Enabled = false;
                MessageBox.Show("Select a person first.", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _LocalLicenseApplication.ApplicationDate = Convert.ToDateTime(lblApplicationDate.Text);
            _LocalLicenseApplication.LicenseClassID = cbLicenseClass.SelectedIndex;
            _LocalLicenseApplication.PaidFees = Convert.ToSingle(lblApplicationFee.Text);
            _LocalLicenseApplication.CreatedByUserID = clsGlobal.GlobalUser.UserID;

            _LocalLicenseApplication.ApplicantPersonID = _SelectedPersonID;
            //_LocalLicenseApplication.
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void tcApplication_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex == 1 && ctrlPersonCardInfoWithFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Select A Person First.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true; 
            }
        }

        private void _OnPersonSelectedEventHandler(object sender, int PersonID)
        {
            _SelectedPersonID = PersonID;
            ctrlPersonCardInfoWithFilter1.LoadPersonInfo(PersonID);
        }
        private void ctrlPersonCardInfoWithFilter1_OnPersonSelected(int PersonID)
        {
            _SelectedPersonID = PersonID;
        }
    }
}
