using System;
using System.Collections.Generic;


namespace SchoolDapper.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public double? Price { get; set; }

        public ICollection<StudentCourse> StudentCourses { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
