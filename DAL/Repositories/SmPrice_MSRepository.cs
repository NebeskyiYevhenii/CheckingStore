using DAL.Contexts;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class SmPrice_MSRepository : GenericRepository<SmPrice_MS>, ISMPrice_MSRepository
    {
        public SmPrice_MSRepository(MSSQLContext context) : base(context)
        {
            Context = context;
            DbSet = context.Set<SmPrice_MS>();
        }

        //public IEnumerable<SmPrice_MS> GetAll1()
        //{

        //    var rez = DbSet.Include(x=>x.Location);
        //    return rez;

        //}
    }
}
