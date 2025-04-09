using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsApplicationTypes
    {
        public clsApplicationTypes()
        {
            ID = -1;
            Name = "";
            Fees = 0;
        }
        private clsApplicationTypes(int ID, string Name, decimal Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Fees = Fees;
        }
        public int ID { get; set; }
        public string Name{get;set;}
        public decimal Fees{get;set;}
        public static DataTable GetApplicationTypesList()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }
        public bool UpdateApplicationTypes()
        {
            return clsApplicationTypesData.UpdateApplicationTypes(this.ID, this.Name, this.Fees);
        }
        public static clsApplicationTypes Find(int ID)
        {
            string Name = "";
            decimal Fees = 0;
            if (clsApplicationTypesData.FindByID(ID, ref Name, ref Fees))
                return new clsApplicationTypes(ID, Name, Fees);
            return null;
        }
    }
}
