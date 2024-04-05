using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabUsingDatabase
{
    public class Courses
    {
        public int CoursesId {  get; set; }
        public string CoursesName { get; set; }
        public int CoursesCredit {  get; set; }

        public Courses() { }

        public override string ToString()
        {
            return $"Id: {CoursesId}\t" +
                $"Name: {CoursesName}\t" +
                $"Credit: {CoursesCredit}";
        }

    }
}
