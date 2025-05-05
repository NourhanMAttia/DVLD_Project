using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_D
{
    public class clsDetainedLicensesData
    {
        public static bool IsLicenseDetained(int LicenseID)
        {
            bool isDetained = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM DetainedLicenses WHERE
                             LicenseID=@LicenseID AND IsReleased = 0";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int r))
                    isDetained = r > 0;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return isDetained;
        }
    }
}
