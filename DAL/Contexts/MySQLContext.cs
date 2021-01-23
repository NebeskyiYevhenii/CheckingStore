using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL.Contexts
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() : base(@"DefaultConnection")
        {

        }
        //public CarWashContext(string connectionString) : base(connectionString)
        //{
        //}
        public DbSet<ResultInspection> ResultСheckings { get; set; }
        //public DbSet<CheckJob> CheckJobs { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
