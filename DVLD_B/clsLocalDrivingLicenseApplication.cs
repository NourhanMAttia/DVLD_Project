using System;
using System.Data;
using DVLD_D;
using Microsoft.Win32;

namespace DVLD_B
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicenseClass LicenseClassInfo;
        public clsLocalDrivingLicenseApplication()
        {
            _Mode = enMode.AddNew;
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID, int ApplicantPersonID,
                                                  int ApplicationTypeID, int CreatedByUserID, DateTime ApplicationDate, DateTime LastStatusDate, 
                                                  enApplicationStatus ApplicationStatus, float PaidFees)
        {
            _Mode = enMode.Update;
            this.LocalDrivingLicenseApplicationID =LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.ApplicationStatus = ApplicationStatus;
            this.PaidFees = PaidFees;
            this.LicenseClassInfo = clsLicenseClass.GetLicenseClassByID(LicenseClassID);
        }

        public static DataTable GetAllLocalLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllApplications();
        }
        public static clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplicationByLocalApplicationID(int ID)
        {
            int applicationID = -1, licenseClassID = -1;
            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByLocalApplicationID(ID, ref applicationID, ref licenseClassID);
            if (isFound)
            {
                clsApplication Application = clsApplication.FindBaseApplicaiton(applicationID);
                return new clsLocalDrivingLicenseApplication(ID, Application.ApplicationID, licenseClassID, Application.ApplicantPersonID,
                                                             Application.ApplicationTypeID, Application.CreatedByUserID, Application.ApplicationDate,
                                                             Application.LastStatusDate, Application.ApplicationStatus, Application.PaidFees);
            }
            else 
                return null;
        }
        public static clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplicationByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = -1, licenseClassID = -1;
            bool isFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(applicationID, ref localDrivingLicenseApplicationID, ref licenseClassID);
            if (isFound)
            {
                clsApplication Application = clsApplication.FindBaseApplicaiton(applicationID);
                return new clsLocalDrivingLicenseApplication(localDrivingLicenseApplicationID, Application.ApplicationID, licenseClassID,
                                                             Application.ApplicantPersonID, Application.ApplicationTypeID, Application.CreatedByUserID,
                                                             Application.ApplicationDate, Application.LastStatusDate, Application.ApplicationStatus,
                                                             Application.PaidFees);
            }
            else
                return null;
        }
        
        private bool _AddNewLocalLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, this.LicenseClassID);
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }
        public bool Save()
        {
            base.Mode = (clsApplication.enMode)_Mode;
            if (!base.Save()) return false;
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLocalLicenseApplication())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdateLocalLicenseApplication();
                        break;
                    }
            }
            return false;
        }
        public bool DeleteLocalLicenseApplication()
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID);
        }
        

    }
}
