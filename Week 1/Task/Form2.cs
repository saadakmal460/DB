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

namespace Task
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE RegestrationNumber = @RegestrationNumber", con);
            cmd.Parameters.AddWithValue("@RegestrationNumber", textBox1.Text);

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

