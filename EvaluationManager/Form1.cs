using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationManager {
    public partial class Form1 : Form {
        string username = "nastavnik";
        string password = "test";

        public Form1() {
            InitializeComponent();
        }

        private void btnPrijava_Click(object sender, EventArgs e) {
            if (txtKorIme.Text == "")
            {
                MessageBox.Show("Korisničko ime nije uneseno!", "Problem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtLozinka.Text == "")
            {
                MessageBox.Show("Lozinka nije uneseno!", "Problem",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                if (txtKorIme.Text == username && txtLozinka.Text == password)
                {
                    FrmStudents frmStudents = new FrmStudents();
                    frmStudents.ShowDialog();
                }
                else {
                    MessageBox.Show("Krivi podaci!", "Problem",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
