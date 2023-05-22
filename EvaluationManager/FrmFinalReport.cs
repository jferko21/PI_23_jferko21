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
    public partial class FrmFinalReport : Form {

        StudentRepository srepo = new StudentRepository();

        public FrmFinalReport() {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e) {

        }

        private List<StudentReportView> GenerateStudentReport() {
            List<Student> allstudents = srepo.GetStudents();
            List<StudentReportView> examreports = new List<StudentReportView>();

            foreach (Student student in allstudents) {
                if (student.HasSignature()) {
                    StudentReportView examreport = new StudentReportView(student);
                    examreports.Add(examreport);
                } 
            }
            return examreports;
        }

        private void FrmFinalReport_Load_1(object sender, EventArgs e) {
            var results = GenerateStudentReport();
            dvgResults.DataSource = results;
        }
    }
}
