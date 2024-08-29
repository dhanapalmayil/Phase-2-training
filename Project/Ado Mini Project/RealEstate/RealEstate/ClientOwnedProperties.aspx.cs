using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Data;
using System.Data.SqlClient;

namespace RealEstate
{
    public partial class ClientOwnedProperties : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadOwnedProperties();
            }
        }

        private void LoadOwnedProperties()
        {
            int userID = Convert.ToInt32(Session["UserID"]);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Properties WHERE PropertyID IN (SELECT PropertyID FROM Transactions WHERE ClientID = @ClientID)";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@ClientID", userID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvOwnedProperties.DataSource = dt;
                    gvOwnedProperties.DataBind();
                }
            }
        }
    }
}