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
    public class CourseRepository : ICourseRepository
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "PersonDatabase";

        public CourseRepository(IConfiguration config)
        {
            _config = config;
        }
        public void Add(Course course)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("Title", course.Title, DbType.String);
                dbparams.Add("Price", course.Price, DbType.String);
                db.Query<Student>($"[dbo].[InsertCourses]",dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("CourseID", id, DbType.Int32);
                db.Query<Course>($"[dbo].[DeleteCourses]",dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Course Find(int id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("CourseID", id, DbType.Int32);
                return db.Query<Course>($"[dbo].[SelectCourses]", dbparams, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public IList<Course> List()
        {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                return db.Query<Course>($"[dbo].[GetCourses]", null, commandType: CommandType.StoredProcedure).ToList();
        }
        public void Update(Course course)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("CourseID", course.CourseId, DbType.String);
                dbparams.Add("Title", course.Title, DbType.String);
                dbparams.Add("Price", course.Price, DbType.String);
                db.Query<Student>($"[dbo].[UpdateCourses]",dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
