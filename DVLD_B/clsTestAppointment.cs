using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsTestAppointment
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int TestAppointmentID { set; get; }
        public clsTestType.enTestType TestTypeID { set; get; }
        public int LocalDrivingLicenseApplicationID{set;get;}
        public DateTime AppointmentDate{set;get;}
        public float PaidFees{set;get;}
        public int CreatedByUserID{set;get;}
        public bool IsLocked{set;get;}
        public int RetakeTestApplicationID{set;get;}
        public int TestID
            {
            get { return _GetTestID(); }
            }
        public clsTestAppointment()
        {
            _Mode = enMode.AddNew;
            this.TestAppointmentID = -1;
            this.TestTypeID = (clsTestType.enTestType)1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.CreatedByUserID = -1;
            this.RetakeTestApplicationID = -1;
            this.PaidFees = 0;
            this.IsLocked = false;
            this.AppointmentDate = DateTime.Now;
        }
        private clsTestAppointment(int TestAppointmentID, clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID, 
                                   DateTime AppointmentDate, float PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {
            _Mode = enMode.Update;
            this.TestAppointmentID = TestAppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.CreatedByUserID = CreatedByUserID;
            this.RetakeTestApplicationID = RetakeTestApplicationID;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            this.AppointmentDate = AppointmentDate;
        }
        public static DataTable GetAllTestAppointment()
        {
            return clsTestAppointmentsData.GetAllTestAppointments();
        }
        private bool _AddNewTestAppointment()
        {
            this.TestAppointmentID = clsTestAppointmentsData.AddNewTestAppointment((int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
            return (this.TestAppointmentID != -1);
        }
        private bool _UpdateTestAppointment()
        {
            return clsTestAppointmentsData.UpdateTestAppointment(this.TestAppointmentID, (int)this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTestAppointment())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateTestAppointment();
                    }
            }
            return false;
        }
        public bool Delete(int LocalDrivingLicenseApplicationID)
        {
            return clsTestAppointmentsData.DeleteTestAppointment(this.TestAppointmentID, LocalDrivingLicenseApplicationID);
        }
        private int _GetTestID()
        {
            return clsTestAppointmentsData.GetTestID(this.TestAppointmentID);
        }
        public static clsTestAppointment Find(int AppointmentID)
        {
            int testTypeID = -1, localDrivingLicenseApplicationID = -1, createdByUserID = -1, retakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            float paidFees = 0;
            bool isLocked = false;
            if (clsTestAppointmentsData.GetTestAppointmentInfoByID(AppointmentID, ref testTypeID, ref localDrivingLicenseApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked, ref retakeTestApplicationID))
                return new clsTestAppointment(AppointmentID, (clsTestType.enTestType)testTypeID, localDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
            return null;
        }
        public static clsTestAppointment GetLastTestAppointment(clsTestType.enTestType TestTypeID, int LocalDrivingLicenseApplicationID)
        {
            int appointmentID = -1, createdByUserID = -1, retakeTestApplicationID = -1;
            DateTime appointmentDate = DateTime.Now;
            bool isLocked = false;
            float paidFees = 0;
            if (clsTestAppointmentsData.GetLastTestAppointment(ref appointmentID, (int)TestTypeID, LocalDrivingLicenseApplicationID,
                                                                  ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked,
                                                                  ref retakeTestApplicationID))
                return new clsTestAppointment(appointmentID, TestTypeID, LocalDrivingLicenseApplicationID, appointmentDate, paidFees, createdByUserID, isLocked, retakeTestApplicationID);
            return null;
        }
        public DataTable GetApplicationTestAppointmentPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationAppointmentsPerTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static DataTable GetApplicationTestAppointmentPerTestType(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            return clsTestAppointmentsData.GetApplicationAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
    }
}
