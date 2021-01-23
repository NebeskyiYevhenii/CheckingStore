using AutoMapper;
using BL.Services.IServices;
using DAL.Contexts;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ResultCheckingService : IResultCheckingService
    {
        private readonly ResultСheckingRepository _resultСheckingRepository = new ResultСheckingRepository();
        private readonly IMapper _mapper;
        public ResultCheckingService()
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ResultСheckingBL, ResultInspection>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
            //_resultСheckingRepository = resultСheckingRepository;

        }

        public ResultСheckingBL Create(ResultСheckingBL resultСhecking)
        {
            var result = _mapper.Map<ResultInspection>(resultСhecking);
            var create = _resultСheckingRepository.Create(result);
            return _mapper.Map<ResultСheckingBL>(create);
        }

        public void Delete(int id)
        {
            _resultСheckingRepository.Delete(id);
        }

        public IEnumerable<ResultСheckingBL> GetAll()
        {
            var ResultСheckingAll = _resultСheckingRepository.GetAll();
            return _mapper.Map<IEnumerable<ResultСheckingBL>>(ResultСheckingAll);
        }

        public IEnumerable<ResultСheckingBL> GetByCheckJobId(int CheckJobId)
        {
            var ResultСheckings = _resultСheckingRepository.GetByCheckJobId(CheckJobId);
            return _mapper.Map<IEnumerable<ResultСheckingBL>>(ResultСheckings);
        }

        public ResultСheckingBL Update(ResultСheckingBL resultСhecking)
        {
            var ResultСheckings = _resultСheckingRepository.Update(_mapper.Map<ResultInspection>(resultСhecking));
            return _mapper.Map<ResultСheckingBL>(ResultСheckings);
        }
    }
}
