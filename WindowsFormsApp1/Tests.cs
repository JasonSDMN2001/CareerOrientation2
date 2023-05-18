﻿using System;
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

    public partial class Tests : Form
    {
        private string username { get; set; }
        private string testType { get; set; }
        List<int> list = new List<int> { 1, 2, 3, 4, 5 };
        Random random = new Random();
        int currentCorrectAns;
        int score=0;
        int number_of_try = 1;
        int totalScore;
        public Tests(string username, string testType)
        {
            InitializeComponent();
            this.username = username;
            this.testType = testType;
        }

        private void Tests_Load(object sender, EventArgs e)
        {
            totalScore = list.Count;
            if (testType == "test1")
            {
                bool exceded_number_of_tries = false;
                try
                {
                    SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;");
                    conn.Open();
                    String query1 = "Select MAX(number_of_try) from results where testname='" + testType + "'and username='" + username + "'";
                    SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        number_of_try = reader.GetInt32(0);
                    }
                    conn.Close();
                    if (number_of_try > 3)
                    {
                        exceded_number_of_tries = true;
                    }
                    else
                    {
                        number_of_try++;
                    }
                }catch(Exception ex)
                {

                }
                if (!exceded_number_of_tries)
                {
                    //populateTable(testType);
                    populateTable2(testType, list, random);
                }
                else
                {
                    MessageBox.Show("You have exceded the max number of tries for this test!\n\n " +
                        "now redirecting back to chapter selection");
                    this.Hide();
                    Kef1 kef1 = new Kef1(username);
                    kef1.Show();
                    this.Close();
                }
            }
        }

        private void populateTable2(String testType,List<int>list,Random random)
        {
            iconPictureBox1.Visible=false; iconPictureBox2.Visible=false;
            SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;");
            conn.Open();
            int randomIndex = random.Next(list.Count);
            int randomNumber = list[randomIndex];
            String query1 = "Select * from tests where testType='" + testType + "'and id='" + randomNumber + "'";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                groupBox1.Text = reader.GetString(2);
                radioButton1.Text = reader.GetString(3);
                radioButton2.Text = reader.GetString(4);
                radioButton3.Text = reader.GetString(5);
                radioButton4.Text = reader.GetString(6);
                currentCorrectAns = reader.GetInt32(7);
            }
        
            list.RemoveAt(randomIndex);
            
            //tableLayoutPanel1.ResumeLayout();
            conn.Close();
        }

        
        private void AddLabelTableRow(string labelText)
        {
            // Create the new row and set its properties
            //int rowIndex = tableLayoutPanel1.RowCount++;
            //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Create the label and set its properties
            Label label = new Label();
            label.Text = labelText;
            label.AutoSize = true;

            // Add the label to a cell in the table
            //tableLayoutPanel1.Controls.Add(label, 0, rowIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pos=0;
            if(radioButton1.Checked==true)
            {
                pos = 1;
            }else if(radioButton2.Checked==true)
            {
                pos = 2;
            }else if (radioButton3.Checked==true) {
                pos = 3;
            }
            else if (radioButton4.Checked == true)
            {
                pos = 4;
            }
            if (pos == currentCorrectAns)
            {
                score++;
                iconPictureBox2.Visible = true;
                MessageBox.Show("Correct");
            }
            else
            {
                iconPictureBox1.Visible = true;
                MessageBox.Show("False");

            }
            if (list.Count > 0)
            {
                populateTable2(testType, list, random);
            }
            else
            {
                float i = (float) score / totalScore;
                SQLiteConnection conn = new SQLiteConnection("Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "career_base.db;Version=3;");
                conn.Open();
                SQLiteCommand profileCreatecmd = new SQLiteCommand("Insert into results(username,testname,score,number_of_try) Values(@username,@testname,@score,@try)", conn);
                profileCreatecmd.Parameters.AddWithValue("@username", username);
                profileCreatecmd.Parameters.AddWithValue("@testname", testType);
                profileCreatecmd.Parameters.AddWithValue("@score", i);
                profileCreatecmd.Parameters.AddWithValue("@try", number_of_try);
                profileCreatecmd.ExecuteNonQuery();
                conn.Close();


                MessageBox.Show("The test is finished");
                this.Hide();
                Kef1 kef1 = new Kef1(username);
                kef1.Show();
                this.Close();
            }

        }
    }
}
