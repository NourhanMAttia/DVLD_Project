using DVLD_D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsDetainedLicense
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int DetainID { set; get; }
        public int LicenseID { set; get; }
        public DateTime DetainDate{set;get;}
        public float FineFees{set;get;}
        public int CreatedByUserID{set;get;}
        public bool IsReleased{set;get;}
        public DateTime? ReleaseDate{set;get;}
        public int? ReleasedByUserID{set;get;}
        public int? ReleaseApplicationID{set;get;}
        public clsDetainedLicense()
        {
            _Mode = enMode.AddNew;
            this.LicenseID = -1;
            this.CreatedByUserID = -1;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
            this.DetainDate = DateTime.Now;
            this.ReleaseDate = DateTime.Now;
            this.FineFees = 0;
            this.IsReleased = false;
        }
        private clsDetainedLicense(int DetainID, int LicenseID, int CreatedByUserID, int? ReleasedByUserID, int? ReleasedApplicationID, DateTime DetainDate, DateTime? ReleaseDate, float FineFees, bool IsReleased)
        {
            _Mode = enMode.Update;
            this.LicenseID = LicenseID;
            this.CreatedByUserID = CreatedByUserID;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleasedApplicationID;
            this.DetainDate = DetainDate;
            this.ReleaseDate = ReleaseDate;
            this.FineFees = FineFees;
            this.IsReleased = IsReleased;
            this.DetainID = DetainID;
        }
        public static DataTable GetAllDetainedLicenses()
        {
            return clsDetainedLicensesData.GetAllDetainedLicenses();
        }
        public static clsDetainedLicense GetDetainedLicenseInfo(int DetainID)
        {
            int licenseID=-1, createdByUserID = -1, releasedByUserID = -1, releaseApplicationID = -1;
            DateTime releaseDate = DateTime.Now, detainDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;
            if (clsDetainedLicensesData.GetDetainedLicenseInfo(DetainID, ref licenseID, ref detainDate, ref fineFees, ref createdByUserID,
                                                              ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
                return new clsDetainedLicense(DetainID, licenseID, createdByUserID, releasedByUserID, releaseApplicationID, detainDate, releaseDate, fineFees, isReleased);
            return null;
        }
        public static clsDetainedLicense GetDetainedLicenseInfoByLicenseID(int LicenseID)
        {
            int detainID = -1, createdByUserID = -1; int? releasedByUserID = -1, releaseApplicationID = -1;
            DateTime? releaseDate = DateTime.Now; DateTime detainDate = DateTime.Now;
            float fineFees = 0;
            bool isReleased = false;
            if(clsDetainedLicensesData.GetDetainedLicenseInfoByLicenseID(LicenseID, ref detainID, ref detainDate, ref fineFees, ref createdByUserID, ref isReleased, ref releaseDate, ref releasedByUserID, ref releaseApplicationID))
                return new clsDetainedLicense(detainID, LicenseID, createdByUserID, releasedByUserID, releaseApplicationID, detainDate, releaseDate, fineFees, isReleased);
            return null;
        }
        private bool _AddNewDetainedLicense()
        {
            this.DetainID = clsDetainedLicensesData.DetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID, this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
            return (this.DetainID != -1);
        }
        private bool _UpdateDetainedLicense()
        {
            return clsDetainedLicensesData.UpdateDetainedLicense(this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
                                                                 this.IsReleased, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDetainedLicense())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateDetainedLicense();
                    }
            }
            return false;
        }
        public static bool DeleteDetainedLicense(int DetainID)
        {
            return clsDetainedLicensesData.DeleteDetainedLicense(DetainID);
        }
        public static bool IsLicenseDetained(int LicenseID)
        {
            return clsDetainedLicensesData.IsLicenseDetained(LicenseID);
        }
    }
}
