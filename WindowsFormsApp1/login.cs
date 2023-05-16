using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;");
            conn.Open();
            String query1 = "Select * from users where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            while (reader.Read())
            {
                builder.Append(reader.GetString(1) + "/").Append(reader.GetString(2));
            }
            conn.Close();
            if (builder.ToString() == "")
            {

                MessageBox.Show("Incorect username/password");
            }
            else
            {
                this.Hide();
                MainPage mainPage = new MainPage(textBox1.Text);
                mainPage.Show();
                this.Close();
            }
        }
    }
}
