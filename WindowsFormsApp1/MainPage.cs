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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class MainPage : Form
    {
        private string username { get; set; }
        public MainPage(string username)
        {
            InitializeComponent();
            this.username = username;   
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            panel1.Dock= DockStyle.Fill;
            panel2.Dock= DockStyle.Fill;
            panel3.Dock= DockStyle.Fill;
            panel4.Dock= DockStyle.Fill;
            try
            {
                float number1=0;
                string testType = "";
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;");
                conn.Open();
                String query1 = "Select MAX(score),testname from results where username='" + username + "' group by testname";
                SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    number1 = reader.GetFloat(0);
                    testType= reader.GetString(1);
                    if (testType == "test1")
                    {
                        progressBar1.Value = (int)(number1 * 100);
                    }
                    else if (testType == "test2")
                    {
                        progressBar2.Value = (int)(number1 * 100);
                    }
                    else if (testType == "test3")
                    {
                        progressBar3.Value = (int)(number1 * 100);
                    }
                    else if (testType == "lasttest")
                    {
                        progressBar4.Value = (int)(number1 * 100);
                    }
                }
                conn.Close();
                
            }
            catch (Exception ex)
            {

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            //Kef1 kef1 = new Kef1(username);
            //kef1.Show();
            //this.Close();
            panel3.Visible = false;
            panel1.Visible = true;
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible=true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible=false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tests tests = new Tests(username, "test1");
            tests.Show();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tests tests = new Tests(username, "test2");
            tests.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tests tests = new Tests(username, "test3");
            tests.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tests tests = new Tests(username, "lasttest");
            tests.Show();
        }
    }
}
