﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public interface IResultCheckingService
    {
        IEnumerable<ResultСheckingBL> GetAll();
        IEnumerable<ResultСheckingBL> GetByCheckJobId(int CheckJobId);
        ResultСheckingBL Create(ResultСheckingBL resultСhecking);
        ResultСheckingBL Update(ResultСheckingBL resultСhecking);
        void Delete(int id);

    }
}