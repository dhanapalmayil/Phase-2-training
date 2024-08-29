using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstate
{
    public partial class ClientViewProperties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAvailableProperties();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAvailableProperties();
        }

        private void LoadAvailableProperties()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string query = "SELECT * FROM Properties WHERE Status = 'Available'";

            if (!string.IsNullOrEmpty(txtTitle.Text) || !string.IsNullOrEmpty(txtCity.Text) || !string.IsNullOrEmpty(txtState.Text))
            {
                query += " AND (1 = 1";

                if (!string.IsNullOrEmpty(txtTitle.Text))
                {
                    query += " AND Title LIKE @Title";
                }

                if (!string.IsNullOrEmpty(txtCity.Text))
                {
                    query += " AND City LIKE @City";
                }

                if (!string.IsNullOrEmpty(txtState.Text))
                {
                    query += " AND State LIKE @State";
                }

                query += ")";
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (!string.IsNullOrEmpty(txtTitle.Text))
                    {
                        cmd.Parameters.AddWithValue("@Title", "%" + txtTitle.Text.Trim() + "%");
                    }

                    if (!string.IsNullOrEmpty(txtCity.Text))
                    {
                        cmd.Parameters.AddWithValue("@City", "%" + txtCity.Text.Trim() + "%");
                    }

                    if (!string.IsNullOrEmpty(txtState.Text))
                    {
                        cmd.Parameters.AddWithValue("@State", "%" + txtState.Text.Trim() + "%");
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        rptProperties.DataSource = dt;
                        rptProperties.DataBind();
                    }
                }
            }
        }

        protected void rptProperties_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buy" || e.CommandName == "Rent")
            {
                int propertyID = Convert.ToInt32(e.CommandArgument);
                int userID = Convert.ToInt32(Session["UserID"]);
                string action = e.CommandName;
                string status = action == "Buy" ? "Sold" : "Rented";
                string successMessage = action == "Buy" ? "Property bought successfully!" : "Property rented successfully!";

                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
                string transactionQuery = "INSERT INTO Transactions (PropertyID, ClientID, TransactionType, TransactionDate) VALUES (@PropertyID, @ClientID, @TransactionType, @TransactionDate)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Update property status
                    using (SqlCommand cmd = new SqlCommand("UPDATE Properties SET Status = @Status WHERE PropertyID = @PropertyID", con))
                    {
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@PropertyID", propertyID);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert transaction record
                    using (SqlCommand cmd = new SqlCommand(transactionQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@PropertyID", propertyID);
                        cmd.Parameters.AddWithValue("@ClientID", userID);
                        cmd.Parameters.AddWithValue("@TransactionType", action);
                        cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMessage.Text = successMessage;
                lblMessage.ForeColor = System.Drawing.Color.Green;

                // Reload available properties
                LoadAvailableProperties();
            }
        }
    }
}
