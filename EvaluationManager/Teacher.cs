namespace EvaluationManager {
    public class Teacher : Person {
        public string Username { get; set; }
        public string Password { get; set; }
        public  bool CheckPassword(string password) {
            return password == Password;
        }

        public void PerformEvaluation(Student student, Activity activity, int points)
        {
            Evaluation evaluation = EvaluationRepository.GetEvaluation (student, activity);
            if (evaluation != null)
            {
                EvaluationRepository.UpdateEvaluation(evaluation, this, points);
            }
            else {
                EvaluationRepository.InsertEvaluation(student, activity, this, points);
            }
        }
     }
}
