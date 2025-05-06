using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsDriver
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;
        public int DriverID { set; get; }
        public int PersonID{set;get;}
        public int CreatedByUserID{set;get;}
        public DateTime CreatedDate{set;get;}
        public clsDriver()
        {
            _Mode = enMode.AddNew;
            this.DriverID = -1;
            this.PersonID = -1;
            this.CreatedByUserID = -1;
            this.CreatedDate = DateTime.Now;
        }
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            _Mode = enMode.Update;
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }
        public static DataTable GetAllDrivers()
        {
            return clsDriversData.GetAllDrivers();
        }
        public static clsDriver GetDriverByID(int ID)
        {
            int personID = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;
            if (clsDriversData.GetDriverInfoByID(ID, ref personID, ref createdByUserID, ref createdDate))
                return new clsDriver(ID, personID, createdByUserID, createdDate);
            return null;
        }
        public static clsDriver GetDriverByPersonID(int PersonID)
        {
            int driverID = -1, createdByUserID = -1;
            DateTime createdDate = DateTime.Now;
            if (clsDriversData.GetDriverInfoByPersonID(PersonID, ref driverID, ref createdByUserID, ref createdDate))
                return new clsDriver(driverID, PersonID, createdByUserID, createdDate);
            return null;
        }
        private bool _AddNewDriver()
        {
            this.DriverID = clsDriversData.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate);
            return (this.DriverID != -1);
        }
        private bool _UpdateDriver()
        {
            return clsDriversData.UpdateDriver(this.DriverID, this.PersonID, this.CreatedByUserID, this.CreatedDate);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewDriver())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateDriver();
                    }
            }
            return false;
        }
        public static bool Delete(int DriverID)
        {
            return clsDriversData.DeleteDriver(DriverID);
        }
        public static bool DoesDriverExist(int DriverID)
        {
            return clsDriversData.DoesDriverExist(DriverID);
        }
        public static bool DoesDriverExistByPersonID(int PersonID)
        {
            return clsDriversData.DoesDriverExistByPersonID(PersonID);
        }
    }
}
