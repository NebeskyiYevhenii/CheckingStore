﻿using BL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface ITypeInspectionService
    {
        IEnumerable<TypeInspectionBL> GetAll();
        //IGrouping<int, InspectionBL> GetAllLocationByUser(string UserId);


    }
}