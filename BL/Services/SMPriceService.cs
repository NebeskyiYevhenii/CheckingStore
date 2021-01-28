﻿using AutoMapper;
using BL.Models;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class SMPriceService
    {
        private readonly OracleRepositories _oracleRepositories;
        private readonly IMapper _mapper;
        public SMPriceService(OracleRepositories oracleRepositories)
        {


            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<SMPriceBL, SMPRICE>().ReverseMap();
                cgf.CreateMap<IEnumerable<SMPriceBL>, IEnumerable<SMPRICE>>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);

            _oracleRepositories = oracleRepositories;
        }

        public SMPriceBL GetByArticleLocation (string Article, string Location)
        {
            var rez = _mapper.Map<SMPriceBL>(_oracleRepositories.GetAll().FirstOrDefault(x => x.ARTICLE == Article && x.STORELOC == Location));
            return rez;
        }





    }
}
