using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvaluationManager
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
            StudentRepository repo = new StudentRepository();

            dgvStudents.DataSource = repo.GetStudents();
        }

        private void FrmStudents_Load(object sender, EventArgs e) {
            ShowStudents();
        }

        private void ShowStudents() {
            List<Student> students = new List<Student>();
            StudentRepository repo = new StudentRepository();

            dgvStudents.DataSource = repo.GetStudents();

        }

    }
}
