using System;
using System.Data.SqlClient;

namespace SQLi_Demo
{
   public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cmd_Login_Click(object sender, EventArgs e)
        {
            txt_password.Visible = false; lbl_username.Visible = false;
            txt_username.Visible = false; lbl_password.Visible = false;
            lbl_Welcome.Visible = true;
            btn_Logout.Visible = true;
            cmd_Login.Visible = false;

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Eshop;Trusted_Connection=True;";

            //string queryString = "SELECT username, password FROM users WHERE username='" + txt_username.Text + "'";

            string queryString = "SELECT username, password FROM users WHERE username=@UserName";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@UserName", txt_username.Text);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        //lbl_Welcome.Text += String.Format("\t{0}\t{1}", reader[0], reader[1]);
                        lbl_Welcome.Text += string.Format("\t{0}\n", reader[0]);
                    }
                    reader.Close();
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void btn_Logout_Click(object sender, EventArgs e)
        {
            txt_password.Visible = true; lbl_username.Visible = true;
            txt_username.Visible = true; lbl_password.Visible = true;
            lbl_Welcome.Visible = false;
            btn_Logout.Visible = false;
            lbl_Welcome.Text = "Welcome: ";
            cmd_Login.Visible = true;
        }
    }
}