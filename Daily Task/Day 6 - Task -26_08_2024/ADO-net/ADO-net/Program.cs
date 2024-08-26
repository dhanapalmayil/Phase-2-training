using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace ADO_net
{
    class Program
    {
        static SqlConnection connection = null;
        static void Main(string[] args)
        {
            getConn();
            PerformQuery();
            Console.ReadKey();
        }
        static void getConn()
        {
            connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
        }

        static void PerformQuery()
        {
            SqlCommand sqlcd = new SqlCommand("select * from Product", connection);
            
          // Initialize the data adapter with the command
    SqlDataAdapter sda = new SqlDataAdapter(sqlcd);

    // Create a DataTable to hold the result set
    DataTable dt = new DataTable();

    // Fill the DataTable with the result set from the data adapter
    sda.Fill(dt);

    // Loop through the rows in the DataTable and display the result
    foreach (DataRow row in dt.Rows)
    {
        Console.WriteLine(row[0].ToString() + " " + row[1].ToString());
    }

    // Close the connection
    connection.Close();
        }


    }
}
