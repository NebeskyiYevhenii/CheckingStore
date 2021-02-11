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
    public class SMPriceService : ISMPriceService
    {
        private readonly OracleRepositories _oracleRepositories;
        private readonly IMapper _mapper;
        public SMPriceService(OracleRepositories oracleRepositories)
        {


            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<SMPriceBL, SMPRICE>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _oracleRepositories = oracleRepositories;
        }

        public SMPriceBL GetByArticleLocation (string Article, int LocationId)
        {
            var rez = _mapper
                .Map<SMPriceBL>(_oracleRepositories
                .GetAll()
                .FirstOrDefault(x => x.ARTICLE == Article && x.STORELOC == LocationId
                .ToString()));
            return rez;
        }

    }
}
