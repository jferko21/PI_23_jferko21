using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationManager {
    public class ActivityRepository {
        private Activity CreateObject(SqlDataReader reader) {

            Activity aktivnost = new Activity();
            aktivnost.Id = Convert.ToInt32(reader["Id"].ToString());
            aktivnost.Name= reader["Name"].ToString();
            aktivnost.Description = reader["Description"].ToString();

            int.TryParse(reader["MaxPoints"].ToString(), out int maxPoint);
            int.TryParse(reader["MinPointsForGrade"].ToString(), out int minPointsForGrade);
            int.TryParse(reader["MinPointsForSignature"].ToString(), out int minPointsForSignature);

            aktivnost.MaxPoints = maxPoint;
            aktivnost.MinPointsForGrade = minPointsForGrade;
            aktivnost.MinPointsForSignature = minPointsForSignature;

            return aktivnost;
        }

        public Activity GetActivity(int id) {
            Activity aktivnost = new Activity();
            SqlDataReader reader;

            DB.OpenConnection();        // Otvara uvijek novu konekciju, netreba static
            reader = DB.GetDataReader($"SELECT * FROM Activities WHERE Id = {id}");
            if (reader.HasRows) {
                reader.Read();
                //aktivnost = CreateObject(reader);
                /*  aktivnost.Id = Convert.ToInt32(reader["Id"].ToString());
                  aktivnost.Name = reader["Name"].ToString();
                  aktivnost.Description = reader["Description"].ToString();

                  int.TryParse(reader["MaxPoints"].ToString(), out int maxPoint);
                  int.TryParse(reader["MaxPointsForGrade"].ToString(), out int minPointsForGrade);
                  int.TryParse(reader["MaxPoints"].ToString(), out int minPointsForSignature);
                */
                aktivnost = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();
            return aktivnost;
        }

        public List<Activity> GetActivities() {
            List<Activity> activity_list = new List<Activity>();
            SqlDataReader reader;

            DB.OpenConnection();
            reader = DB.GetDataReader("SELECT * FROM Activities");
            while (reader.Read()) {
                Activity activity = CreateObject(reader);
                activity_list.Add(activity);
            }

            reader.Close();
            DB.CloseConnection();
            return activity_list;
        }
    }
}
