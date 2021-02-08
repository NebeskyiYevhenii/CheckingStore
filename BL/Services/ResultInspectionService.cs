using AutoMapper;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.IServices
{
    public class ResultInspectionService : IResultInspectionService
    {
        private readonly IResultInspectionRepository _resultInspectionRepository = new ResultInspectionRepository();
        private readonly IMapper _mapper;
        public ResultInspectionService()
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ResultInspectionBL, ResultInspection>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            //_resultInspectionRepository = ;
        }

        public void Create(ResultInspectionBL resultInspectionBL)
        {
            var rez1 = _mapper.Map<ResultInspection>(resultInspectionBL);
            _resultInspectionRepository.Create(rez1);
        }

        public IEnumerable<ResultInspectionBL> GetAll()
        {
            var rez = _resultInspectionRepository.GetAll();
            return _mapper.Map<IEnumerable<ResultInspectionBL>>(rez);
        }
    }
}
