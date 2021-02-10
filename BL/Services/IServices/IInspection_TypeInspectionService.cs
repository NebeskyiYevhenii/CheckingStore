using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface IInspection_TypeInspectionService
    {
        IEnumerable<Inspection_TypeInspectionBL> GetAll();
        Inspection_TypeInspectionBL GetById(int id);

        IEnumerable<Inspection_TypeInspectionBL> GetByInspectionId(int InspectionId);
        void Update(Inspection_TypeInspectionBL inspection_TypeInspectionBL);
        //IEnumerable<Inspection_TypeInspectionBL> Get(Expression<Func<Inspection_TypeInspectionBL, bool>> exception);


        //IGrouping<int, InspectionBL> GetAllLocationByUser(string UserId);


    }
}
