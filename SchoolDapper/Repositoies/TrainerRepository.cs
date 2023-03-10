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
    public class TrainerRepository : ITrainerRepository
    {
        private readonly IConfiguration _configuration;
        private string Connectionstring = "PersonDatabase";
        public TrainerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void Add(Trainer trainer)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("TrainerName", trainer.TrainerName, DbType.String);
                dbparams.Add("Birthdate", trainer.Birthdate, DbType.String);
                dbparams.Add("City", trainer.City, DbType.String);
                dbparams.Add("CourseId", trainer.CourseId, DbType.Int32);
                db.Query<Student>($"[dbo].[InsertTrainer]", dbparams, commandType: CommandType.StoredProcedure);
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
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("TrainerID", id, DbType.Int32);
                db.Query<Trainer>($"[dbo].[DeleteTrainers]", dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Trainer Find(int id)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("TrainerID", id, DbType.Int32);
                return db.Query<Trainer>($"[dbo].[SelectTrainers]", dbparams, commandType: CommandType.StoredProcedure).FirstOrDefault();
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

        public IList<Trainer> List()
        {
            using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Connectionstring));
            return db.Query<Trainer>($"[dbo].[GetTrainers]", null, commandType: CommandType.StoredProcedure).ToList();
        }

        public void Update(Trainer trainer)
        {
            try
            {
                using IDbConnection db = new SqlConnection(_configuration.GetConnectionString(Connectionstring));
                var dbparams = new DynamicParameters();
                dbparams.Add("TrainerID", trainer.TrainerId, DbType.String);
                dbparams.Add("TrainerName", trainer.TrainerName, DbType.String);
                dbparams.Add("CourseId", trainer.CourseId, DbType.Int32);
                dbparams.Add("Birthdate", trainer.Birthdate, DbType.String);
                dbparams.Add("City", trainer.City, DbType.String);
                db.Query<Student>($"[dbo].[UpdateTrainers]", dbparams, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
