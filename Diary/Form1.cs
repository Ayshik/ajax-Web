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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=desktop-st7ve7g;Initial Catalog=Diary;Integrated Security=True");

            string query = "Select * from LoginDiary Where UserName = '" + textBox1.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "'";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(query,sqlcon);
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                UserPanel up = new UserPanel();
                this.Visible = false;
                up.Visible = true;
            }
            else
            { MessageBox.Show("Check your UserId and Password"); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
