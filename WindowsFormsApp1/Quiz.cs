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
    public partial class Quiz : Form
    {
        private string username { get; set; }
        public Quiz(string username)
        {
            InitializeComponent();
            this.username = username;
        }
    }
}
