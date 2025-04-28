using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_D;

namespace DVLD_B
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public enum enApplicationType {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5, NewInternationalLicense = 6, RetakeTest = 7
        };
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };
        public int ApplicationID { get; set; }
        public int ApplicantPersonID{get;set;}
        public clsPerson PersonInfo { get; set; }
        public DateTime ApplicationDate{get;set;}
        public int ApplicationTypeID{get;set;}
        public clsApplicationType ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { get; set; }
        public string StatusText
        {
            get { return (ApplicationStatus == enApplicationStatus.New) ?"New" : (ApplicationStatus == enApplicationStatus.Cancelled) ?"Cancelled" :"Completed"; }
        }
        public DateTime LastStatusDate{get;set;}
        public float PaidFees{get;set;}
        public int CreatedByUserID{get;set;}
        public clsUser CreatedByUserInfo;
        public clsApplication()
        {
            Mode = enMode.AddNew;

            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = 0;
            this.CreatedByUserID = -1;

            this.ApplicationStatus = enApplicationStatus.New;
            this.PaidFees = 0;

            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
        }
        private clsApplication(int ApplicatoinID, int ApplicantPersonID, int ApplicationTypeID, int CreatedByUserID,
                               enApplicationStatus ApplicationStatus, float PaidFees, DateTime ApplicationDate, DateTime LastStatusDate)
        {
            Mode = enMode.Update;

            this.ApplicationID = ApplicatoinID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;

            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationTypeInfo = clsApplicationType.Find(ApplicationTypeID);
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);

            this.ApplicationStatus = ApplicationStatus;
            this.PaidFees = PaidFees;

            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
        }
        public static DataTable GetAllApplications()
        {
            return clsApplicationsData.GetAllApplications();
        }
        public static bool DoesApplicationExist(int ID)
        {
            return clsApplicationsData.DoesApplicationExist(ID);
        }
        public static clsApplication FindBaseApplicaiton(int ApplicationID)
        {
            int personID = -1, applicationTypeID=-1, createdByUserID = -1;
            byte applicationStatus = 1;
            float paidFees = 0;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            if (clsApplicationsData.GetApplicationByID(ApplicationID, ref personID, ref applicationDate,  ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                return new clsApplication(ApplicationID, personID, applicationTypeID, createdByUserID, (enApplicationStatus)applicationStatus, paidFees, applicationDate, lastStatusDate);
            return null;
        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        return false;
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdateApplication();
                        break;
                    }
            }
            return false;
        }
        public static bool DeleteApplication(int ApplicationID)
        {
            return clsApplicationsData.DeleteApplication(ApplicationID);
        }
        public bool UpdateStatus()
        {
            return clsApplicationsData.UpdateStatus(this.ApplicationID, (byte)this.ApplicationStatus);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationID)
        {
            return clsApplicationsData.DoesPersonHaveActiveApplication(PersonID, ApplicationID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationsData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }
        public int GetActiveApplicationID(clsApplication.enApplicationStatus ApplicationTypeID)
        {
            return clsApplicationsData.GetActiveApplicationID((int)ApplicationTypeID);
        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationsData.GetActiveApplicaitonIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }
    }
}
