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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class Register : Form
    {
        String gender;
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Form1 form= new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bol = true;
            if (textBox4.Text.Length == 0)
            {
                MessageBox.Show("Email Address cannot be blank");
                bol = false;
            }else if(!textBox4.Text.Contains(".")|| !textBox4.Text.Contains("@"))
            {
                MessageBox.Show("Not a valid email adress");
                bol= false;
            }else if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Passwords do not match");
                bol = false;
            }
            else if (textBox2.Text.Length < 6)
            {
                MessageBox.Show("Password cannot be less than 6 chars"); 
                bol = false;
            }
            else if (textBox1.Text.Length < 3)
            {

                MessageBox.Show("Username cannot be less than 3 chars");
                bol = false;
            }
            if (bol)
            {
                String db = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;";
                SQLiteConnection conn = new SQLiteConnection(db);
                conn.Open();
                SQLiteCommand profileCreatecmd = new SQLiteCommand("Insert into users(username,password,email,birthdate,gender) Values(@username,@password,@email,@birthdate,@gender)", conn);
                profileCreatecmd.Parameters.AddWithValue("@username", textBox1.Text);
                profileCreatecmd.Parameters.AddWithValue("@password", textBox2.Text);
                profileCreatecmd.Parameters.AddWithValue("@email", textBox4.Text);
                profileCreatecmd.Parameters.AddWithValue("@birthdate", dateTimePicker1.Text);
                profileCreatecmd.Parameters.AddWithValue("@gender", gender);
                profileCreatecmd.ExecuteNonQuery();
                conn.Close();
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }
    }
}
