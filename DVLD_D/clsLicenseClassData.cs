using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_D
{
    public class clsLicenseClassData
    {
        public static DataTable GetAllLicenseClasses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM LicenseClasses";
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
        public static bool GetLicenseClassByID(int ClassID, ref string ClassName, ref string ClassDescription,
                                               ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClasses
                             WHERE LicenseClassID=@ClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (float)reader["ClassFees"];
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
        public static bool GetLicenseClassByName(string ClassName, ref int ClassID, ref string ClassDescription,
                                               ref byte MinimumAllowedAge, ref byte DefaultValidityLength, ref float ClassFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM LicenseClasses
                             WHERE ClassName=@ClassName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (float)reader["ClassFees"];
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
        public static int AddNewLicenseClass(string ClassName, string ClassDescription, byte MinimumAllowedAge, 
                                             byte DefaultValidityLenght, float ClassFees)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO LicenseClasses
                             (ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLenght, ClassFees)
                             VALUES
                             (@ClassName, @ClassDescription, @MinimumAllowedAge, @DefaultValidityLenght, @ClassFees);
                             SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLenght", DefaultValidityLenght);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            try
            {
                connection.Open();
                object res = command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int id))
                    ID = id;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return ID;
        }
        public static bool UpdateLicenseClass(int ClassID, string ClassName, string ClassDescription, byte MinimumAllowedAge,
                                             byte DefaultValidityLength, float ClassFees)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE LicenseClasses
                             SET 
                             ClassName=@ClassName, ClassDescription=@ClassDescription, MinimumAllowedAge=@MinimumAllowedAge,
                             DefaultValidityLength=@DefaultValidityLength, ClassFees=@ClassFees
                             WHERE LicenseClassID=@ClassID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            command.Parameters.AddWithValue("@ClassID", ClassID);
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
    }
}
