using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsTest
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public int TestID { set; get; }
        public int TestAppointmentID{set;get;}
        public int CreatedByUserID{set;get;}
        public bool TestResult{set;get;}
        public string Notes{set;get;}
        public clsTest()
        {
            _Mode = enMode.AddNew;
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.CreatedByUserID = -1;
            this.TestResult = false;
            this.Notes = "";
        }
        private clsTest(int TestID, int TestAppointmentID, int CreatedByUserID, bool TestResult, string Notes)
        {
            _Mode = enMode.Update;
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.CreatedByUserID = CreatedByUserID;
            this.TestResult = TestResult;
            this.Notes = Notes;
        }
        public static DataTable GetAllTests()
        {
            return clsTestsData.GetAllTests();
        }
        public static clsTest GetTestInfoByID(int TestID)
        {
            int testAppointmentID = -1, createdByUserID = -1;
            bool testResult = false;
            string notes = "";
            if (clsTestsData.GetTestInfoByID(TestID, ref testAppointmentID, ref testResult, ref notes, ref createdByUserID))
                return new clsTest(TestID, testAppointmentID, createdByUserID, testResult, notes);
            return null;
        }
        public static clsTest GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, clsTestType.enTestType TestTypeID, int LicenseClassID)
        {
            int TestID = -1, TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";
            if (clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass(PersonID, (int)TestTypeID, LicenseClassID, ref TestID, ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))
                return new clsTest(TestID, TestAppointmentID, CreatedByUserID, TestResult, Notes);
            return null;
        }
        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
            return (this.TestID != -1);
        }
        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest(this.TestID, this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewTest())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateTest();
                    }
            }
            return false;
        }
        public static byte PassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
    }
}
