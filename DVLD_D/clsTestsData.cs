using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_D
{
    public class clsTestsData
    {
        public static DataTable GetAllTests()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Tests";
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
        public static bool GetTestInfoByID(int TestID, ref int TestAppointmentID, ref bool TestResult, ref string Notes,
                                           ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM TESTS WHERE TestID=@TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];

                    Notes = (string)reader["Notes"];
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
        public static bool GetLastTestByPersonAndTestTypeAndLicenseClass(int PersonID, int TestTypeID, int LicenseClassID, 
                                                                     ref int TestID, ref int TestAppointmentID, ref bool TestResult,
                                                                     ref string Notes, ref int CreatedByUserID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT  top 1 Tests.TestID, 
                             Tests.TestAppointmentID, Tests.TestResult, 
			                 Tests.Notes, Tests.CreatedByUserID, Applications.ApplicantPersonID
                             FROM 
                             LocalDrivingLicenseApplications INNER JOIN Tests INNER JOIN TestAppointments 
                             ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID 
                             ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                             INNER JOIN Applications 
                             ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
                             WHERE (Applications.ApplicantPersonID = @PersonID) 
                             AND (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID)
                             AND ( TestAppointments.TestTypeID=@TestTypeID)
                             ORDER BY Tests.TestAppointmentID DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    TestID = (int)reader["TestID"];
                    TestAppointmentID = (int)reader["TestAppointmentID"];
                    TestResult = (bool)reader["TestResult"];
                    Notes = (string)reader["Notes"];
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
        public static int AddNewTest(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int testID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TESTS
                             (TestAppointmentID, TestResults, Notes, CreatedByUserID)
                             VALUES
                             (@TestAppointmentID, @TestResults, @Notes, @CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int id))
                    testID = id;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return testID;
        }
        public static bool UpdateTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE TESTS 
                             SET 
                             TestAppointmentID=@TestAppointmentID, TestResults=@TestResults, Notes=@Notes, CreatedByUserID=@CreatedByUserID
                             WHERE TestID=@TestID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestID", TestID);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
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
        public static byte GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            byte passedTestCount = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT passedTestCount = COUNT(TestTypeID)
                             FROM Tests INNER JOIN TestAppointments ON
                             Tests.TestAppointmentID = TestAppointments.TestAppointmentID
                             WHERE LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID AND TestResult=1";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int count))
                    passedTestCount = (byte)count;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return passedTestCount;
        }
    }
}
