using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace DAL.Contexts
{
    //https://www.c-sharpcorner.com/article/code-first-migration-asp-net-mvc-5-with-entityframework-mysql/
    //https://coderoad.ru/22680446/%D0%9E%D1%82%D0%BA%D0%B0%D1%82-Entity-Framework-%D0%B8-%D1%83%D0%B4%D0%B0%D0%BB%D0%B5%D0%BD%D0%B8%D0%B5-%D0%BD%D0%B5%D1%83%D0%B4%D0%B0%D1%87%D0%BD%D0%BE%D0%B9-%D0%BC%D0%B8%D0%B3%D1%80%D0%B0%D1%86%D0%B8%D0%B8
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Inspection> Inspections { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync
        (UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this,
            DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class MSSQLContext : IdentityDbContext<ApplicationUser>
    {
        public MSSQLContext() : base(@"DefaultConnection")//DefaultConnection
        {

        }
        
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Inspection_TypeInspection> Inspection_TypeInspections { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<ResultInspection> ResultInspections { get; set; }
        public DbSet<TypeInspection> TypeInspections { get; set; }
        public DbSet<ShelfFilling> ShelfFillings { get; set; }
        public DbSet<SmPrice_MS> SmPrice_MSs { get; set; }
           

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Inspection>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Inspections)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ShelfFilling>()
                .HasRequired(x => x.Location)
                .WithMany(x => x.ShelfFillings)
                .HasForeignKey(x => x.LocationId);

            modelBuilder.Entity<Inspection_TypeInspection>()
                .HasRequired(x => x.TypesInspection)
                .WithMany(x => x.Inspection_TypeInspections)
                .HasForeignKey(x => x.TypesInspectionId);

            modelBuilder.Entity<Inspection_TypeInspection>()
                .HasRequired(x => x.Inspection)
                .WithMany(x => x.Inspection_TypeInspections)
                .HasForeignKey(x => x.InspectionId);

            modelBuilder.Entity<Inspection_TypeInspection>()
                .HasRequired(x => x.ResultInspection)
                .WithRequiredPrincipal(x => x.Inspection_TypeInspection);

            //modelBuilder.Entity<ResultInspection>()
            //    .HasKey(x => x.Id);

            //modelBuilder.Entity<ResultInspection>()
            //    .HasRequired(t => t.Inspection_TypeInspection)
            //    .WithOptional(t => t.ResultInspection);
                

        }
    }
}
