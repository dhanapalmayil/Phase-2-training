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
        static SqlCommand sqlcd;
        static void Main(string[] args)
        {
            getConn();
            string repeat = "Yes";
            while (repeat.ToLower().Equals("yes"))
            {
                Console.WriteLine("Enter the value \n1)Insert \n2)Update \n3)Delete \n4)Show all data's");
                int id = Convert.ToInt32(Console.ReadLine());
                if (id == 1)
                {
                    insert();
                }
                else if (id == 2)
                {
                    update();
                }
                else if (id == 3)
                {
                    delete();
                }
                else if (id == 4)
                {
                    Fetch();
                }
                Console.WriteLine("Do you want to continue?\nYes (or) No");
                repeat = Console.ReadLine();
               
            }

        }
        static void getConn()
        {
            connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
        }

        static void Fetch()
        {
            getConn();

            
            string s1 = "select * from Product";
            SqlCommand sel = new SqlCommand(s1, connection);
            SqlDataReader sdr = sel.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine(sdr[0].ToString() + "  " + sdr[1].ToString());
            }
            connection.Close();
            
        }

      
        static void insert()
        {
            getConn();
            Console.WriteLine("Enter how many values you need to insert");
            int value = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < value; i++)
            {
                Console.WriteLine("Enter the Id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name of Product ");
                string name = Console.ReadLine();
                sqlcd = new SqlCommand("Insert into Product values(@id,@name)", connection);
                sqlcd.Parameters.AddWithValue("@id", id);
                sqlcd.Parameters.AddWithValue("@name", name);
                sqlcd.ExecuteNonQuery();
                Console.WriteLine("Values Inserted as Id={0} and ProductName={1}",id,name);
            }
            Console.WriteLine("All values Inserted Successfully");
            connection.Close();
        }
        static void update()
        {
            getConn();
            
                Console.WriteLine("Enter the Id to update ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Name of Product to change for that id");
                string name = Console.ReadLine();
                sqlcd = new SqlCommand("Update Product set ProName=@name where ProId=@id", connection);
                sqlcd.Parameters.AddWithValue("@id", id);
                sqlcd.Parameters.AddWithValue("@name", name);
                sqlcd.ExecuteNonQuery();
                Console.WriteLine("Updated Successfully");
            
            connection.Close();
        }
        static void delete()
        {
            getConn();

            Console.WriteLine("Enter the Id to Delete");
            int id = Convert.ToInt32(Console.ReadLine());        
            sqlcd = new SqlCommand("Delete from Product where ProId=@id", connection);
            sqlcd.Parameters.AddWithValue("@id", id);   
            sqlcd.ExecuteNonQuery();
            Console.WriteLine("Deleted Successfully");

            connection.Close();
        }
        


    }
}
