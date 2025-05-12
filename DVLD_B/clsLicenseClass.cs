using System;
using System.Data;
using DVLD_D;

namespace DVLD_B
{
    public class clsLicenseClass
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int ClassID { get; set; }
        public string ClassName{get;set;}
        public string ClassDescription{get;set;}
        public byte MinimumAllowedAge{get;set;}
        public byte DefaultValidityLength{get;set;}
        public float ClassFees{get;set;}
        public clsLicenseClass()
        {
            _Mode = enMode.AddNew;
            this.ClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;
        }
        private clsLicenseClass(int ClassID, string ClassName, string ClassDescription, 
                                byte MinimumAllowedAge, byte DefaultValidityLength, float ClassFees)
        {
            _Mode = enMode.Update;
            this.ClassID = ClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
        }
        public static DataTable GetAllLicenseClasses()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }
        public static clsLicenseClass GetLicenseClassByID(int ID)
        {
            string name = "", description = "";
            byte minimumAllowedAge = 0, defaultValidityLength = 0;
            float fees = 0;
            if (clsLicenseClassData.GetLicenseClassByID(ID, ref name, ref description, ref minimumAllowedAge, ref defaultValidityLength, ref fees))
                return new clsLicenseClass(ID, name, description, minimumAllowedAge, defaultValidityLength, fees);
            return null;
        }
        public static clsLicenseClass GetLicenseClassByName(string Name)
        {
            int id = -1;
            string description = "";
            byte minimumAllowedAge = 0, defaultValidityLength = 0;
            float fees = 0;
            if (clsLicenseClassData.GetLicenseClassByName(Name, ref id,ref description, ref minimumAllowedAge, ref defaultValidityLength, ref fees))
                return new clsLicenseClass(id, Name, description, minimumAllowedAge, defaultValidityLength, fees);
            return null;
        }
        private bool _AddNewLicenseClass()
        {
            this.ClassID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.ClassID != -1);
        }
        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassData.UpdateLicenseClass(this.ClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewLicenseClass())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                        break;
                    }
                case enMode.Update:
                    {
                        return _UpdateLicenseClass();
                        break;
                    }
            }
            return false;
        }
        public static int GetDefaultValidityLengthPerClass(int ClassID)
        {
            return clsLicenseClassData.GetValidityLengthPerClass(ClassID);
        }
    }
}
