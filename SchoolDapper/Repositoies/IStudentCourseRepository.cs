using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
    public interface IStudentCourseRepository
    {
        DbConnection GetDbconnection();
        void Add(StudentCourse studentCourse);
       
    }
}
