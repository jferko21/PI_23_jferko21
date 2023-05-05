using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Xml;

namespace EvaluationManager {
    public class StudentRepository {

        private Student CreateObject(SqlDataReader reader) {

            Student student = new Student();
            //student = CreateObject(reader);
            student.Id = Convert.ToInt32(reader["Id"].ToString());
            student.FirstName = reader["FirstName"].ToString();
            student.LastName = reader["LastName"].ToString();
            //student.Grade = Convert.ToInt32(reader["Grade"].ToString());
            int.TryParse(reader["Grade"].ToString(), out int grade);
            student.Grade = grade;

            return student;
        }

        public Student GetStudent(int id) {
            Student student = new Student();
            SqlDataReader reader;

            DB.OpenConnection();
            reader = DB.GetDataReader("SELECT * FROM Students WHERE Id = {id} ");
            if (reader.HasRows) {
                reader.Read();
                //student = CreateObject(reader);
                student.Id = Convert.ToInt32(reader["Id"].ToString());
                student.FirstName= reader["FirstName"].ToString();
                student.LastName = reader["LastName"].ToString();
                //student.Grade = Convert.ToInt32(reader["Grade"].ToString());
                int.TryParse(reader["Grade"].ToString(), out int grade);
                student.Grade = grade;

                reader.Close();
            }

            DB.CloseConnection();
            return student;
        }

        public List<Student> GetStudents() {
            List<Student> student_list = new List<Student>();
            SqlDataReader reader;

            DB.OpenConnection();
            reader = DB.GetDataReader("SELECT * FROM Students");
            while (reader.Read()) {
                Student student = CreateObject(reader);
                student_list.Add(student);
            }

            reader.Close();
            DB.CloseConnection();
            return student_list;
        }

    }
}
