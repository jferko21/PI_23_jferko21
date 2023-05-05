namespace EvaluationManager {
    public abstract class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() {
            return FirstName + " " + LastName;
        }
    }

}
