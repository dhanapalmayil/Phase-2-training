using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace RealEstate
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty; 
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string userType = GetUserType();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username and password are required.";
                return;
            }

            if (string.IsNullOrEmpty(userType))
            {
                lblMessage.Text = "Please select either 'Agent' or 'Client'.";
                return;
            }

            if (UsernameExists(username))
            {
                lblMessage.Text = "Username already exists.";
                return;
            }

            if (RegisterUser(username, password, userType))
            {
                lblMessage.Text = "Registration successful.";
            }
            else
            {
                lblMessage.Text = "Registration failed. Please try again.";
            }
        }

        private string GetUserType()
        {
            if (rbAgent.Checked)
                return "Agent";
            if (rbClient.Checked)
                return "Client";
            return string.Empty;
        }

        private bool UsernameExists(string username)
        {
            bool exists = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    con.Open();
                    int userCount = Convert.ToInt32(cmd.ExecuteScalar());

                    if (userCount > 0)
                    {
                        exists = true;
                    }
                }
            }

            return exists;
        }

        private bool RegisterUser(string username, string password, string userType)
        {
            bool isRegistered = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Password, UserType) VALUES (@Username, @Password, @UserType)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); 
                    cmd.Parameters.AddWithValue("@UserType", userType);

                    con.Open();
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            isRegistered = true;
                        }
                    }
                    catch (SqlException ex)
                    {
                        
                        lblMessage.Text = "An error occurred: " + ex.Message;
                    }
                }
            }

            return isRegistered;
        }
    }
}
