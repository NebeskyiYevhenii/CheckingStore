using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ShelfFillingRepository : GenericRepository<ShelfFilling>, IShelfFillingRepository
    {
        public ShelfFillingRepository(MSSQLContext context) : base(context)
        {
            //_shelfFillingRepository = shelfFillingRepository;
            Context = context;
            DbSet = context.Set<ShelfFilling>();
        }

        //private readonly GenericRepository<ShelfFilling> _genericRepository = new GenericRepository<ShelfFilling>(new MSSQLContext());
        //public List<ShelfFilling> _shelfFillings = new List<ShelfFilling>();



        //public IEnumerable<ShelfFilling> GetAll()
        //{
        //    var rez = DbSet.ToList();
        //    return rez;
        //}

        public IEnumerable<ShelfFilling> GetEquipmentByLocation(int locationId)
        {
            //var shelfLocationId = _genericRepository.GetAll().FirstOrDefault(x => x.Id == locationId);
            
            return DbSet
                .Where(x => x.LocationId == locationId)
                .ToList();
        }

        public IEnumerable<ShelfFilling> GetFillingByLocationArticle(int locationId, string Article)
        {
           //var shelfLocationId = _genericRepository.GetAll().FirstOrDefault(x => x.Id == locationId);

            return DbSet
                .Where(x => x.LocationId == locationId && x.Article == Article)
                .ToList();
        } 
        
        
        public IEnumerable<ShelfFilling> GetFillingByInspection(Inspection inspection)
        {
            //var shelfLocationId = _genericRepository.GetAll().FirstOrDefault(x => x.Id == inspection.LocationId);

            return DbSet
                .Where(x => x.LocationId == inspection.LocationId && x.Article == inspection.Article)
                .ToList();
        }        
        public IEnumerable<ShelfFilling> GetFillingByInspections(IEnumerable<Inspection> inspections)
        {
            //var LocationId = inspections.Select(x => x.LocationId).FirstOrDefault();
            //var shelfLocationId = _genericRepository.GetAll().FirstOrDefault(x => x.Id == LocationId);

            List<ShelfFilling> rez = new List<ShelfFilling>();

            foreach (var inspection in inspections)
            {
                var rez1 = DbSet
                    .Where(x => x.Article == inspection.Article && x.LocationId == inspection.Location.SMLocId)
                    .FirstOrDefault();
                if (rez1 != null)
                    rez.Add(rez1);
            }

            return rez;
        }
    }
}
