using System;
using System.Data;
using DVLD_D;
namespace DVLD_B
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int PersonID { set; get; }
        public int CountryID { set; get; }
        public short Gender { set; get; }
        public string NationalNo { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        private string _ImagePath;
        public string ImagePath
        {
            set { _ImagePath = value; }
            get { return _ImagePath; }
        }
        public DateTime DateOfBirth { set; get; }
        public clsCountry CountryInfo;

        public clsPerson()
        {
            Mode = enMode.AddNew;
            PersonID = -1;
            CountryID = -1;
            Gender = -1;
            NationalNo = "";
            FirstName = "";
            SecondName = "";
            ThirdName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            _ImagePath = "";
            DateOfBirth = DateTime.Now;
            CountryInfo.CountryID = -1;
            CountryInfo.CountryName = "";
        }
        private clsPerson(int PersonID, int CountryID, short Gender, string NationalNo, string FirstName,
                          string SecondName, string ThirdName, string LastName, string Email, string Phone,
                          string Address, string ImagePath, DateTime DateOfBirth)
        {
            Mode = enMode.Update;
            this.PersonID = PersonID;
            this.CountryID = CountryID;
            this.Gender = Gender;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this._ImagePath = ImagePath;
            this.DateOfBirth = DateOfBirth;
            this.CountryInfo = clsCountry.Find(CountryID);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static clsPerson Find(int PersonID)
        {
            int CountryID = -1;
            short Gender = -1;
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            string ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            bool isFound = clsPersonData.GetPersonInfoByID(PersonID, ref CountryID, ref Gender, ref NationalNo, 
                ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Email, ref Phone, ref Address, 
                ref ImagePath, ref DateOfBirth);
            if(isFound) return new clsPerson(PersonID, CountryID, Gender, NationalNo, FirstName, SecondName, ThirdName, 
                    LastName, Email, Phone, Address, ImagePath, DateOfBirth);
            return null;
        }
        public static clsPerson Find(string NationalNo)
        {
            int CountryID = -1;
            short Gender = -1;
            int PersonID = -1;
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            string Email = "";
            string Phone = "";
            string Address = "";
            string ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            bool isFound = clsPersonData.GetPersonInfoByNationalNo(ref PersonID, ref CountryID, ref Gender, 
                NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref Email, ref Phone, 
                ref Address, ref ImagePath, ref DateOfBirth);
            if(isFound) return new clsPerson(PersonID, CountryID, Gender, NationalNo, FirstName, SecondName, 
                ThirdName, LastName, Email, Phone, Address, ImagePath, DateOfBirth);
            return null;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.CountryID, this.Gender, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Phone, this.Address, this.ImagePath, this.DateOfBirth);
            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.CountryID, this.Gender, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.Email, this.Phone, this.Address, this.ImagePath, this.DateOfBirth);
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPerson())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        if (_UpdatePerson())
                            return true;
                        return false;
                    }
            }
            return false;
        }
        public bool IsPersonExist(int PersonID)
        {
            return clsPersonData.IsPersonExist(PersonID);
        }
        public bool IsPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
