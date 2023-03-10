using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.ViewModel
{
    public class ViewModelStudentCourse
    {
        [Display(Name = "Courses")]
        public int CourseId { get; set; }
        [Display(Name = "Student Name")]
        public int StudentId { get; set; }

        public List<Course> courses { get; set; }
        public List<Student> students { get; set; }
    }
}
