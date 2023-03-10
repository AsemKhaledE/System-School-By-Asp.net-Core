using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDapper.Data
{
    public class SchoolDbContext: DbContext
    {  
        public SchoolDbContext() { }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }
    }
}
