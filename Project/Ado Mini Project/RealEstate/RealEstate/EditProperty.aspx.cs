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

namespace RealEstate
{
    public partial class EditProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int propertyId;  // Declare the variable outside
                if (int.TryParse(Request.QueryString["id"], out propertyId))
                {
                    LoadProperty(propertyId);
                }
            }
        }

        private void LoadProperty(int propertyId)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Properties WHERE PropertyID = @PropertyID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PropertyID", propertyId);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTitle.Text = reader["Title"].ToString();
                        txtDescription.Text = reader["Description"].ToString();
                        txtPrice.Text = reader["Price"].ToString();
                        txtAddress.Text = reader["Address"].ToString();
                        txtCity.Text = reader["City"].ToString();
                        txtState.Text = reader["State"].ToString();
                        txtZipCode.Text = reader["ZipCode"].ToString();
                        // Assuming there's a field to display current image if needed.
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string uploadedImagePath = string.Empty; // Use a different variable name to avoid conflicts

            if (fuImage.HasFile)
            {
                // Handle file upload
                string fileName = Path.GetFileName(fuImage.PostedFile.FileName);
                uploadedImagePath = "/Images/" + fileName;
                string physicalPath = Server.MapPath(uploadedImagePath); // Convert virtual path to physical path
                fuImage.SaveAs(physicalPath);
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Properties SET Title = @Title, Description = @Description, Price = @Price, " +
                               "Address = @Address, City = @City, State = @State, ZipCode = @ZipCode, " +
                               "ImagePath = @ImagePath WHERE PropertyID = @PropertyID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@State", txtState.Text);
                    cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
                    cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(uploadedImagePath) ? DBNull.Value : (object)uploadedImagePath);
                    cmd.Parameters.AddWithValue("@PropertyID", Request.QueryString["id"]);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            lblMessage.Text = "Property updated successfully!";
            Response.Redirect("UpdateDeleteProperties.aspx");
        }
    }
}
