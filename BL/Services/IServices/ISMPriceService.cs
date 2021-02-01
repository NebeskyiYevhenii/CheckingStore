﻿using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface ISMPriceService
    {
        SMPriceBL GetByArticleLocation(string Article, int LocationId);
    }
}
