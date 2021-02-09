using AutoMapper;
using BL.Services.IServices;
using DAL.Models;
using CheckingStore.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class ResultInspectionController : Controller
    {

        private readonly IResultInspectionService _resultInspectionService;
        private readonly IMapper _mapper;
        public ResultInspectionController()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IResultInspectionService>().To<ResultInspectionService>();
            _resultInspectionService = ninjectKernel.Get<IResultInspectionService>();


            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ShelfFillingBL, ShelfFillingModel>().ReverseMap();
                cgf.CreateMap<Inspection_TypeInspectionBL, Inspection_TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<ResultInspectionBL, ResultInspectionModel>().ReverseMap();
                cgf.CreateMap<TypeInspectionBL, TypeInspectionModel>().ReverseMap();
                //cgf.CreateMap<SMPriceBL, SMPriceModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }

        public ActionResult RecordResult(int Inspection_typeInspectionId, bool rezult)
        {
            ResultInspectionModel ResultInspectionModel = new ResultInspectionModel(Inspection_typeInspectionId, rezult);
            _resultInspectionService.Create(_mapper.Map<ResultInspectionBL>(ResultInspectionModel));
            ViewData["rezult"] = rezult;
            return PartialView();
        }
    }
}