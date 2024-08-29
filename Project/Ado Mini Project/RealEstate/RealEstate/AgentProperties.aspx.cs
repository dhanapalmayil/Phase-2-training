using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace RealEstate
{
    public partial class AgentProperties : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProperties();
            }
        }

        private void LoadProperties()
        {
            // Retrieve UserID from session
            int userID = Convert.ToInt32(Session["UserID"]);

            // SQL query to fetch properties bought or rented by clients
            string query = @"
                SELECT p.PropertyID, p.Title AS PropertyTitle, u.Username AS ClientUsername, t.TransactionType, t.TransactionDate
                FROM Properties p
                JOIN Transactions t ON p.PropertyID = t.PropertyID
                JOIN Users u ON t.ClientID = u.UserID
                WHERE t.TransactionType IN ('Buy', 'Rent')";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        con.Open();
                        da.Fill(dt);
                        gvProperties.DataSource = dt;
                        gvProperties.DataBind();
                    }
                }
            }
        }
    }
}
