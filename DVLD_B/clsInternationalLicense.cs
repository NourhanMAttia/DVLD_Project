using DVLD_D;
using System;
using System.Data;

namespace DVLD_B
{
    public class clsInternationalLicense
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int InternationalLicenseID { set; get; }
        public int ApplicationID{set;get;}
        public int DriverID{set;get;}
        public int IssuedUsingLocalLicenseID{set;get;}
        public int CreatedByUserID{set;get;}
        public DateTime IssueDate{set;get;}
        public DateTime ExpirationDate{set;get;}
        public bool IsActive{set;get;}
        public clsInternationalLicense()
        {
            _Mode = enMode.AddNew;
            this.InternationalLicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.CreatedByUserID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.IsActive = false;
        }
        private clsInternationalLicense(int InternationalLicenseID, int ApplicationID, int DriverID, int IssuedUsingLocalLicenseID, 
                                        int CreatedByUserID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            _Mode = enMode.Update;
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.CreatedByUserID = CreatedByUserID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
        }
        public static clsInternationalLicense GetInternationalLicenseInfo(int LicenseID)
        {
            int applicationID = -1, driverID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;
            if (clsInternationalLicensesData.GetInternationalLicenseInfoByID(LicenseID, ref applicationID, ref driverID, ref issuedUsingLocalLicenseID,
                                                                            ref createdByUserID, ref issueDate, ref expirationDate, ref isActive))
                return new clsInternationalLicense(LicenseID, applicationID, driverID, issuedUsingLocalLicenseID, createdByUserID, issueDate, expirationDate, isActive);
            return null;
        }
        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicensesData.GetAllInternationalLicenses();
        }
        public static DataTable GetInternationalLicensesPerDriver(int DriverID)
        {
            return clsInternationalLicensesData.GetInternationalLicensesPerDriver(DriverID);
        }
        public static clsInternationalLicense GetLastActiveInternationalLicense(int DriverID)
        {
            int internationalLicenseID = -1, applicationID = -1, issuedUsingLocalLicenseID = -1, createdByUserID = -1;
            DateTime issueDate = DateTime.Now, expirationDate = DateTime.Now;
            bool isActive = false;
            if (clsInternationalLicensesData.GetLastActiveInternationalLicense(ref internationalLicenseID, ref applicationID, DriverID,
                                                                              ref issuedUsingLocalLicenseID, ref createdByUserID,
                                                                              ref issueDate, ref expirationDate, ref isActive))
                return new clsInternationalLicense(internationalLicenseID, applicationID, DriverID, issuedUsingLocalLicenseID, createdByUserID,
                                                  issueDate, expirationDate, isActive);
            return null;
        }
        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesData.AddNewInternationalLicense(this.ApplicationID, this.DriverID, this.IssuedUsingLocalLicenseID, this.CreatedByUserID, this.IssueDate, this.ExpirationDate, this.IsActive);
            return (this.InternationalLicenseID != -1);
        }
        public bool Save()
        {
            if (_AddNewInternationalLicense())
            {
                _Mode = enMode.Update;
                return true;
            }
            return false;
        }
        public static bool IsLicenseActive(int LicenseID)
        {
            return clsInternationalLicensesData.IsLicenseActive(LicenseID);
        }
    }
}
