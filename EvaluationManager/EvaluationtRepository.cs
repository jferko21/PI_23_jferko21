using DBLayer;
using EvaluationManager;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

public static class EvaluationRepository {
    public static Evaluation GetEvaluation(Student student, Activity activity) {
        Evaluation evaluation = null;
        string sql = $"SELECT * FROM Evaluations WHERE IdStudents = {student.Id} AND IdActivities = {activity.Id}";

        DB.OpenConnection();
        var reader = DB.GetDataReader(sql);
        if (reader.HasRows) {
            reader.Read();
            evaluation = CreateObject(reader);
            reader.Close();
        }

        DB.CloseConnection();
        return evaluation;
    }

    public static List<Evaluation> GetEvaluations(Student student) {
        List<Evaluation> evaluations = new List<Evaluation>();
        string sql = $"SELECT * FROM Evaluations WHERE IdStudents = {student.Id}";

        DB.OpenConnection();
        var reader = DB.GetDataReader(sql);

        while (reader.Read()) {
            Evaluation evaluation = CreateObject(reader);
            evaluations.Add(evaluation);
        }

        reader.Close();
        DB.CloseConnection();

        return evaluations;
    }

    private static Evaluation CreateObject(SqlDataReader reader) {
        ActivityRepository activityrepo = new ActivityRepository();
        StudentRepository studentrepo = new StudentRepository();

        int idActivities = int.Parse(reader["IdActivities"].ToString());
        var activity = activityrepo.GetActivity(idActivities);
        int idStudents = int.Parse(reader["IdStudents"].ToString());
        var student = studentrepo.GetStudent(idStudents);
        int idTeachers = int.Parse(reader["IdTeachers"].ToString());
        var teacher = TeacherRepository.GetTeacher(idTeachers);
        DateTime evaluationDate = DateTime.Parse(reader["EvaluationDate"].ToString());
        int points = int.Parse(reader["Points"].ToString());

        var evaluation = new Evaluation {
            Activity = activity,
            Student = student,
            Evaluator = teacher,
            EvaluationDate = evaluationDate,
            Points = points
        };

        return evaluation;
    }

    public static void InsertEvaluation(Student student, Activity activitiy, Teacher teacher,
        int points) {
        string sql = $"INSERT INTO Evaluations (IdActivities, IdStudents, IdTeachers, EvaluationDate, Points) VALUES ({activitiy.Id}, {student.Id}, {teacher.Id}, GETDATE(), {points})";


        DB.OpenConnection();
        DB.ExecuteCommand(sql);
        DB.CloseConnection();
    }

    public static void InsertEvaluation(Evaluation evaluation, Teacher teacher,
    int points) {
        string sql = $"UPDATE Evaluations SET IdTeachers = {teacher.Id}, Points = {points}), EvaluationDate = GETDATE() WHERE IdActivities = {evaluation.Activity.Id} AND idStudents = {evaluation.Student.Id}";


        DB.OpenConnection();
        DB.ExecuteCommand(sql);
        DB.CloseConnection();
    }
}