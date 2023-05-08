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
    public partial class FrmEvaluation : Form {
        Student student = null;
        ActivityRepository repo;

        public FrmEvaluation() {
            InitializeComponent();
        }
        public FrmEvaluation(Student student) {
            this.student = student;
            repo = new ActivityRepository();
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, EventArgs e) {

        }

        private void btnCancel_Click(object sender, EventArgs e) {

        }

        private void cboActivities_SelectedIndexChanged(object sender, EventArgs e) {
            Activity selectedActivity = cboActivities.SelectedItem
                 as Activity;
            txtActivityDescription.Text = selectedActivity.Description;
            txtMinForGrade.Text = selectedActivity.MinPointsForGrade.ToString();
            txtActivityDescription.Text = selectedActivity.Description;
            txtMinForSignature.Text= selectedActivity.MinPointsForSignature.ToString();

            numPoints.Maximum = 0;
            numPoints.Maximum = selectedActivity.MaxPoints;
        }

        private void FrmEvaluation_Load(object sender, EventArgs e) {
            PopulateActivities();
            SetFormTitle();
        }

        private void SetFormTitle() {
            this.Text = $"{student.FirstName} {student.LastName}";
        }

        private void PopulateActivities() {
            if (student != null) {
                cboActivities.DataSource = repo.GetActivities();
            }
        }
    }
}
