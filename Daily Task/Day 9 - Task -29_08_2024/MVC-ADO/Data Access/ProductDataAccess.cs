using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MVC_ADO.Models;
using System.Data.SqlClient;

namespace MVC_ADO.Data_Access
{
    public class ProductDataAccess
    {
        static SqlConnection connection = null;
        static SqlCommand sqlcd;
      
        static void getConn()
        {
            connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true;TrustServerCertificate=True;");
            connection.Open();
        }

        public List<ProductModel> Fetch()
        {
            getConn();
            List<ProductModel> list = new List<ProductModel>();
            string s1 = "select * from Product";
            SqlCommand sel = new SqlCommand(s1, connection);
            SqlDataReader sdr = sel.ExecuteReader();
            while (sdr.Read())
            {
                list.Add(new ProductModel() { ProId = Convert.ToInt32(sdr[0]), ProName = sdr[1].ToString() });
            }
            connection.Close();
            return list;
        }
        public ProductModel Search(int id)
        {
            getConn();
            ProductModel pd = new ProductModel();
            string s1 = "select * from Product where ProId ="+id;
            SqlCommand sel = new SqlCommand(s1, connection);
            SqlDataReader sdr = sel.ExecuteReader();
            while (sdr.Read())
            {
                pd.ProId = (int)sdr[0];
                pd.ProName = sdr[1].ToString();
            }
            connection.Close();
            return pd;
        }


        public ProductModel insert(ProductModel pro)
        {
            getConn();
               sqlcd = new SqlCommand("Insert into Product values(@id,@name)", connection);
                sqlcd.Parameters.AddWithValue("@id", pro.ProId);
                sqlcd.Parameters.AddWithValue("@name", pro.ProName);
                sqlcd.ExecuteNonQuery();
        
            connection.Close();
            return pro;
        }
        public ProductModel update(ProductModel pro)
        {
            getConn();
            sqlcd = new SqlCommand("Update Product set ProName=@name where ProId=@id", connection);
            sqlcd.Parameters.AddWithValue("@id", pro.ProId);
            sqlcd.Parameters.AddWithValue("@name", pro.ProName);
            sqlcd.ExecuteNonQuery();

            connection.Close();
            return pro;
        }
       
        public void delete(int id)
        {
            getConn();

           

            sqlcd = new SqlCommand("Delete from Product where ProId=@id", connection);
            sqlcd.Parameters.AddWithValue("@id", id);
            sqlcd.ExecuteNonQuery();

            connection.Close();
        }
    }
}
