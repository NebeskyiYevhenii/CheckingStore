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
    public class InspectionService : IInspectionService
    {
        private readonly InspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        public InspectionService(InspectionRepository inspectionRepository)
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<InspectionBL, Inspection>().ReverseMap();
                cgf.CreateMap<Location, LocationBL>().ReverseMap();

                //cgf.CreateMap<IEnumerable<InspectionBL>, IEnumerable<Inspection>>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _inspectionRepository = inspectionRepository;
        }

        public InspectionBL GetByLocationIdArticleUserId(int LocationId, string Article, string userId)
        {
            var inspection = _inspectionRepository
                .GetByUserId(userId)
                .Where(x => x.LocationId == LocationId && x.Article == Article)
                .FirstOrDefault();
            return _mapper.Map<InspectionBL>(inspection);

        }

        public IEnumerable<LocationBL> GetAllLocationByUser(string userId)
        {
            var locations = _inspectionRepository.GetByUserId(userId)
                .Select(x => x.Location)
                .Distinct();

            return _mapper.Map<IEnumerable<LocationBL>>(locations);
        }
        
        //public IEnumerable<LocationBL> GetAllByUser(string userId)
        //{
        //    var locations = _inspectionRepository.GetByUserId(userId)
        //        .Select(x => x.Location)
        //        .Distinct();

        //    return _mapper.Map<IEnumerable<LocationBL>>(locations);
        //}




    }
}
