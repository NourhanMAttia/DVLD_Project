using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsTestType
    {
        public enum enTestType { VisionTest=1, WrittenTest=2, StreetTest=3};
        public int ID { get; set; }
        public string Name{get; set;}
        public string Description{get; set;}
        public float Fees{get; set;}
        public clsTestType()
        {
            ID = -1;
            Name = "";
            Description = "";
            Fees = -1;
        }
        private clsTestType(int ID, string Name, string Description, float Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Fees = Fees;
        }
        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();
        }
        public static clsTestType GetTestTypeByID(int ID)
        {
            string name = "", description = "";
            float fees = -1;
            if (clsTestTypesData.GetTestTypeByID(ID, ref name, ref description, ref fees))
                return new clsTestType(ID, name, description, fees);
            else
                return null;
        }
        public bool UpdateTestType()
        {
            return clsTestTypesData.UpdateTestType(this.ID, this.Name, this.Description, this.Fees);
        }
    }
}
