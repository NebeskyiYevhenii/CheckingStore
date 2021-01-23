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
        IEnumerable<ResultInspection> GetAll();
        IEnumerable<ResultInspection> GetByCheckJobId(int CheckJobId);
        ResultInspection Create(ResultInspection resultСhecking);
        ResultInspection Update(ResultInspection resultСhecking);
        void Delete(int id);
    }
}
