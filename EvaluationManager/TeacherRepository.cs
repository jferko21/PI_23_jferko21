using DBLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace EvaluationManager {
    public static class TeacherRepository {

        /// <summary>
        /// Create Teacher Teacher object 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Teacher CreateObject(SqlDataReader reader) {

            Teacher teacher = new Teacher();
            teacher.Id = Convert.ToInt32(reader["Id"].ToString());
            teacher.FirstName = reader["FirstName"].ToString();
            teacher.LastName = reader["LastName"].ToString();
            teacher.Username = reader["Username"].ToString();
            teacher.Password = reader["Password"].ToString();

            return teacher;
        }

        /// <summary>
        /// Returns Teacher with username 
        /// </summary>
        /// <param name="username"></param>
        /// <returns>
        /// Return Teacher if exists with given usernmae, null if not.
        /// </returns>
        public static Teacher GetTeacher(string username) {
            return FetchTeacher($"SELECT * FROM Teachers WHERE Username = '{username}'");
        }

        /// <summary>
        /// Return Teacher with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Return Teacher if exists with given id, null if not.
        /// </returns>
        public static Teacher GetTeacher(int id) {
            return FetchTeacher ($"SELECT * FROM Teachers WHERE Id = '{id}'");
        }

        /// <summary>
        /// Fetchs Teacher with given sql string.
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>
        /// Returns Teacher object if found, null if not.
        /// </returns>
        public static Teacher FetchTeacher(string sql) {
            Teacher teacher = null;
            SqlDataReader reader;

            DB.OpenConnection();
            reader = DB.GetDataReader(sql);
            while (reader.Read()) {
                teacher = CreateObject(reader);
            }

            reader.Close();
            DB.CloseConnection();

            return teacher;
        }
    }
}
