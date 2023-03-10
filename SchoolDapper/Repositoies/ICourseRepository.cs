using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
    public interface ICourseRepository
    {
        DbConnection GetDbconnection();
        Course Find(int id);
        IList<Course> List();
        void Add(Course course);
        void Update(Course course);
        void Delete(int id);
    }
}
