using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_D
{
    public class clsDriversData
    {
        public static DataTable GetAllDrivers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Drivers.DriverID, Drivers.PersonID, People.NationalNo, 
                             FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName,
                             Drivers.CreatedDate, ActiveLicenses = (SELECT COUNT(*) FROM Licenses WHERE Licenses.DriverID = Drivers.DriverID AND Licenses.IsActive = 1)
                             FROM Drivers 
                             INNER JOIN People ON
                             People.PersonID = Drivers.PersonID";
            SqlCommand command = new SqlCommand(query, connection);
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
                Console.WriteLine("Error : " + e.Message);
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static bool GetDriverInfoByID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                }
                reader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int DriverID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Drivers 
                             (PersonID, CreatedByUserID, CreatedDate)
                             VALUES 
                             (@PersonID, @CreatedByUserID, @CreatedDate);
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int id))
                    DriverID = id;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return DriverID;
        }
        public static bool UpdateDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Drivers 
                             PersonID=@PersonID, CreatedByUserID=@CreatedByUserID, CreatedDate=@CreatedDate
                             WHERE DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DeleteDriver(int DriverID)
        {
            int rowsAffected =0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"DELETE * FROM Drivers WHERE DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DoesDriverExist(int DriverID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Found=1 FROM Drivers WHERE DriverID=@DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int r))
                    isFound = r > 0;
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
    }
}
