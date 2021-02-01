using AutoMapper;
using BL.Models;
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
        //GenericRepository<Location> _locationRepository
        private readonly GenericRepository<ResultInspection> _resultInspectionRepository; //IResultInspectionRepository _resultInspectionRepository;
        private readonly IMapper _mapper;
        public ResultInspectionService(GenericRepository<ResultInspection> resultInspectionRepository)
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ResultInspectionBL, ResultInspection>().ReverseMap();
                //cgf.CreateMap<Location, LocationBL>().ReverseMap();

                //cgf.CreateMap<IEnumerable<InspectionBL>, IEnumerable<Inspection>>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _resultInspectionRepository = resultInspectionRepository;
        }

        public IEnumerable<ResultInspectionBL> GetAll()
        {
            var rez = _resultInspectionRepository.GetAll();
            return _mapper.Map<IEnumerable<ResultInspectionBL>>(rez);
            //throw new NotImplementedException();
        }

        public IEnumerable<ResultInspection> GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
