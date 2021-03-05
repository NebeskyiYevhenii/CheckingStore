using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface ISMPrice_MSService
    {
        IEnumerable<SmPrice_MSBL> GetAll();
        IEnumerable<SmPrice_MSBL> GetAllByArtLoc(string Article, int LocationId);

    }
}
