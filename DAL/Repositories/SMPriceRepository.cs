using DAL.Contexts;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class SMPriceRepository : ISMPriceRepository
    {
        private readonly OracleContext _ctx;

        public SMPriceRepository()
        {
            _ctx = new OracleContext();
        }

        public IEnumerable<SMPRICE> GetAll()
        {
            var rez = _ctx.SMPRICES.ToList();
            return rez;
        }
    }
}
