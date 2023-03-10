using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean? Gender { get; set; }
        public string StudentGender { get { return Gender.HasValue == true ? "Male" : "Female"; } }
        public string Phone { get; set; }
        public string Email { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }
    }
}
