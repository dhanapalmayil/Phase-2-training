using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.IO; 
using System.Configuration;




namespace RealEstate
{
    public partial class _UpdateDeleteProperties : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProperties();
            }
        }

        private void BindProperties()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT PropertyID, Title, Description, Price, Address, City, State, ZipCode, ImagePath FROM Properties";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvProperties.DataSource = dt;
                gvProperties.DataBind();
            }
        }

        protected void gvProperties_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int propertyId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditProperty.aspx?id=" + propertyId);
            }
            else if (e.CommandName == "Delete")
            {
                int propertyId = Convert.ToInt32(e.CommandArgument);
                DeleteProperty(propertyId);
                return;
                BindProperties();
            }
        }
        protected void btndelete(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int propertyId = Convert.ToInt32(btnDelete.CommandArgument);

            DeleteProperty(propertyId);
            BindProperties();
        }


        private void DeleteProperty(int propertyId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Properties WHERE PropertyID = @PropertyID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PropertyID", propertyId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

     }
 }
