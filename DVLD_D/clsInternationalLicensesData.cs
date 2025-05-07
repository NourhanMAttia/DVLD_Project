using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_D
{
    public class clsInternationalLicensesData
    {
        public static DataTable GetInternationalLicensesPerDriver(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                             InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID,
                             LicenseClasses.ClassName, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate,
                             InternationalLicenses.IsActive 
                             FROM InternationalLicenses INNER JOIN LocalDrivingLicenseApplications
                             ON InternationalLicenses.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             INNER JOIN LicenseClasses ON
                             LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                             WHERE DriverID=@DriverID
                             ORDER BY InternationalLicenses.InternationalLicenseID DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error When Retrieving International Driving Licenses Per Driver: {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }
}
