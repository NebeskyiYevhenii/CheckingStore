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
        private readonly ResultСheckingRepository _resultСheckingRepository;
        private readonly IMapper _mapper;
        public ResultCheckingService(ResultСheckingRepository resultСheckingRepository)
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ResultСheckingModel, ResultСhecking>().ReverseMap();
                cgf.CreateMap<ResultСheckingModel, ResultСhecking>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
            _resultСheckingRepository = resultСheckingRepository;

        }

        public ResultСheckingModel Create(ResultСheckingModel resultСhecking)
        {
            var result = _mapper.Map<ResultСhecking>(resultСhecking);
            var create = _resultСheckingRepository.Create(result);
            return _mapper.Map<ResultСheckingModel>(create);
        }

        public void Delete(int id)
        {
            _resultСheckingRepository.Delete(id);
        }

        public IEnumerable<ResultСheckingModel> GetAll()
        {
            var ResultСheckingAll = _resultСheckingRepository.GetAll();
            return _mapper.Map<IEnumerable<ResultСheckingModel>>(ResultСheckingAll);
        }

        public IEnumerable<ResultСheckingModel> GetByCheckJobId(int CheckJobId)
        {
            var ResultСheckings = _resultСheckingRepository.GetByCheckJobId(CheckJobId);
            return _mapper.Map<IEnumerable<ResultСheckingModel>>(ResultСheckings);
        }

        public ResultСheckingModel Update(ResultСheckingModel resultСhecking)
        {
            var ResultСheckings = _resultСheckingRepository.Update(_mapper.Map<ResultСhecking>(resultСhecking));
            return _mapper.Map<ResultСheckingModel>(ResultСheckings);
        }
    }
}
