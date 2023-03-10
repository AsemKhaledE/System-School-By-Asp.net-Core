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
    public class StudentRepository : IStudentRepository
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "PersonDatabase";

        public StudentRepository(IConfiguration config)
        {
            _config = config;
        }

        public void Delete(int id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("StudentId", id, DbType.Int32);
                db.Query<Student>($"[dbo].[DeleteStudents]", dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
        }

        public Student Find(int id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("StudentId", id, DbType.Int32);
                return db.Query<Student>($"[dbo].[SelectStudent]", dbparams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IList<Student> List()
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            return db.Query<Student>($"[dbo].[GetStudents]",null , commandType: CommandType.StoredProcedure).ToList();
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public void Insert(Student student)
        {
            using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
            var dbparams = new DynamicParameters();
            dbparams.Add("FirstName", student.FirstName, DbType.String);
            dbparams.Add("LastName", student.LastName, DbType.String);
            dbparams.Add("Gender", student.StudentGender == "Female" ? false : true, DbType.String);
            dbparams.Add("Phone", student.Phone, DbType.String);
            dbparams.Add("Email", student.Email, DbType.String);
            db.Query<Student>($"[dbo].[InsertStudent]", dbparams, commandType: CommandType.StoredProcedure);
        }

     

        public void Update(Student student)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_config.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("StudentId", student.StudentId, DbType.Int32);
                dbparams.Add("FirstName", student.FirstName, DbType.String);
                dbparams.Add("LastName", student.LastName, DbType.String);
                dbparams.Add("Gender", student.StudentGender == "Male" ? true : false, DbType.String);
                dbparams.Add("Phone", student.Phone, DbType.String);
                dbparams.Add("Email", student.Email, DbType.String);
                db.Query<Student>($"[dbo].[UpdateStudent]", dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

}
