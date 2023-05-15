using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationManager {
    public partial class Form1 : Form {

        public static Teacher LoggedTeacher {
            get;
            set;
        }

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
                LoggedTeacher = TeacherRepository.GetTeacher(txtKorIme.Text);

                if (LoggedTeacher != null && 
                       txtKorIme.Text == LoggedTeacher.Username && txtLozinka.Text == LoggedTeacher.Password)
                {
                    FrmStudents frmStudents = new FrmStudents();
                    frmStudents.Text = $"{LoggedTeacher.Username}  {LoggedTeacher.LastName}";
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
