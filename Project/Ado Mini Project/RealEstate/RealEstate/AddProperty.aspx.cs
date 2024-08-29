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
    public partial class AddProperty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            string uploadedImagePath = string.Empty;

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
                string query = "INSERT INTO Properties (Title, Description, Price, Address, City, State, ZipCode, ImagePath, Status) " +
                               "VALUES (@Title, @Description, @Price, @Address, @City, @State, @ZipCode, @ImagePath, 'Available')";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Price", Convert.ToInt32(txtPrice.Text));
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@City", txtCity.Text);
                    cmd.Parameters.AddWithValue("@State", txtState.Text);
                    cmd.Parameters.AddWithValue("@ZipCode", txtZipCode.Text);
                    cmd.Parameters.AddWithValue("@ImagePath", uploadedImagePath);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            lblMessage.Text = "Property added successfully!";
        }
    }
}