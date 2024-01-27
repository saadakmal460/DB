using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Home_Task
{
    public partial class Courses : Form
    {
        public Courses()
        {
            InitializeComponent();
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Course values (@Name, @Code)", con);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Code", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            LoadData();
        }



        private void LoadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Course", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                textBox1.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Code"].Value.ToString();


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            string name = selectedRow.Cells["Name"].Value.ToString();
            var con = Configuration.getInstance().getConnection();


            SqlCommand cmd = new SqlCommand("UPDATE Course SET Name = @NewName, Code = @NewCode WHERE Name = @OldName", con);
            cmd.Parameters.AddWithValue("@OldName", name);
            cmd.Parameters.AddWithValue("@NewName", textBox1.Text);
            cmd.Parameters.AddWithValue("@NewCode", textBox2.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully");
            LoadData();

        }



        private void DeleteRecord(string name)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Course WHERE Name = @Name", con);
            cmd.Parameters.AddWithValue("@Name", name);


            cmd.ExecuteNonQuery();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string name = selectedRow.Cells["Name"].Value.ToString();


                DeleteRecord(name);


                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE Code = @Code", con);
            cmd.Parameters.AddWithValue("@Code", textBox2.Text);

            //con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dataTable = new DataTable();
            dataTable.Load(reader);



            if (dataTable.Rows.Count > 0)
            {
                // Display data in the DataGridView
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No data found for the specified registration number.");
            }
        }
    }
}
