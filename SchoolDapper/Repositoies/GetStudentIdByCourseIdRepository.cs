using Dapper;
using Microsoft.Extensions.Configuration;
using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
    public class GetStudentIdByCourseIdRepository : IGetStudentIdByCourseIdRepository
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "PersonDatabase";

        public GetStudentIdByCourseIdRepository(IConfiguration config)
        {
            _config = config;
        }
        public void Delete(StudentCourse studentCourse)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("StudentId", studentCourse.StudentId, DbType.Int32);
                dbparams.Add("CourseId", studentCourse.CourseId, DbType.Int32);
                db.Query<StudentCourse>($"[dbo].[DeleteStudentCourse]", dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public List<StudentCourse> GetListStudentById(int id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("courseID", id, DbType.Int32);
                return db.Query<StudentCourse>($"[dbo].[SelectStudentByCourseID]", dbparams, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
