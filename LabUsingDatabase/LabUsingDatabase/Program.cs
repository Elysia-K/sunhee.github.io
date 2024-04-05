using MySql.Data.MySqlClient;

namespace LabUsingDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MySqlConnectionStringBuilder builder =
                new MySqlConnectionStringBuilder
                {
                    Server = "localhost",
                    UserID = "root",
                    Password = "Ksh916464!",
                    Database = "ooplab"
                };

            CousresManager coursesManager = 
                new CousresManager(builder.ConnectionString);

            List<Courses> courses = coursesManager.GetAllCourses();

            Console.WriteLine("Printing Courses");
            foreach(var course in courses)
            {
                Console.WriteLine(course);
            }

        }
    }
}
