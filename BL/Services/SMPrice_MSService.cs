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
    public class SMPrice_MSService : ISMPrice_MSService
    {
        private readonly GenericRepository<SmPrice_MS> _smPrice_MSRepository;
        private readonly IMapper _mapper;
        public SMPrice_MSService(GenericRepository<SmPrice_MS> smPrice_MSRepository)
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<SmPrice_MSBL, SmPrice_MS>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
            _smPrice_MSRepository = smPrice_MSRepository;
        }

        public IEnumerable<SmPrice_MSBL> GetAll()
        {
            var rez = _smPrice_MSRepository.GetAll();
            return _mapper.Map<IEnumerable<SmPrice_MSBL>>(rez);
        }

        public IEnumerable<SmPrice_MSBL> GetAllByArtLoc(string Article, int LocationId)
        {
            var rez = _smPrice_MSRepository.Get(x=>x.Article == Article && x.StoreLoc == LocationId);
            return _mapper.Map<IEnumerable<SmPrice_MSBL>>(rez);
        }
    }
}
