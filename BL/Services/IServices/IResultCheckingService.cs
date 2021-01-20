using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface IResultCheckingService
    {
        IEnumerable<ResultСheckingModel> GetAll();
        IEnumerable<ResultСheckingModel> GetByCheckJobId(int CheckJobId);
        ResultСheckingModel Create(ResultСheckingModel resultСhecking);
        ResultСheckingModel Update(ResultСheckingModel resultСhecking);
        void Delete(int id);

    }
}
