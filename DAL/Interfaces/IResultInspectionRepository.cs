using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IResultInspectionRepository
    {
        IEnumerable<ResultInspection> GetAll();
        IEnumerable<ResultInspection> GetByCheckJobId(int CheckJobId);
        void Create(ResultInspection resultСhecking);
        ResultInspection Update(ResultInspection resultСhecking);
        void Delete(int id);
    }
}
