using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_D
{
    public class clsCountryData
    {
        public static bool GetCountryInfoByID(int CountryID, ref string CountryName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryID=@CountryID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];
                }
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static bool GetCountryInfoByName(ref int CountryID, string CountryName)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries WHERE CountryName=@CountryName;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["CountryID"];
                }
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM Countries ORDER BY CountryName;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                    dt.Load(reader);
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return dt;
        }
    }
}
