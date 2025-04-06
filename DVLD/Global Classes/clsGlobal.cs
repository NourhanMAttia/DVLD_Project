using DVLD_B;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Global_Classes
{
    public class clsGlobal
    {
        public static clsUser GlobalUser;
        public static bool RememberUsernameAndPassword(string username, string password)
        {
            return false;
        }
        public static bool GetStoredCredentials(ref string username, ref string password)
        {
            return false;
        }
    }
}
