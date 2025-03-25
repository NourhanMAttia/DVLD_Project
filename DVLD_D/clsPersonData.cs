using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;


namespace DVLD_D
{
    public class clsPersonData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT People.PersonID, People.NationalNo,
                             People.FirstName, People.SecondName, People.ThirdName, People.LastName,
			                 People.DateOfBirth, People.Gendor,  
				             CASE
                                 WHEN People.Gendor = 0 THEN 'Male'
                                 ELSE 'Female'
                             END as Gender ,
			                 People.Address, People.Phone, People.Email, 
                             People.NationalityCountryID, Countries.CountryName, People.ImagePath
                             FROM People INNER JOIN Countries ON 
                             People.NationalityCountryID = Countries.CountryID
                             ORDER BY People.FirstName";
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
        public static bool GetPersonInfoByID(int PersonID, ref int CountryID, ref short Gender, ref string NationalNo, ref string FirstName,
                                             ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone,
                                             ref string Address, ref string ImagePath, ref DateTime DateOfBirth)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM People WHERE PersonID=@PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["NationalityCountryID"];
                    Gender = (byte)reader["Gendor"];
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
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
        public static bool GetPersonInfoByNationalNo(ref int PersonID, ref int CountryID, ref short Gender, string NationalNo, ref string FirstName,
                                            ref string SecondName, ref string ThirdName, ref string LastName, ref string Email, ref string Phone,
                                            ref string Address, ref string ImagePath, ref DateTime DateOfBirth)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT * FROM People WHERE NationalNo=@NationalNo;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["NationalityCountryID"];
                    Gender = (byte)reader["Gendor"];
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    if (reader["ThirdName"] != DBNull.Value)
                        ThirdName = (string)reader["ThirdName"];
                    else
                        ThirdName = "";
                    LastName = (string)reader["LastName"];
                    if (reader["Email"] != DBNull.Value)
                        Email = (string)reader["Email"];
                    else
                        Email = "";
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
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
        public static int AddNewPerson(int CountryID, short Gender, string NationalNo, string FirstName,
             string SecondName, string ThirdName, string LastName, string Email, string Phone,
             string Address, string ImagePath, DateTime DateOfBirth)
        {
            // third name , email and image path can be null
            int PersonID = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"INSERT INTO People (NationalityCountryID, Gendor, NationalNo, FirstName, SecondName, ThirdName, LastName, Email, Phone, Address, ImagePath, DateOfBirth) 
                             VALUES (@CountryID, @Gender, @NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @Email, @Phone, @Address, @ImagePath, @DateOfBirth); 
                             SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            if (ThirdName == "" || ThirdName == null)
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            if (Email == "" || Email == null)
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);
            if (ImagePath == "" || ImagePath == null)
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            try
            {
                Connection.Open();
                object res = Command.ExecuteScalar();
                if (res != null && int.TryParse(res.ToString(), out int PID))
                    PersonID = PID;
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return PersonID;
        }
        public static bool UpdatePerson(int PersonID, int CountryID, short Gender, string NationalNo, string FirstName, string SecondName,
                                        string ThirdName, string LastName, string Email, string Phone, string Address, string ImagePath,
                                        DateTime DateOfBirth)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"UPDATE People 
                             SET NationalityCountryID=@CountryID,
                                 Gendor=@Gender,
                                 NationalNo=@NationalNo,
                                 FirstName=@FirstName,
                                 SecondName=@SecondName, 
                                 ThirdName=@ThirdName,
                                 LastName=@LastName,
                                 Email=@Email,
                                 Phone=@Phone,
                                 Address=@Address,
                                 ImagePath=@ImagePath,
                                 DateOfBirth=@DateOfBirth
                             WHERE PersonID = @PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CountryID", CountryID);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            if (ThirdName == "" || ThirdName == null)
                Command.Parameters.AddWithValue("@ThirdName", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            if (Email == "" || Email == null)
                Command.Parameters.AddWithValue("@Email", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Email", Email);
            if (ImagePath == "" || ImagePath == null)
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            try
            {
                Connection.Open();
                rowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool DeletePerson(int PersonID)
        {
            int rowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "DELETE People WHERE PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Connection.Open();
                rowsAffected = Command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return rowsAffected > 0;
        }
        public static bool IsPersonExist(int PersonID)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT Found=1 FROM People WHERE PersonID=@PersonID;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
        public static bool IsPersonExist(string NationalNo)
        {
            bool isFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT Found=1 FROM People WHERE NationalNo=@NationalNo;";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception) { }
            finally
            {
                Connection.Close();
            }
            return isFound;
        }
    }
}
