using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            label2.Text ="Welcome "+ username;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Kef1 kef1 = new Kef1(username);
            kef1.Show();
            this.Close();
        }
    }
}
