using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace DVLD_D
{
    public class clsLicensesData
    {
        public static DataTable GetAllLicenses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Licenses";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetLicenseInfoByID(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
            ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Licenses WHERE LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (string)reader["Notes"];
                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];
                    IssueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
        public static bool GetLicenseInfoByApplicationID(int ApplicationID, ref int LicenseID, ref int DriverID, ref int LicenseClass,
                                                         ref DateTime IssueDate, ref DateTime ExpirationDate, ref string Notes,
                                                         ref float PaidFees, ref bool IsActive, ref byte IssueReason, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Licenses WHERE ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LicenseID = (int)reader["LicenseID"];
                    DriverID = (int)reader["DriverID"];

                    LicenseClass = (int)reader["LicenseClass"];
                    IssueDate = (DateTime)reader["IssueDate"];

                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    Notes = (string)reader["Notes"];

                    PaidFees = Convert.ToSingle(reader["PaidFees"]);
                    IsActive = (bool)reader["IsActive"];

                    IssueReason = Convert.ToByte(reader["IssueReason"]);
                    CreatedByUserID = (int)reader["CreatedByUserID"];
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
        public static DataTable GetDriverLicenses(int DriverID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT     
                           Licenses.LicenseID, ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN LicenseClasses 
                           ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                           WHERE DriverID=@DriverID
                           ORDER BY IsActive DESC, ExpirationDate DESC";
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
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate,
                                        string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int LicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Licenses
                             (ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID)
                             VALUES
                             (@ApplicationID, @DriverID, @LicenseClass, @IssueDate, @ExpirationDate, @Notes, @PaidFees, @IsActive, @IssueReason, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int id))
                    LicenseID = id;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return LicenseID;
        }
        public static bool UpdateLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, 
            DateTime ExpirationDate, string Notes, float PaidFees, bool IsActive, byte IssueReason, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Licenses 
                             SET ApplicationID=@ApplicationID, DriverID=@DriverID, LicenseClass=@LicenseClass, IssueDate=@IssueDate, 
                                 ExpirationDate=@ExpirationDate, Notes=@Notes, PaidFees=@PaidFees, IsActive=@IsActive, IssueReason=@IssueReason,
                                 CreatedByUserID=@CreatedByUserID
                             WHERE LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);

            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);

            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@Notes", Notes);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DeactivateLicense(int LicenseID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Licenses
                             SET IsActive=0
                             WHERE LicenseID=@LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }
        public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int ActiveLicenseID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Licenses.LicenseID FROM
                             Licenses INNER JOIN Drivers ON
                             Licenses.DriverID = Drivers.DriverID
                             WHERE Drivers.PersonID=@PersonID, Licenses.LicenseClassID=@LicenseClassID, IsActive=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int id))
                    ActiveLicenseID = id;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return ActiveLicenseID;
        }
        public static bool DoesLicenseExistForPersonID(int PersonID, int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM 
                             Licenses INNER JOIN Drivers ON
                             Licenses.DriverID = Drivers.DriverID
                             WHERE Drivers.PersonID=@PersonID, Licenses.LicenseClassID=@LicenseClassID, IsActive=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
    }
}
