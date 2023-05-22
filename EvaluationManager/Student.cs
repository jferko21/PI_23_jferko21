using System.Collections.Generic;
using System.Linq;

namespace EvaluationManager {
    public class Student : Person {
        public int Grade { get; set; }

        public List<Evaluation> GetEvaluations() {
            return EvaluationRepository.GetEvaluations(this);
        }

        public int CalculateTotalPoints() {
            int totalPoints = 0;

            foreach (var evaluation in GetEvaluations()) {
                totalPoints += evaluation.Points;
            }

            return totalPoints;
        }

        private bool IsEvaluationComplete() {
            ActivityRepository arepo = new ActivityRepository();

            List<Evaluation> evaluations = GetEvaluations();
            List<Activity> activities = arepo.GetActivities();

            return evaluations.Count == activities.Count;
        }

        public bool HasSignature() {
            bool hasSignature = false;
            List<Evaluation> evaluations = GetEvaluations();

            if (IsEvaluationComplete()) {
                foreach (Evaluation evaluation in GetEvaluations()) {
                    if (evaluation.IsSufficientForSignature()) {
                        hasSignature = true;
                        break;
                    }
                }
            }
            
            return hasSignature;
        }

        public bool HasGrade() {
            bool hasGrade = false;
            if (IsEvaluationComplete()) {
                foreach (Evaluation evaluation in GetEvaluations()) {
                    if (evaluation.IsSufficientForGrade()) {
                        hasGrade = true;
                        break;
                    }
                }
            }
            return hasGrade;
        }


        public int CalculateGrade() {
            int grade = 1;

            if (HasGrade()) {
                int totalPoints = CalculateTotalPoints();

                if (totalPoints >= 91) {
                    grade = 5;
                } else if (totalPoints >= 76) {
                    grade = 4;
                } else if (totalPoints >= 61) {
                    grade = 3;
                } else if (totalPoints >= 50) {
                    grade = 2;
                }
            }
            return grade;
        }
    }
}
