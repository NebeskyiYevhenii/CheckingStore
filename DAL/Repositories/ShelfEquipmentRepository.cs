using DAL.Contexts;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class ShelfEquipmentRepository 
    {
        private readonly ShelfEquipmentContext _ctx;

        public ShelfEquipmentRepository()
        {
            _ctx = new ShelfEquipmentContext();
        }


        public IEnumerable<ShelfEquipment> GetAll()
        {
            var rez = _ctx._shelfEquipments.ToList();
            return rez;
        }
    }
}
