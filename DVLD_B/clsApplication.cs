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
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int ApplicationID { get; set; }
        public int ApplicantPersonID{get;set;}
        public DateTime ApplicationDate{get;set;}
        public int ApplicationTypeID{get;set;}
        public byte ApplicationStatus{get;set;}
        public DateTime LastStatusDate{get;set;}
        public float PaidFees{get;set;}
        public int CreatedByUserID{get;set;}
        public clsApplication()
        {
            _Mode = enMode.AddNew;

            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationTypeID = -1;
            this.CreatedByUserID = -1;

            this.ApplicationStatus = 0;
            this.PaidFees = 0;

            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
        }
        private clsApplication(int ApplicatoinID, int ApplicantPersonID, int ApplicationTypeID, int CreatedByUserID,
                               byte ApplicationStatus, float PaidFees, DateTime ApplicationDate, DateTime LastStatusDate)
        {
            _Mode = enMode.Update;

            this.ApplicationID = ApplicatoinID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.CreatedByUserID = CreatedByUserID;

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
        public static clsApplication FindApplicationByID(int ApplicationID)
        {
            int personID = -1, applicationTypeID = -1, createdByUserID = -1;
            byte applicationStatus = 0;
            float paidFees = 0;
            DateTime applicationDate = DateTime.Now, lastStatusDate = DateTime.Now;
            if (clsApplicationsData.GetApplicationByID(ApplicationID, ref personID, ref applicationDate, ref applicationTypeID, ref applicationStatus, ref lastStatusDate, ref paidFees, ref createdByUserID))
                return new clsApplication(ApplicationID, personID, applicationTypeID, createdByUserID, applicationStatus, paidFees, applicationDate, lastStatusDate);
            return null;
        }
        private bool _AddNewApplication()
        {
            this.ApplicationID = clsApplicationsData.AddNewApplication(this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApplication()
        {
            return clsApplicationsData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewApplication())
                        {
                            _Mode = enMode.Update;
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
            return clsApplicationsData.UpdateStatus(this.ApplicationID, this.ApplicationStatus);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationID)
        {
            return clsApplicationsData.DoesPersonHaveActiveApplication(PersonID, ApplicationID);
        }
    }
}
