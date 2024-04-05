using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabUsingDatabase
{
    public class CousresManager
    {
        private string connectionString;

        public CousresManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Courses> GetAllCourses()
        {
            List<Courses> courses = new List<Courses>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM courses";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            courses.Add(new Courses{
                            CoursesId= Convert.ToInt32(reader["CoursesId"]),
                            CoursesName = reader["CoursesName"].ToString(),
                            CoursesCredit = Convert.ToInt32(reader["CoursesCredit"]),
                            });
                        }
                    }
                }
            }
            return courses;

        }

        public void AddCourses(Courses courses)
        {
            using(var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO courses " +
                    "(CoursesId, CoursesName, CoursesCredit) VALUES (@CoursesId, @CoursesName, @CoursesCredit)";
                using ( var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CoursesId", courses.CoursesId);
                    cmd.Parameters.AddWithValue("@CoursesName", courses.CoursesName);
                    cmd.Parameters.AddWithValue("@CoursesCredit", courses.CoursesCredit);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateCourses(Courses courses)
        {
            using ( var connection = new MySqlConnection( connectionString))
            {
                connection.Open();
                var query = "UPDATE courses SET CoursesId = @CoursesId, " +
                    "CoursesName = @CoursesName, CoursesCredit= @CoursesCredit";
                using (var cmd = new MySqlCommand(query,connection))
                {
                    cmd.Parameters.AddWithValue("@CoursesId", courses.CoursesId);
                    cmd.Parameters.AddWithValue("@CoursesName", courses.CoursesName);
                    cmd.Parameters.AddWithValue("@CoursesCredit", courses.CoursesCredit);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCourses(int coursesid)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM courses WHERE CoursesId = @CoursesId";
                using (var cmd = new MySqlCommand(query, connection))
                {

                    cmd.Parameters.AddWithValue("@CoursesId", coursesid);
                    cmd.ExecuteNonQuery();

                }
            }
        }

    }
}
