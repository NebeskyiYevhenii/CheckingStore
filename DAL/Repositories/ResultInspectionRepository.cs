using DAL.Contexts;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class ResultInspectionRepository : IResultInspectionRepository
    {
        private readonly MSSQLContext _ctx;

        public ResultInspectionRepository()
        {
            _ctx = new MSSQLContext();
        }

        public void Create(ResultInspection resultInspection)
        {
            _ctx.ResultInspections.Add(resultInspection);
            _ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultInspection> GetAll()
        {
            //var inspercions = _ctx.Inspections.Include(x => x.User).ToList();
            throw new NotImplementedException();
        }

        public IEnumerable<ResultInspection> GetByCheckJobId(int CheckJobId)
        {
            throw new NotImplementedException();
        }

        public ResultInspection Update(ResultInspection resultСhecking)
        {
            throw new NotImplementedException();
        }

    }
}
