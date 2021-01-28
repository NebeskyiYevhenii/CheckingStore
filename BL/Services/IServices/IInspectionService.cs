using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface IInspectionService
    {
        IEnumerable<LocationBL> GetAllLocationByUser(string UserId);
        //IGrouping<int, InspectionBL> GetAllLocationByUser(string UserId);


    }
}
