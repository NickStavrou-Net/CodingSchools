using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace SQLConsoleApp
{
    class Program
    {
        static readonly string connectionstring = @"Server=DESKTOP-6VLMGU5\SQLEXPRESS;Initial Catalog=AdoDB;Trusted_Connection=True;";
        static readonly SqlConnection sqlConnection = new SqlConnection(connectionstring);

        static void Main(string[] args)
        {
            //string connString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;

            using (sqlConnection)
            //using(SqlConnection connection = new SqlConnection(connString))
            {
                try
                {
                    //todo parameterized queries
                    sqlConnection.Open();

                    ////Insert User
                    Console.WriteLine("Enter Username and Password: ");
                    string userName = Console.ReadLine();
                    string password = Console.ReadLine();

                    SqlCommand cmdInsert = new SqlCommand($"INSERT INTO UsersDetails(UserName, Password) " +
                        $"VALUES('{userName}', '{password}')", sqlConnection);

                    int insertedRows = cmdInsert.ExecuteNonQuery();//<------edo ksekinaei na rotaei tin Database 
                    if (insertedRows > 0)
                    {
                        Console.WriteLine("Insertion Succeful");
                        Console.WriteLine($"{insertedRows} rows inserted succesfully");
                    }

                    //Select
                    //SqlCommand cmdSelect = new SqlCommand("SELECT COUNT (*) FROM UsersDetails " +
                    //    "WHERE Username = @username AND Password = @password", sqlConnection);

                    //cmdSelect.Parameters.AddWithValue("@username", "nick");
                    //cmdSelect.Parameters.AddWithValue("@password", "123");

                    //int result = (int)cmdSelect.ExecuteScalar();//<----------to kano CAST ston integer eauto tou
                    //if (result > 0)
                    //{
                    //    Console.WriteLine("Found User");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("User not Found");
                    //}

                    ////login
                    //Console.WriteLine("Enter Usernmame and Password to Login: ");
                    //string usernameInserted = Console.ReadLine();
                    //string passwordInserted = Console.ReadLine();

                    //SqlCommand cmdLogin = new SqlCommand($"SELECT ID, Username, Password FROM UsersDetails " +
                    //    $"WHERE Username ='{usernameInserted}' AND Password = '{passwordInserted}'", sqlConnection);

                    //SqlDataReader reader = cmdLogin.ExecuteReader();//<----arxikopoiisi antikeimenou kai me me mia method pou epistrefei object
                    //while (reader.Read())
                    //{
                    //    Console.WriteLine("User Logged In Sucessfully");
                    //    //Create a User Object
                    //    User user = new User
                    //    {
                    //        ID = reader.GetInt32(0),
                    //        Username = reader.GetString(1),
                    //        Password = reader.GetString(2)
                    //    };

                    //    Console.Write(user);
                    //}
                    ////readers MUST close
                    //reader.Close();

                    //Select multiple Users
                    //SqlCommand cmdUsers = new SqlCommand("SELECT ID, Username, Password FROM UsersDetails", sqlConnection);
                    //SqlDataReader readerUsers = cmdUsers.ExecuteReader();

                    //List<User> users = new List<User>();

                    //Console.WriteLine("Users: ");
                    //while (readerUsers.Read())
                    //{
                    //    User user = new User
                    //    {
                    //        ID = readerUsers.GetInt32(0),
                    //        Username = readerUsers.GetString(1),
                    //        Password = readerUsers.GetString(2)
                    //    };
                    //    users.Add(user);
                    //}

                    ////READER MUST CLOSE
                    //readerUsers.Close();

                    //foreach (User user in users)
                    //{
                    //    Console.WriteLine(user);
                    //}

                    //Update
                    //Console.WriteLine("Enter a Username for Update: ");
                    //string usernameForUpdate = Console.ReadLine();

                    //Console.WriteLine("Enter a New password for User: ");
                    //string newPassword = Console.ReadLine();

                    //SqlCommand cmdUpdate = new SqlCommand($"UPDATE FROM UsersDetails SET Password = '{newPassword}' " +
                    //    $"WHERE Username = '{usernameForUpdate}'", sqlConnection);

                    //int rowsUpdated = cmdUpdate.ExecuteNonQuery();
                    //if (rowsUpdated > 0)
                    //{
                    //    Console.WriteLine("Updated Successfully.");
                    //    Console.WriteLine($"{rowsUpdated} rows updated succefully.");
                    //}

                    //Delete
                    //Console.WriteLine("Enter Username to Delete");
                    //string userToDelete = Console.ReadLine();

                    //SqlCommand cmdDelete = new SqlCommand($"DELETE FROM UsersDetails WHERE Username = '{userToDelete}'", sqlConnection);

                    //int rowsDeleted = cmdDelete.ExecuteNonQuery();
                    //if (rowsDeleted > 0)
                    //{
                    //    Console.WriteLine("Deleted Succefully");
                    //    Console.WriteLine($"{rowsDeleted} rows deleted successfully.");
                    //}



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                    Console.WriteLine("SqlConnection closed");
                }
            }
        }
    }
}
