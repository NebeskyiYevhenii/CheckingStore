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
    public class ResultСheckingRepository : IResultСhecking
    {
        private readonly MSSQLContext _ctx;

        public ResultСheckingRepository()
        {
            _ctx = new MSSQLContext();
        }

        public ResultInspection Create(ResultInspection resultСhecking)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResultInspection> GetAll()
        {
            var inspercions = _ctx.Inspections.Include(x => x.User).ToList();
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

        //public ResultInspection Create(ResultInspection resultСhecking)
        //{
        //    _ctx.ResultСheckings.Add(resultСhecking);
        //    _ctx.SaveChanges();
        //    return resultСhecking;
        //}

        //public void Delete(int id)
        //{
        //    var entity = _ctx.ResultСheckings.FirstOrDefault(x => x.Id == id);

        //    _ctx.ResultСheckings.Remove(entity);

        //    _ctx.SaveChanges();
        //}

        //public IEnumerable<ResultInspection> GetAll()
        //{
        //    return _ctx.ResultСheckings.ToList();
        //}

        //public IEnumerable<ResultInspection> GetByCheckJobId(int CheckJobId)
        //{
        //    return _ctx.ResultСheckings.Where(x => x.CheckJobId == CheckJobId);
        //}

        //public ResultInspection Update(ResultInspection resultСhecking)
        //{
        //    var entity = _ctx.ResultСheckings.FirstOrDefault(x => x.Id == resultСhecking.Id);

        //    entity.CheckCount = resultСhecking.CheckCount;
        //    entity.CheckDate = resultСhecking.CheckDate;
        //    entity.CheckExpiryDate = resultСhecking.CheckExpiryDate;
        //    entity.CheckJobId = resultСhecking.CheckJobId;
        //    entity.CheckPrice = resultСhecking.CheckPrice;
        //    entity.CreatDate = resultСhecking.CreatDate;

        //    _ctx.SaveChanges();

        //    return resultСhecking;
        //}

    }
}
