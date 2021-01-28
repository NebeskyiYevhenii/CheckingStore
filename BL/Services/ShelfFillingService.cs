using AutoMapper;
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
        private readonly IShelfFillingRepository _shelfFillingRepository;
        private readonly IMapper _mapper;
        public ShelfFillingService(IShelfFillingRepository shelfFillingRepository)
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ShelfFillingBL, ShelfFilling>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _shelfFillingRepository = shelfFillingRepository;
        }


        public IEnumerable<ShelfFillingBL> GetAll()
        {
            var rez = _shelfFillingRepository.GetAll();
            return _mapper.Map<IEnumerable<ShelfFillingBL>>(rez);
        }
    }
}
