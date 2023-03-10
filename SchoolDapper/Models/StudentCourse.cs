using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Models
{
    public class StudentCourse
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public List<Course> courses { get; set; }
        public List<Student> students { get; set; }


    }
}
