using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Kef1 : Form
    {
        public string username { get; set; }
        public Kef1(string username)
        {
            InitializeComponent();
            this.username = username;  
        }

        private void Kef1_Load(object sender, EventArgs e)
        {
            label1.Text="Welcome "+ username;
        }
    }
}
