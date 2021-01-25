using DAL.Contexts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OracleRepositories
    {
        private readonly OracleContext _ctx;

        public OracleRepositories()
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
