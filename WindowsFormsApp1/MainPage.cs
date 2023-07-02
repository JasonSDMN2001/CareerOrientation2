using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class MainPage : Form
    {
        private string username { get; set; }
        private string quizResults { get; set; }
        private string quizResults2 { get; set; }
        SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;");

        public MainPage(string username,string quizResults,string quizResults2)
        {
            InitializeComponent();
            this.username = username;   
            this.quizResults = quizResults;
            this.quizResults2 = quizResults2;
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            panel1.Dock= DockStyle.Fill;
            panel2.Dock= DockStyle.Fill;
            panel3.Dock= DockStyle.Fill;
            panel4.Dock= DockStyle.Fill;
            panel5.Dock= DockStyle.Fill;
            try
            {
                float number1=0;
                string testType = "";
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
                        label40.Text = progressBar1.Value + "%";
                    }
                    else if (testType == "test2")
                    {
                        progressBar2.Value = (int)(number1 * 100);
                        label42.Text = progressBar2.Value + "%";
                    }
                    else if (testType == "test3")
                    {
                        progressBar3.Value = (int)(number1 * 100);
                        label41.Text = progressBar3.Value + "%";
                    }
                    else if (testType == "lasttest")
                    {
                        progressBar4.Value = (int)(number1 * 100);
                        label38.Text = progressBar4.Value + "%";
                    }
                }
                conn.Close();
                if(progressBar1.Value>60 && progressBar2.Value > 60 && progressBar3.Value > 60)
                {
                    progressBar4.Visible = true;
                    button7.Visible= true;
                    label38.Visible=true;
                    label36.Visible = false;
                    label39.Visible=true;
                }
                if (progressBar4.Value > 60)
                {
                    button8.Visible = true;
                    label45.Visible = true;
                    label44.Visible = false;
                }
                conn.Open();
                String query2 = "Select MAX(score),importantN from results where username='" + username + "' and testname='lasttest' and importantQ='notcorrect'";
                SQLiteCommand cmd2 = new SQLiteCommand(query2, conn);
                SQLiteDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.GetInt32(1) != 0)
                    {
                        label46.Text = "Έχεις λάθος απο το τεστ: "+reader2.GetInt32(1) + ". Πρέπει να ξαναδείς το τεστ κεφαλαίου";
                    }
                    else
                    {
                        label46.Text = "";
                    }
                }
                conn.Close();
                if (quizResults != "")
                {
                    label12.Visible= true;
                    label12.Text = "Προτάσεις επαγγελμάτων σχετικές με τις προτιμήσεις και ικανότητες σου: \n" + quizResults;
                }
                if (quizResults2 != "")
                {
                    label13.Visible = true;
                    label13.Text = "Προτάσεις μεταπτυχιακών σπουδών σχετικές με τις προτιμήσεις και ικανότητες σου: \n" + quizResults2;
                }

                conn.Open();
                String query3 = "Select * from results where username='" + username + "'";
                SQLiteCommand cmd3 = new SQLiteCommand( query3, conn);
                SQLiteDataReader reader3 = cmd3.ExecuteReader();
                int rowIndex = 1;
                while (reader3.Read())
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    Label label1 = new Label();
                    label1.Text = reader3.GetString(1);
                    Label label2 = new Label();
                    label2.Text = reader3.GetFloat(2).ToString();  
                    Label label3 = new Label();
                    label3.Text = reader3.GetInt32(3).ToString();

                    tableLayoutPanel1.Controls.Add(label1, 0, rowIndex); 
                    tableLayoutPanel1.Controls.Add(label2, 1, rowIndex); 
                    tableLayoutPanel1.Controls.Add(label3, 2, rowIndex);
                    

                    rowIndex++;
                }
                tableLayoutPanel1.RowCount = rowIndex;

                conn.Close();
                conn.Open();
                String query4 = "Select kef1clicks,kef2clicks,kef3clicks from users where username='" + username + "'";
                SQLiteCommand cmd4 = new SQLiteCommand(query4, conn);
                SQLiteDataReader reader4 = cmd4.ExecuteReader();
                int i=0,j=0,k = 0;
                while (reader4.Read())
                {
                    i = reader4.GetInt32(0);
                    j = reader4.GetInt32(1);
                    k = reader4.GetInt32(2); 
                }
                conn.Close();
                label23.Text = "Πάτησες να διαβάσεις το κεφάλαιο 1: " + i.ToString() + " φορές";

                label28.Text = "Πάτησες να διαβάσεις το κεφάλαιο 2: " + j.ToString() + " φορές";

                label30.Text = "Πάτησες να διαβάσεις το κεφάλαιο 3: " + k.ToString() + " φορές";
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
            conn.Open();
            String query = "Select kef1clicks from users where username='" + username + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            int i=0;
            while (reader.Read())
            {
                i = reader.GetInt32(0);
                i++;
            }
            conn.Close();
            conn.Open();
            String query1 = "Update users set kef1clicks='" + i + "' where username='"+username+"'";
            SQLiteCommand cmd2 = new SQLiteCommand(query1, conn);
            cmd2.ExecuteNonQuery();

            conn.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible=true;
            conn.Open();
            String query = "Select kef2clicks from users where username='" + username + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i = reader.GetInt32(0);
                i++;
            }
            conn.Close();
            conn.Open();
            String query1 = "Update users set kef2clicks='" + i + "' where username='" + username + "'";
            SQLiteCommand cmd2 = new SQLiteCommand(query1, conn);
            cmd2.ExecuteNonQuery();

            conn.Close();

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
            conn.Open();
            String query = "Select kef3clicks from users where username='" + username + "'";
            SQLiteCommand cmd = new SQLiteCommand(query, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i = reader.GetInt32(0);
                i++;
            }
            conn.Close();
            conn.Open();
            String query1 = "Update users set kef3clicks='" + i + "' where username='" + username + "'";
            SQLiteCommand cmd2 = new SQLiteCommand(query1, conn);
            cmd2.ExecuteNonQuery();

            conn.Close();

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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Quiz quiz = new Quiz(username);
            quiz.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            panel3.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel5.Visible=false;
            panel3.Visible=true;
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Είστε σίγουροι ότι θέλετε να τερματίσετε την εφαρμογή;", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();

            }
            else
            { }
        }

        private void circularButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Είστε σίγουροι ότι θέλετε να επιστρέψετε στην προηγούμενη σελίδα;", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            { }
        }

        private void circularButton3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
        }

        private void circularButton3_Click_1(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
        }
    }
}
