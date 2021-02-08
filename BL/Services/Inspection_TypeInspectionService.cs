﻿using AutoMapper;
using BL.Models;
using BL.Services.IServices;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class Inspection_TypeInspectionService : IInspection_TypeInspectionService
    {
        private readonly Inspection_TypeInspectionRepository _inspection_TypeInspectionRepository;
        private readonly IMapper _mapper;
        public Inspection_TypeInspectionService(Inspection_TypeInspectionRepository inspection_TypeInspectionRepository)
        {
            

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Inspection_TypeInspectionBL, Inspection_TypeInspection>().ReverseMap();
                cgf.CreateMap<TypeInspectionBL, TypeInspection>().ReverseMap();
                cgf.CreateMap<InspectionBL, Inspection>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _inspection_TypeInspectionRepository = inspection_TypeInspectionRepository;
        }

        //public IEnumerable<Inspection_TypeInspectionBL> Get(Expression<Func<Inspection_TypeInspectionBL, bool>> exception)
        //{
        //    return DbSet.Where(exception).ToList();
        //}

        public IEnumerable<Inspection_TypeInspectionBL> GetAll()
        {
 

            var rez = _inspection_TypeInspectionRepository.GetAll();
            return _mapper.Map<IEnumerable<Inspection_TypeInspectionBL>>(rez);
        }
        public IEnumerable<Inspection_TypeInspectionBL> GetByInspectionId(int InspectionId)
        {
            var rez = _inspection_TypeInspectionRepository.GetAllByInspectionId(InspectionId);
            return _mapper.Map<IEnumerable<Inspection_TypeInspectionBL>>(rez);
        }

    }
}