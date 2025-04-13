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
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseClassID = -1;
        }
        private clsLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID =LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }

        public static DataTable GetAllLocalLicenseApplications()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllApplications();
        }
        public static clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplicationByLocalApplicationID(int ID)
        {
            int applicationID = -1, licenseClassID = -1;
            if (clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByLocalApplicationID(ID, ref applicationID, ref licenseClassID))
                return new clsLocalDrivingLicenseApplication(ID, applicationID, licenseClassID);
            return null;
        }
        public static clsLocalDrivingLicenseApplication GetLocalDrivingLicenseApplicationByApplicationID(int applicationID)
        {
            int localDrivingLicenseApplicationID = -1, licenseClassID = -1;
            if (clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(applicationID, ref localDrivingLicenseApplicationID, ref licenseClassID));
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
