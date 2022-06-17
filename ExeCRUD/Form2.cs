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

namespace ExeCRUD
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadAllRecords();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-AS5OAOK;initial Catalog=exeCRUD;User ID=sa;Password=123");
        private void button2_Click(object sender, EventArgs e)
        {
            int iddrkr = int.Parse(textBox1.Text);
            string jdldrkr = textBox2.Text, genre = textBox3.Text;
            con.Open();
            SqlCommand com = new SqlCommand("exec SP_listdrakor_Insert '" + iddrkr + "','" + jdldrkr+ "','" + genre + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved");
            LoadAllRecords();
        }
        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec SP_listdrakor_View ", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec SP_listdrakor_Update '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Update");
            LoadAllRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string iddrakorr = textBox1.Text;
            SqlCommand com = new SqlCommand("exec SP_listdrakor_Delete '" + textBox1.Text + "'" , con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Delete");
            LoadAllRecords();
        }
    }
}
