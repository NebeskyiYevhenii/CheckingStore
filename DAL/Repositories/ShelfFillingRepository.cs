using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ShelfFillingRepository
    {
        private readonly ShelfFillingContext _ctx;

        public ShelfFillingRepository()
        {
            _ctx = new ShelfFillingContext();
        }


        public IEnumerable<ShelfFilling> GetAll()
        {
            var rez = _ctx._shelfFillings.ToList();
            return rez;
        }
    }
}
