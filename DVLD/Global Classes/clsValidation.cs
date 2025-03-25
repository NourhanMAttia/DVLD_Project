using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DVLD.Global_Classes
{
    class clsValidation
    {
        public static bool IsValidEmail(string Email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(Email);
        }
        public static bool IsValidInteger(string Number)
        {
            var pattern = @"^[0-9]*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(Number);
        }
        public static bool IsValidFloat(string Number)
        {
            var pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(Number);
        }
        public static bool IsNumber(string Number)
        {
            return IsValidInteger(Number) || IsValidFloat(Number);
        }
    }
}
