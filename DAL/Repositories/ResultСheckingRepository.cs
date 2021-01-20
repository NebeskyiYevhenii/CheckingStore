using DAL.Contexts;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ResultСheckingRepository : IResultСhecking
    {
        private readonly MySQLContext _ctx;

        public ResultСheckingRepository()
        {
            _ctx = new MySQLContext();
        }

        public ResultСhecking Create(ResultСhecking resultСhecking)
        {
            _ctx.ResultСheckings.Add(resultСhecking);
            _ctx.SaveChanges();
            return resultСhecking;
        }

        public void Delete(int id)
        {
            var entity = _ctx.ResultСheckings.FirstOrDefault(x => x.id == id);

            _ctx.ResultСheckings.Remove(entity);

            _ctx.SaveChanges();
        }

        public IEnumerable<ResultСhecking> GetAll()
        {
            return _ctx.ResultСheckings.ToList();
        }

        public IEnumerable<ResultСhecking> GetByCheckJobId(int CheckJobId)
        {
            return _ctx.ResultСheckings.Where(x => x.CheckJobId == CheckJobId);
        }

        public ResultСhecking Update(ResultСhecking resultСhecking)
        {
            var entity = _ctx.ResultСheckings.FirstOrDefault(x => x.id == resultСhecking.id);

            entity.CheckCount = resultСhecking.CheckCount;
            entity.CheckDate = resultСhecking.CheckDate;
            entity.CheckExpiryDate = resultСhecking.CheckExpiryDate;
            entity.CheckJobId = resultСhecking.CheckJobId;
            entity.CheckPrice = resultСhecking.CheckPrice;
            entity.CreatDate = resultСhecking.CreatDate;

            _ctx.SaveChanges();

            return resultСhecking;
        }

    }
}
