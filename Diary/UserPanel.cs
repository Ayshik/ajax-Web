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

namespace Diary
{
    public partial class UserPanel : Form
    {
        public UserPanel()
        {            InitializeComponent();
        }
        void GridUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=desktop-st7ve7g;Initial Catalog=Diary;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT EName,EDetails,Date,Importance FROM Event");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UserPanel_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GridUpdate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D9OUHAV\SQLEXPRESS;Initial Catalog=user_mgt;Integrated Security=True");
            con.Open();
            string query = string.Format("UPDATE Event SET EName='{0}', EDetails='{1}',Date='{2}',Importance='{3}' WHERE UserId={4}", textBox2.Text, textBox3.Text, textBox4.Text,comboBox1.Text, int.Parse(textBox1.Text));
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();           
            MessageBox.Show("Update Successfully...");
            GridUpdate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D9OUHAV\SQLEXPRESS;Initial Catalog=user_mgt;Integrated Security=True");
            con.Open();
            string query = string.Format("INSERT INTO users(name,email) VALUES('{0}','{1}')", textBox1.Text, textBox2.Text);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Added Successfully...");
            GridUpdate();
            textBox1.Text = textBox2.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res.Equals(DialogResult.Yes))
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-D9OUHAV\SQLEXPRESS;Initial Catalog=user_mgt;Integrated Security=True");
                con.Open();
                string query = string.Format("DELETE FROM users WHERE id={0}", int.Parse(textBox4.Text));
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                GridUpdate();
                MessageBox.Show("Delete Successfully...");

                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
            else
            {
                GridUpdate();
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = string.Empty;
            }
        }
    }
}
