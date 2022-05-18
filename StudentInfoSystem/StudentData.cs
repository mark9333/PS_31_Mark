using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    internal class StudentData
    {
        public static List<Student> studentsArray;

        public static List<Student> testStudents
        {
            get
            {
                return getStudents();
            }
            private set { }
        }

        public static List<Student> getStudents()
        {
            studentsArray = new List<Student>();

            studentsArray.Add(new Student("Donovan", "Thomas", "Briggs", "FKST", "KSI", "bachelor", "semester graduate", "121218556", 4, 7, 31, "aezakmi"));
            studentsArray.Add(new Student("Kiro", "Gavrailov", "Dondukov", "FPMI", "MI", "bachelor", "discontinued", "503119002", 1, 9, 22, "n0MoreLies"));
            studentsArray.Add(new Student("Joseph", "Jorge", "Joestar", "FKST", "KSI", "bachelor", "active", "503119106", 3, 9, 50, "12ffs5"));

            return studentsArray;
        }

        public static Student IsUserPassCorrect(string username, string password)
        {
            Student student = (from s in testStudents where s.facNumber.Equals(username) && s.password.Equals(password) select s).FirstOrDefault();
            return student;
        }
    }
}
