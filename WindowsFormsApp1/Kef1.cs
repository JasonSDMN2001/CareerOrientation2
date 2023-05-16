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
        private string username { get; set; }
        public Kef1(string username)
        {
            InitializeComponent();
            this.username = username;  
        }

        private void Kef1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            // no larger than screen size
            this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;


            label4.Text = "Η ταχύτατη εξέλιξη των υπολογιστών, που σηματοδοτείται\n " +
                "από αυξημένη υπολογιστική ισχύ, αυξημένη χωρητικότητα μνήμης\n και " +
                "εξειδικευμένες περιφερειακές συσκευές, έχει επιτρέψει τη διάδοση\n" +
                " προηγμένων και απαιτητικών προγραμματιστικών τεχνικών, ακόμα και\n" +
                " σε επίπεδο προσωπικού υπολογιστή.\n Οι τεχνικές αυτές θεραπεύονται " +
                "από τα επιστημονικά πεδία της Τεχνολογίας\nΛογισμικού, των Γραφικών " +
                "και της Εικονικής Πραγματικότητας, της Τεχνητής Νοημοσύνης και\n των" +
                " Ευφυών Συστημάτων, \nτης Αναγνώρισης Προτύπων και Μηχανικής Μάθησης," +
                " Πολυμέσων καθώς και από τις πλέον προηγμένες\nτεχνικές Επικοινωνίας" +
                " Ανθρώπου-Υπολογιστή.\n Η κατεύθυνση αυτή φιλοδοξεί να προσφέρει" +
                " στους προπτυχιακούς φοιτητές αφ’ ενός το απαραίτητο υπόβαθρο,\n" +
                " αφ’\nετέρου τις ιδιαίτερες τεχνικές γνώσεις ώστε να μπορούν\nνα " +
                "ανταποκριθούν αναπτυξιακά και ερευνητικά \nστην ευρύτερη περιοχή" +
                " των σύγχρονων και προηγμένων τεχνικών ανάπτυξης λογισμικού.";
            
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoScroll= true;
            tableLayoutPanel1.AutoSizeMode=AutoSizeMode.GrowAndShrink;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Tests tests = new Tests(username,"test1");
            tests.Show();
            this.Close();
        }
    }
}
