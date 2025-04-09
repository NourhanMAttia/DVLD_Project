using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_D
{
    public class clsApplicationTypesData
    {
        public static DataTable GetAllApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM ApplicationTypes";
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
        public static bool UpdateApplicationTypes(int ID, string Name, decimal Fees)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE ApplicationTypes
                             SET
                             ApplicationTypeTitle=@Name, ApplicationFees=@Fees
                             WHERE ApplicationTypeID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Fees", Fees);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error Message : {e.Message}");
            }
            finally
            {
                connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool FindByID(int ID, ref string Name, ref decimal Fees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT * FROM ApplicationTypes 
                             WHERE ApplicationTypeID=@ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    Name = (string)reader["ApplicationTypeTitle"];
                    Fees = (decimal)reader["ApplicationFees"];
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
    }
}
