using DVLD_B;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace DVLD.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser GlobalUser;
        public static bool RememberUsernameAndPassword(string username, string password)
        {
            bool hasRemembered = false;
            string FilePath = @"C:\DVLD-Credentials\User-Credentials.txt";
            if(username == "" && password == "")
            {
                if (File.Exists(FilePath))
                {
                    try
                    {
                        File.Delete(FilePath);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error Deleting Credentials File.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return true;
            }
            string Delim = "#///#";
            string credentialsToRemember = GlobalUser.Username + Delim + GlobalUser.Password;
            try
            {
                File.WriteAllText(FilePath, credentialsToRemember);
                hasRemembered = true;
            }
            catch (Exception)
            {
                hasRemembered = false;
            }
            return hasRemembered;
        }
        public static bool GetStoredCredentials(ref string username, ref string password)
        {
            bool isFound = false;
            string FilePath = @"C:\DVLD-Credentials\User-Credentials.txt";
            if (!File.Exists(FilePath))
            {
               // MessageBox.Show($"File Doesn't Exist", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return isFound;
            }
            string Delim = "#///#";
            int start = 0;
            int pos = -1;
            string content = File.ReadAllText(FilePath);
            pos = content.IndexOf(Delim);
            if(pos != -1)
            {
                username = content.Substring(start, pos);
                password = content.Substring(pos + Delim.Length);
                isFound = true;
            }
            return isFound;
        }
    }
}
