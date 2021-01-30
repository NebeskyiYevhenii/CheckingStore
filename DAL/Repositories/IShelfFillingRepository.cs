using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IShelfFillingRepository// : IGenericRepository<ShelfFilling>
    {
        //IEnumerable<ShelfFilling> GetAll();
        IEnumerable<ShelfFilling> GetEquipmentByLocation(int lokationId);
        IEnumerable<ShelfFilling> GetFillingByLocationArticle(int locationId, string Article);
        IEnumerable<ShelfFilling> GetFillingByInspections(IEnumerable<Inspection> inspections);
    }
}
