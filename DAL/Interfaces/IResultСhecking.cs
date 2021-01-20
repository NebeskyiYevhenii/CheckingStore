using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IResultСhecking
    {
        IEnumerable<ResultСhecking> GetAll();
        IEnumerable<ResultСhecking> GetByCheckJobId(int CheckJobId);
        void Create(ResultСhecking resultСhecking);
        ResultСhecking Update(ResultСhecking resultСhecking);
        void Delete(int id);
    }
}
