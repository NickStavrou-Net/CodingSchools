using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace ConsoleAppSQL
{
    class Program
    {
        //1st 
        //static readonly string connectionstring = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AdoDB;Integrated Security=True;";
        //static readonly SqlConnection connection = new SqlConnection(connectionstring);
        static async Task Main(string[] args)
        {
            string connstring = FetchConnectionStringFromJson();
            using SqlConnection connection = new SqlConnection(connstring);
            //using (connection)
            try
            {
                await connection.OpenAsync();
                #region INSERT
                //INSERT
                Console.WriteLine("Enter Username and Password: ");
                string userName = Console.ReadLine();
                string password = Console.ReadLine();

                SqlCommand cmdInsert = new SqlCommand(@"INSERT INTO UsersDetails(UserName, Password)
                                                            VALUES(@username, @password);", connection);
                //cmdInsert.Parameters.Add("@password", SqlDbType.Int).SqlValue = password;
                cmdInsert.Parameters.AddWithValue("@username", userName);//using addwithvalue because of string
                cmdInsert.Parameters.AddWithValue("@password", password);//else will use Add and specify the datatype

                int rowsInserted = await cmdInsert.ExecuteNonQueryAsync();
                if (rowsInserted > 0)
                {
                    Console.WriteLine("Insertion Succeful");
                    Console.WriteLine($"{rowsInserted} rows inserted succesfully");
                }
                #endregion
                #region SELECT
                ////SELECT
                SqlCommand cmdSelect = new SqlCommand("SELECT * FROM UsersDetails;", connection);
                using (SqlDataReader reader = await cmdSelect.ExecuteReaderAsync())
                {

                    if (reader.HasRows is true)
                    {

                        while (await reader.ReadAsync())
                        {
                            User user = new();
                            Console.WriteLine(
                                string.Format(@$"{user.Username = reader["UserName"].ToString()} 
                                                 {user.Password = reader["Password"].ToString()}"));

                        }

                        //readers MUST close
                        await reader.CloseAsync();

                    }
                    else
                    {
                        Console.WriteLine("No Results return from Database!");
                    }

                }
                #endregion
                #region UPDATE
                //UPDATE
                Console.WriteLine("Enter username: ");
                string userNameFromDB = Console.ReadLine();
                Console.WriteLine("Enter new password: ");
                string newPassword = Console.ReadLine();

                SqlCommand cmdUpdate = new SqlCommand(@$"UPDATE UsersDetails SET Password = @password
                                WHERE Username = @username;", connection);
                cmdUpdate.Parameters.AddWithValue("@password", newPassword);
                cmdUpdate.Parameters.AddWithValue("@username", userNameFromDB);

                int rowsUpdated = await cmdUpdate.ExecuteNonQueryAsync();
                if (rowsUpdated > 0)
                {
                    Console.WriteLine("Updated Successfully.");
                    Console.WriteLine($"{rowsUpdated} rows updated succefully.");
                }
                #endregion
                #region DELETE
                //DELETE
                Console.WriteLine("Enter Username to Delete");
                string userToDelete = Console.ReadLine();

                SqlCommand cmdDelete = new SqlCommand($"DELETE FROM UsersDetails WHERE Username = @userToDelete", connection);
                cmdDelete.Parameters.AddWithValue("@userToDelete", userToDelete);


                int rowsDeleted = await cmdDelete.ExecuteNonQueryAsync();
                if (rowsDeleted > 0)
                {
                    Console.WriteLine("Deleted Succefully");
                    Console.WriteLine($"{rowsDeleted} rows deleted successfully.");
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            finally
            {
                await connection.CloseAsync();
                Console.WriteLine("SqlConnection closed");
            }
        }

        private static string FetchConnectionStringFromJson()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            string connstring = config.GetConnectionString("DefaultConnection");
            return connstring;
        }
    }
}
