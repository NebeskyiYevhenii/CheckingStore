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
    public class Inspection_TypeInspectionRepository : GenericRepository<Inspection_TypeInspection>, IInspection_TypeInspectionRepository
    {
        public Inspection_TypeInspectionRepository(MSSQLContext context) : base(context)
        {
            Context = context;
            DbSet = context.Set<Inspection_TypeInspection>();
        }
        public IEnumerable<Inspection_TypeInspection> GetAllByInspectionId(int InspectionId)
        {
            var rez = DbSet.Where(x => x.InspectionId == InspectionId)
                .Include(c => c.TypesInspection)
                .Include(c => c.Inspection)
                .ToList();
            return rez;
        }
        public void Update(Inspection_TypeInspection entity)
        {

            var newItem = DbSet.Find(entity.Id);
            newItem.IsValid = entity.IsValid;
            newItem.CreatDate = entity.CreatDate;
            Context.Entry(newItem).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public IEnumerable<Inspection_TypeInspection> GetAll1()
        {

            var rez = DbSet.Include(x=>x.Inspection.Location).ToList();
            return rez;

        }


    }
}
