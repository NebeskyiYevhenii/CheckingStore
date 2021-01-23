using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL.Contexts
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext() : base(@"UserDB")//DefaultConnection
        {

        }
        
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Inspection_TypeInspection> Inspection_TypeInspections { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ResultInspection> ResultInspections { get; set; }
        public DbSet<TypeInspection> TypeInspections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        
    }
}
