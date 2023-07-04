using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup.Primitives;

namespace WindowsFormsApp1
{
    public partial class Quiz : Form
    {
        private string username { get; set; }
        private int score1, score2, score3, score4, score5, score6, score7, score8;
        public Quiz(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {

                score1++;
                score7++;
            }
            /*if(radioButton7.Checked == true)
            {
                score2++;
                score8++;
            }
            if(radioButton18.Checked == true) { 
                score3++;
            }
            if(radioButton17.Checked == true) 
            {
                score4++;
            } */



            if (radioButton27.Checked == true)
            {
                score4++;
                score5++;
            }
            if (radioButton30.Checked == true)
            {
                score3++;
                score4++;
                score7++;
            }
            if (radioButton25.Checked == true)
            {
                score1++;
                score2++;
                score7++;
            }
            if (radioButton13.Checked == true || radioButton14.Checked == true || radioButton15.Checked == true)
            {
                score2++;
            }
            if (radioButton19.Checked == true)
            {
                score1++;
                score7++;
            }
            if (radioButton7.Checked == true || radioButton12.Checked == true || radioButton21.Checked == true)
            {
                score3++;
                score7++;
            }
            if (radioButton9.Checked == true || radioButton8.Checked == true)
            {
                score3++;
                score7++;
            }
            if (radioButton33.Checked == true || radioButton29.Checked == true)
            {
                score5++;
                score7++;
            }
            if (radioButton38.Checked == true)
            {
                score5++;
                score7++;
            }
            if (radioButton40.Checked == true)
            {
                score5++;
                score7++;
            }
            if (radioButton43.Checked == true || radioButton42.Checked == true)
            {
                score6++;
                score8++;
            }
            if (radioButton46.Checked == true)
            {
                score6++;
            }
            if (radioButton48.Checked == true)
            {
                score6++;
                score3++;
                score5++;
            }
            if (radioButton50.Checked == true)
            {
                score6++;
                score8++;
            }
            if (radioButton53.Checked == true || radioButton52.Checked == true)
            {
                score5++;
            }
            if (radioButton58.Checked == true)
            {
                score1++;
                score7++;
            }
            if (radioButton59.Checked == true)
            {
                score6++;
            }
            if (radioButton61.Checked == true || radioButton60.Checked == true)
            {
                score1++;
                score2++;
                score7++;
            }
            if (radioButton67.Checked == true || radioButton66.Checked == true)
            {
                score1++;
                score2++;
                score3++;
                score4++;
                score5++;
                score7++;
            }
            if (radioButton73.Checked == true || radioButton72.Checked == true)
            {
                score1++;
                score7++;
            }
            
            List<(int score, string label)> scores = new List<(int score, string label)>
            {
                (score1, "Προγραμματιστής λογισμικού"),
                (score2, "Μηχανικός λογισμικού"),
                (score3, "Μηχανικός ενδυνάμωσης λογισμικού με τεχνητή νοημοσύνη"),
                (score4, "Μηχανικός μηχανικής μάθησης"),
                (score5, "Ειδικός τεχνητής νοημοσύνης"),
                (score6, "Σχεδιαστής εμπειρίας χρηστών")
            };

            scores.Sort((x, y) => y.score.CompareTo(x.score));

            List<string> sortedLabels = scores.Take(3).Select(x => x.label).ToList();

            string sortedLabelsString = string.Join("\n", sortedLabels);

            MessageBox.Show("Συγχαρητήρια το επάγγελμα που σου αρμόζει είναι με την εξής φθίνουσα σειρά:\n" + sortedLabelsString);

            List<(int score2, string label2)> scores2 = new List<(int score2, string label2)>
            {
                (score7, "Ανάπτυξη λογισμικού και τεχνητής νοημοσύνης"),
                (score8, "Κατανεμημένα Συστήματα")
                
            };

            scores2.Sort((x, y) => y.score2.CompareTo(x.score2));

            List<string> sortedLabels2 = scores2.Take(1).Select(x => x.label2).ToList();

            string sortedLabelsString2 = string.Join("\n", sortedLabels2);

            MessageBox.Show("Συγχαρητήρια το μεταπτυχιακό που σου αρμόζει είναι:\n" + sortedLabelsString2);

            MainPage mainPage = new MainPage(username, sortedLabelsString, sortedLabelsString2);
            mainPage.Show();
            this.Hide();
        }
    }
}
