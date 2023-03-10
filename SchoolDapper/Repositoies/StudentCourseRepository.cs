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
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "PersonDatabase";

        public StudentCourseRepository(IConfiguration config)
        {
            _config = config;
        }
        public void Add(StudentCourse studentCourse)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("studentID", studentCourse.StudentId, DbType.String);
                dbparams.Add("CourseID", studentCourse.CourseId, DbType.String);
                db.Query<StudentCourse>($"[dbo].[InsertStudentCourse]", dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw;
            }         
        }

        public DbConnection GetDbconnection()
        {
            throw new NotImplementedException();
        }
    }
}
