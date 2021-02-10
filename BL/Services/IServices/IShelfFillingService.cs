using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface IShelfFillingService //: IGenericService<ShelfFilling>
    {
        //IEnumerable<ShelfFillingBL> GetAll();
        IEnumerable<ShelfFilling> GetEquipmentByLocationArticle(int locationId, string Article);
        IEnumerable<ShelfFillingBL> GetEquipmentByUserIdLocId(string userId, int LocId);
        IEnumerable<ShelfFillingBL> GetFillingByInspections(IEnumerable<Inspection> inspections);
        IEnumerable<ShelfFillingBL> GetEquipmentByUserIdLocIdEquipment(string userId, int LocId, string equipment);
    }
}
