namespace EvaluationManager {
    public class Teacher : Person {
        public string Username { get; set; }
        public string Password { get; set; }
        public  bool CheckPassword(string password) {
            return password == Password;
        }
    }
}
