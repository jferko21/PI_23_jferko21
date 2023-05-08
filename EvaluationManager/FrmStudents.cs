﻿using System;
using System.Collections.Generic;
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
            StudentRepository repo = new StudentRepository();
            dgvStudents.DataSource = repo.GetStudents();

            dgvStudents.Columns["Id"].DisplayIndex = 0;
            dgvStudents.Columns["FirstName"].DisplayIndex = 1;
            dgvStudents.Columns["LastName"].DisplayIndex = 2;
            dgvStudents.Columns["Grade"].DisplayIndex = 3;

        }

    }
}
