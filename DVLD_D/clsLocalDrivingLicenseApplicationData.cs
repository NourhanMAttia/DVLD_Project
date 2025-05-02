using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace DVLD_D
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static DataTable GetAllApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications_View ORDER BY ApplicationDate DESC";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByLocalApplicationID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID=@ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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

        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SET NOCOUNT ON;
                             INSERT INTO LocalDrivingLicenseApplications
                             (ApplicationID, LicenseClassID)
                             VALUES
                             (@ApplicationID, @LicenseClassID);
                             SELECT CAST(SCOPE_IDENTITY() AS INT);";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int ID))
                    LocalDrivingLicenseApplicationID = ID;
            }
            catch (SqlException e) 
            {
                Debug.WriteLine("SQL error: " + e.Message);
                throw;  
            }
            finally
            {
                connection.Close();
            }
            return LocalDrivingLicenseApplicationID;
        }
        public static bool UpdateLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LocalDrivingLicenseApplications
                             SET 
                             ApplicationID=@ApplicationID, LicenseClassID=@LicenseClassID
                             WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicaitonID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
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
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
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

        public bool HasPassedTestByTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool hasPassed = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Tests 
                             INNER JOIN TestAppointments ON
                             Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             INNER JOIN LocalDrivingLicenseApplications ON
                             TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
                             WHERE TestResult=1 AND TestAppointments.TestTypeID = @TestTypeID AND
                             LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int result))
                    hasPassed = result == 0 ? false : true;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return hasPassed;
        }
        public bool HasAttendedTestByTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool hasAttended = false;

            return hasAttended;
        }
        public byte GetTotalTrialsPerTest(int TestType)
        {
            byte trials = 0;

            return trials;
        }
        public bool HasPassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            bool hasPassedAllTests = false;

            return hasPassedAllTests;
        }
        public int IssueLicenseForFirstTime()
        {
            return 0;
        }
        public bool IsLicenseIssued()
        {
            return false;
        }
        public int GetActiveLicenseID()
        {
            return 0;
        }
    }
}