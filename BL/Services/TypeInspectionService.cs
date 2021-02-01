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
    public class TypeInspectionService : ITypeInspectionService
    {
        //GenericRepository<Location> _locationRepository
        private readonly GenericRepository<TypeInspection> _typeInspectionRepository;
        private readonly IMapper _mapper;
        public TypeInspectionService(GenericRepository<TypeInspection> typeInspectionRepository)
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<TypeInspectionBL, TypeInspection>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _typeInspectionRepository = typeInspectionRepository;
        }

        public IEnumerable<TypeInspectionBL> GetAll()
        {
            var rez = _typeInspectionRepository.GetAll();
            return _mapper.Map<IEnumerable<TypeInspectionBL>>(rez);
            //throw new NotImplementedException();
        }
    }
}
