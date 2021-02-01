using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class InspectionRepository : GenericRepository<Inspection>, IInspectionRepository
    {
        public InspectionRepository(MSSQLContext context) : base(context)
        {
            Context = context;
            DbSet = context.Set<Inspection>();
        }

        public IEnumerable<Inspection> GetByUserId(string userId)
        {
            return DbSet.Where(x=>x.UserId == userId)
                .Include(x=>x.Location)
                .ToList();
        }

        IEnumerable<ResultInspection> IInspectionRepository.GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
