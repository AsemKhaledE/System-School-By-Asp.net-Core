using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
   public interface IGetCourseByStudentIdRepository
    {
        DbConnection GetDbconnection();
        List<StudentCourse> GetListCoursesById(int id);
        void Delete(StudentCourse student);
    }
}
