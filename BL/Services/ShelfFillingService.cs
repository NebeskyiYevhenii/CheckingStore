using AutoMapper;
using BL.Models;
using BL.Services.IServices;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class ShelfFillingService : IShelfFillingService
    {
        private readonly ShelfFillingRepository _shelfFillingRepository;
        private readonly InspectionRepository _inspectionRepository;
        private readonly IMapper _mapper;
        public ShelfFillingService(ShelfFillingRepository shelfFillingRepository, InspectionRepository inspectionRepository)
        {


            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ShelfFillingBL, ShelfFilling>().ReverseMap();
                cgf.CreateMap<InspectionBL, Inspection>().ReverseMap();
                //cgf.CreateMap<IEnumerable<LocationBL>, IEnumerable<Location>>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _shelfFillingRepository = shelfFillingRepository;
            _inspectionRepository = inspectionRepository;
        }

        public bool Delete(ShelfFilling item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShelfFilling> GetAll()
        {
            throw new NotImplementedException();
        }

        public ShelfFilling GetById(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<ShelfFilling> GetEquipmentByLocationArticle(int locationId, string Article)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<ShelfFilling> GetEquipmentByLocationArticle(InspectionBL inspectionBL)
        //{
        //    var rez = _shelfFillingRepository.GetFillingByLocationArticle();
        //    return _mapper.Map<IEnumerable<ShelfFillingBL>>(rez);
        //} 

        public IEnumerable<ShelfFillingBL> GetEquipmentByUserIdLocId(string userId, int LocId)
        {
            var Ispections = _inspectionRepository.GetByUserId(userId).Where(x => x.LocationId == LocId);
            var rez = _shelfFillingRepository.GetFillingByInspections(Ispections);

            return _mapper.Map<IEnumerable<ShelfFillingBL>>(rez);
        }


        public IEnumerable<ShelfFillingBL> GetEquipmentByUserIdLocIdEquipment(string userId, int LocId, string equipment)
        {
            var Ispections = _inspectionRepository.GetByUserId(userId).Where(x => x.LocationId == LocId);
            var rez = _shelfFillingRepository.GetFillingByInspections(Ispections).Where(x=>x.EquipmentName == equipment);

            return _mapper.Map<IEnumerable<ShelfFillingBL>>(rez);
        }








        public IEnumerable<ShelfFillingBL> GetFillingByInspections(IEnumerable<Inspection> inspections)
        {
            throw new NotImplementedException();
        }

        public void Insert(ShelfFilling item)
        {
            throw new NotImplementedException();
        }
    }
}
