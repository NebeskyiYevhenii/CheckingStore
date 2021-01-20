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
        public MySQLContext() : base(@"Server=tzk706.nic.ua:3306; Database=basket20_powerbi; Uid=basket20_powerbi_user; Pwd=basket20_powerbi_user;")
        {

        }
        //public CarWashContext(string connectionString) : base(connectionString)
        //{
        //}
        public DbSet<ResultСhecking> ResultСheckings { get; set; }
        public DbSet<CheckJob> CheckJobs { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
