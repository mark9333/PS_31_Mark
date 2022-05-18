using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    internal class StudentValidation
    {
        public static Student getStudentDataByUser(User user)
        {
            List<Student> students = StudentData.getStudents();
            return students.Find(s => s.firstName.Equals(user.username) && s.facNumber.Equals(user.facNum));
        }
    }
}
