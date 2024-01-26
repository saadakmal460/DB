using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Xml.Linq;

namespace Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Insert into Student values (@RegestrationNumber, @Name,@Department,@Session,@CGPA,@Address)", con);
            cmd.Parameters.AddWithValue("@RegestrationNumber", textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Department", textBox3.Text);
            cmd.Parameters.AddWithValue("@Session", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@CGPA", float.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Successfully saved");
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadData()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Get the changed data
            DataGridViewRow updatedRow = dataGridView1.Rows[e.RowIndex];

            string registrationNumber = updatedRow.Cells["RegestrationNumber"].Value.ToString();
            string name = updatedRow.Cells["Name"].Value.ToString();
            string department = updatedRow.Cells["Department"].Value.ToString();
            int session = Convert.ToInt32(updatedRow.Cells["Session"].Value);
            float cgpa = Convert.ToSingle(updatedRow.Cells["CGPA"].Value);
            string address = updatedRow.Cells["Adress"].Value.ToString();

            // Update the database
            UpdateDatabase(registrationNumber, name, department, session, cgpa, address);
        }

        private void UpdateDatabase(string registrationNumber, string name, string department, int session, float cgpa, string address)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET Name = @Name, Department = @Department, Session = @Session, CGPA = @CGPA, Adress = @Adress WHERE RegestrationNumber = @RegestrationNumber", con);
            cmd.Parameters.AddWithValue("@RegestrationNumber", registrationNumber);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Department", department);
            cmd.Parameters.AddWithValue("@Session", session);
            cmd.Parameters.AddWithValue("@CGPA", cgpa);
            cmd.Parameters.AddWithValue("@Adress", address);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {


            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET Name = @Name, Department = @Department, Session = @Session, CGPA = @CGPA, Address = @Address WHERE RegestrationNumber = @RegestrationNumber", con);
            cmd.Parameters.AddWithValue("@RegestrationNumber", textBox1.Text);
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Department", textBox3.Text);
            cmd.Parameters.AddWithValue("@Session", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@CGPA", float.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@Address", textBox6.Text);


            cmd.ExecuteNonQuery();
            MessageBox.Show("Updated Successfully");
            LoadData();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string registrationNumber = selectedRow.Cells["RegestrationNumber"].Value.ToString();


                DeleteRecord(registrationNumber);


                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void DeleteRecord(string registrationNumber)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegestrationNumber = @RegestrationNumber", con);
            cmd.Parameters.AddWithValue("@RegestrationNumber", registrationNumber);


            cmd.ExecuteNonQuery();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                textBox1.Text = selectedRow.Cells["RegestrationNumber"].Value.ToString();
                textBox2.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox3.Text = selectedRow.Cells["Department"].Value.ToString();
                textBox4.Text = selectedRow.Cells["Session"].Value.ToString();
                textBox5.Text = selectedRow.Cells["CGPA"].Value.ToString();
                textBox6.Text = selectedRow.Cells["Address"].Value.ToString();

            }
        }
    }
}