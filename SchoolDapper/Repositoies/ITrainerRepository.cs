using SchoolDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Repositoies
{
   public interface ITrainerRepository
    {
        DbConnection GetDbconnection();
        IList<Trainer> List();
        Trainer Find(int id);
        void Add(Trainer trainer);
        void Update(Trainer trainer);
        void Delete(int id);
    }
}
