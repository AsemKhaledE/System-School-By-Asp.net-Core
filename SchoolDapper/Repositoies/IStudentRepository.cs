using Dapper;
using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
    public interface IStudentRepository : IDisposable
    {
        DbConnection GetDbconnection();
        //List<Student> GetAll<Student>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        IList<Student> List();
        void Insert(Student student);
        Student Find(int id);
        void Update(Student student);
        void Delete(int id);
    }
}
