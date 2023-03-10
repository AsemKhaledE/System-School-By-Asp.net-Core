using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
    public interface IGetStudentIdByCourseIdRepository
    {
        DbConnection GetDbconnection();
        List<StudentCourse> GetListStudentById(int id);
        void Delete(StudentCourse course);
    }
}
