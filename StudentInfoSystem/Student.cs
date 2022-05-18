using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string faculty { get; set; }
        public string specialty { get; set; }
        public string educationDegree { get; set; }
        public string status { get; set; }
        public string facNumber { get; set; }
        public int course { get; set; }
        public int stream { get; set; }
        public int group { get; set; }
        public string password { get; set; }
        public int studentId { get; set; }

        public Student(string firstName, string middleName, string lastName, string faculty, string specialty, string educationDegree, 
            string status, string facNumber, int course, int stream, int group, string password)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.specialty = specialty;
            this.educationDegree = educationDegree;
            this.status = status;
            this.facNumber = facNumber;
            this.course = course;
            this.stream = stream;
            this.group = group;
            this.password = password;
        }
    }
}
