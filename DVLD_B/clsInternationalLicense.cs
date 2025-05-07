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
        

        public static DataTable GetInternationalLicensesPerDriver(int DriverID)
        {
            return clsInternationalLicensesData.GetInternationalLicensesPerDriver(DriverID);
        }
    }
}
