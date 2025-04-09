using DVLD_D;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_B
{
    public class clsUser
    {
        enum enMode { AddNew=0, Update=1 };
        private enMode _Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isActive { get; set; }
        public clsPerson Person;
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            Username = "";
            Password = "";
            isActive = false;
            _Mode = enMode.AddNew;
        }
        private clsUser(int UserID, int PersonID, string Username, string Password, bool isActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.isActive = isActive;
            this.Person = clsPerson.Find(PersonID);
            _Mode = enMode.Update;
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username, this.Password, this.isActive);
            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username, this.Password, this.isActive);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        } 
        public static clsUser FindByUserID(int UserID)
        {
            int PersonID = -1;
            string Username = "";
            string Password = "";
            bool isActive = false;
            if (clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref Username, ref Password, ref isActive))
                return new clsUser(UserID, PersonID, Username, Password, isActive);
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string Username = "";
            string Password = "";
            bool isActive = false;
            if (clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref Username, ref Password, ref isActive))
                return new clsUser(UserID, PersonID, Username, Password, isActive);
            else
                return null;
        }
        public static clsUser FindByUsernameAndPassword(string Username, string Password)
        {
            int PersonID = -1;
            int UserID = -1;
            bool isActive = false;
            if (clsUserData.GetUserInfoByUsernameAndPassword(Username, Password, ref UserID, ref PersonID, ref isActive))
                return new clsUser(UserID, PersonID, Username, Password, isActive);
            else
                return null;
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                            break;
                    }
                case enMode.Update:
                    {
                        return _UpdateUser();
                        break;
                    }
            }
            return false;
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static bool IsUserExist(int UserID)
        {
            return clsUserData.IsUserExist(UserID);
        }
        public static bool IsUserExist(string Username)
        {
            return clsUserData.IsUserExist(Username);
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
        public bool ChangePassword(string NewPassword)
        {
            return clsUserData.ChangePassword(this.UserID, NewPassword);
        }
    }
}
