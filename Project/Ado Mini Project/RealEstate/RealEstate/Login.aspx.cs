using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace RealEstate
{
    public partial class Login : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            int userID;
            string userType;

            bool isAuthenticated = AuthenticateUser(username, password, out userID, out userType);

            if (isAuthenticated)
            {
                
                Session["Username"] = username;
                Session["UserID"] = userID;

                if (userType == "Client")
                {
                    Response.Redirect("ClientWelcome.aspx");
                }
                else if (userType == "Agent")
                {
                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    lblMessage.Text = "Unknown user type.";
                }
            }
            else
            {
                lblMessage.Text = "Invalid username or password.";
            }
        }

        private bool AuthenticateUser(string username, string password, out int userID, out string userType)
        {
            userID = 0;
            userType = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, UserType FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userID = Convert.ToInt32(reader["UserID"]);
                            userType = reader["UserType"].ToString();
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
