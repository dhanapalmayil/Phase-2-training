using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace Ado___windows_app
{
    public partial class dep : Form
    {
        static SqlCommand sqlcd;
        public dep()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            string s1 = "select * from Product";
            SqlCommand sel = new SqlCommand(s1, connection);
            SqlDataReader sdr = sel.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            int id = Convert.ToInt32(empid.Text);
            sqlcd = new SqlCommand("select * from AdoWin where EmpId=@id", connection);
            sqlcd.Parameters.AddWithValue("@id", id);
            SqlDataReader sdr = sqlcd.ExecuteReader();
           
            while (sdr.Read())
            {
                empname.Text = sdr[1].ToString();
                dep_text.Text = sdr[2].ToString();
            }
           
            
           
        }
        
        private void btn_Display_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            string s1 = "select * from AdoWin";
            SqlCommand sel = new SqlCommand(s1, connection);
            SqlDataReader sdr = sel.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            int id =Convert.ToInt32( empid.Text);
            string name = empname.Text;
            string dep = dep_text.Text;
            sqlcd = new SqlCommand("Insert into AdoWin values(@id,@name,@Dep)", connection);
            sqlcd.Parameters.AddWithValue("@id", id);
            sqlcd.Parameters.AddWithValue("@name", name);
            sqlcd.Parameters.AddWithValue("@Dep", dep);
            sqlcd.ExecuteNonQuery();
            MessageBox.Show("Inserted succesfully");
            btn_Display_Click(null, null);
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            string s1 = "select * from AdoWin";
            SqlCommand sel = new SqlCommand(s1, connection);
            SqlDataReader sdr = sel.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
        }

        private void button_Upd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            int id = Convert.ToInt32(empid.Text);
            string name = empname.Text;
            string dep = dep_text.Text;
            sqlcd = new SqlCommand("Update AdoWin set EmpName=@name,Dep=@dep where Empid=@id", connection);
            sqlcd.Parameters.AddWithValue("@id", id);
            sqlcd.Parameters.AddWithValue("@name", name);
            sqlcd.Parameters.AddWithValue("@Dep", dep);
            sqlcd.ExecuteNonQuery();
            MessageBox.Show("Updated succesfully");
            btn_Display_Click(null, null);

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
          
            string idcheck = empid.Text;
            string name = empname.Text;
            string dep = dep_text.Text;
           
            if (!idcheck.Equals(""))
            {
                int id = Convert.ToInt32(empid.Text);
                sqlcd = new SqlCommand("Delete from AdoWin where Empid=@id", connection);
                sqlcd.Parameters.AddWithValue("@id", id);
                sqlcd.ExecuteNonQuery();
                MessageBox.Show("Deleted succesfully based on Id");
                btn_Display_Click(null, null);
                return;
            }
            if (!name.Equals(""))
            {
                sqlcd = new SqlCommand("Delete from AdoWin where EmpName=@name", connection);
                sqlcd.Parameters.AddWithValue("@name", name);
                sqlcd.ExecuteNonQuery();
                MessageBox.Show("Deleted succesfully as per Name of Employee");
                btn_Display_Click(null, null);
                return;
            }
            if (!dep.Equals(""))
            {
                sqlcd = new SqlCommand("Delete from AdoWin where Dep=@dep", connection);
                sqlcd.Parameters.AddWithValue("@dep", dep);
                sqlcd.ExecuteNonQuery();
                MessageBox.Show("Deleted succesfully as per Department");
                btn_Display_Click(null, null);
                return;
            }
            
            

            
        }

        private void Count_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("data source = PTSQLTESTDB01 ; database = Sports_dhanapal ; integrated security = true");
            connection.Open();
            
            sqlcd = new SqlCommand("Select count(*) from AdoWin", connection);
            //SqlDataReader sdr = sqlcd.ExecuteReader();
            int value=Convert.ToInt32(sqlcd.ExecuteScalar());
            lbl_count.Text = "Total Employees count = "+value.ToString();
           
        }

        private void empid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
