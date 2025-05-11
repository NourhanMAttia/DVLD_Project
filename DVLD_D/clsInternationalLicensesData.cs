using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace DVLD_D
{
    public class clsInternationalLicensesData
    {
        public static bool GetInternationalLicenseInfoByID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID, 
                                                           ref int IssuedUsingLocalLicenseID, ref int CreatedByUSerID, 
                                                           ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses InternationalLicenseID=@InternationalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUSerID = (int)reader["CreatedByUSerID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();

            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static DataTable GetInternationalLicensesPerDriver(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                             InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID,
                             LicenseClasses.ClassName, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate,
                             InternationalLicenses.IsActive 
                             FROM InternationalLicenses INNER JOIN LocalDrivingLicenseApplications
                             ON InternationalLicenses.IssuedUsingLocalLicenseID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             INNER JOIN LicenseClasses ON
                             LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID
                             WHERE InternationalLicenses.DriverID=@DriverID
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
        public static bool GetLastActiveInternationalLicense(ref int InternationalLicenseID, ref int ApplicationID, int DriverID,
                                                           ref int IssuedUsingLocalLicenseID, ref int CreatedByUSerID,
                                                           ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM InternationalLicenses WHERE DriverID=@DriverID AND IsActive = 1
                             ORDER BY InternationalLicenseID DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    CreatedByUSerID = (int)reader["CreatedByUSerID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                }
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static int AddNewInternationalLicense(int ApplicationID,  int DriverID,
                                                           int IssuedUsingLocalLicenseID, int CreatedByUSerID,
                                                           DateTime IssueDate, DateTime ExpirationDate, bool IsActive)
        {
            int licenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO InternationalLicenses
                             (ApplicationID, DriverID, IssuedUsingLocalLicenseID, CreatedByUserID, IssueDate, ExpirationDate, IsActive)
                             VALUES
                             (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @CreatedByUserID, @IssueDate, @ExpirationDate, @IsActive);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@CreatedByUSerID", CreatedByUSerID);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int id))
                    licenseID = id;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return licenseID;
        }
        public static bool IsLicenseActive(int InternationalLicenseID)
        {
            bool isActive = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT FOUND=1 FROM InternationalLicenses WHERE InternationalLicenseID=@InternationalLicenseID AND IsActive =1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                isActive = (res != null);
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return isActive;
        }
    }
}
