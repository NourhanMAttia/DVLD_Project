﻿using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsApplicationType
    {
        public clsApplicationType()
        {
            ID = -1;
            Name = "";
            Fees = 0;
        }
        private clsApplicationType(int ID, string Name, decimal Fees)
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
        public static clsApplicationType Find(int ID)
        {
            string Name = "";
            decimal Fees = 0;
            if (clsApplicationTypesData.FindByID(ID, ref Name, ref Fees))
                return new clsApplicationType(ID, Name, Fees);
            return null;
        }
    }
}
