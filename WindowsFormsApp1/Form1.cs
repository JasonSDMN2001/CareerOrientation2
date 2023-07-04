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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        String gender="";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible=false;
            panel3.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible= false;
        }

        private void button3_Click(object sender, EventArgs e)
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

                MainPage mainPage = new MainPage(textBox1.Text,"","");
                mainPage.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
            panel3.Visible=true;
            panel1.Visible=false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool bol = true;
            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Email Address cannot be blank");
                bol = false;
            }
            else if (!textBox6.Text.Contains(".") || !textBox6.Text.Contains("@"))
            {
                MessageBox.Show("Not a valid email adress");
                bol = false;
            }
            else if (textBox5.Text != textBox4.Text)
            {
                MessageBox.Show("Passwords do not match");
                bol = false;
            }
            else if (textBox4.Text.Length < 6)
            {
                MessageBox.Show("Password cannot be less than 6 chars");
                bol = false;
            }
            else if (textBox3.Text.Length < 3)
            {

                MessageBox.Show("Username cannot be less than 3 chars");
                bol = false;
            }
            if (bol)
            {
                String db = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;";
                SQLiteConnection conn = new SQLiteConnection(db);
                conn.Open();
                SQLiteCommand profileCreatecmd = new SQLiteCommand("Insert into users(username,password,email,birthdate,gender,kef1clicks,kef2clicks,kef3clicks) Values(@username,@password,@email,@birthdate,@gender,@kef1,@kef2,@kef3)", conn);
                profileCreatecmd.Parameters.AddWithValue("@username", textBox3.Text);
                profileCreatecmd.Parameters.AddWithValue("@password", textBox4.Text);
                profileCreatecmd.Parameters.AddWithValue("@email", textBox6.Text);
                profileCreatecmd.Parameters.AddWithValue("@birthdate", dateTimePicker1.Text);
                profileCreatecmd.Parameters.AddWithValue("@gender", gender);
                profileCreatecmd.Parameters.AddWithValue("@kef1", 0);
                profileCreatecmd.Parameters.AddWithValue("@kef2", 0);
                profileCreatecmd.Parameters.AddWithValue("@kef3", 0);
                profileCreatecmd.ExecuteNonQuery();
                conn.Close();
                panel2.Visible = false;
                panel3.Visible = true;
                panel1.Visible = false;
            }
        }


        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
