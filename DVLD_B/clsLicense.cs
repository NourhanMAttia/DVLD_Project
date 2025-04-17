using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using DVLD_D;

namespace DVLD_B
{
    public class clsLicense
    {
        private enum enMode { AddNew=0, Update=1};
        private enMode _Mode = enMode.AddNew;
        public int LicenseID { set; get; }
        public int ApplicationID{set;get;}
        public int DriverID { set; get; }
        public int LicenseClass{set;get;}
        public int CreatedByUserID{set;get;}
        public DateTime IssueDate{set;get;}
        public DateTime ExpirationDate{set;get;}
        public string Notes{set;get;}
        public float PaidFees{set;get;}
        public bool IsActive{set;get;}
        public byte IssueReason{set;get;}
        public clsLicense()
        {
            _Mode = enMode.AddNew;
            this.LicenseID = -1;
            this.ApplicationID = -1;
            this.LicenseClass = -1;
            this.CreatedByUserID = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.Notes = "";
            this.PaidFees = 0;
            this.IsActive = false;
            this.IssueReason = 0;
        }
        private clsLicense(int LicenseID, int ApplicationID, int DriverID,int LicenseClass, int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate,
                           string Notes, float PaidFees, byte IssueReason, bool IsActive)
        {
            _Mode = enMode.Update;
            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.CreatedByUserID = CreatedByUserID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
        }
        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }
        public static clsLicense GetLicenseInfoByID(int LicenseID)
        {
            int applicationID = -1, licenseClass = -1, driverID =-1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            string notes = "";
            float paidFees = 0;
            byte issueReason = 0;
            bool isActive = false;
            if (clsLicensesData.GetLicenseInfoByID(LicenseID, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate,
                                                  ref notes, ref paidFees, ref isActive, ref issueReason, ref createdByUserID))
                return new clsLicense(LicenseID, applicationID, driverID, licenseClass, createdByUserID, issueDate, expirationDate, notes,
                                      paidFees, issueReason, isActive);
            return null;

        }
        public static DataTable GetDriverLicenses(int DriverID)
        {
            return clsLicensesData.GetDriverLicenses(DriverID);
        }
        private bool _AddNewLicense()
        {
            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate, this.ExpirationDate,
                                                           this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
            return (this.LicenseID != -1);
        }
        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
                                                 this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLicense())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateLicense();
                    }
            }
            return false;
        }
        public bool DeactivateLicense()
        {
            return clsLicensesData.DeactivateLicense(this.LicenseID);
        }
        public static int GetActiveLicenseIDForPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
        }
        public static bool DoesLicenseExistForPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.DoesLicenseExistForPersonID(PersonID, LicenseClassID);
        }
    }
}
