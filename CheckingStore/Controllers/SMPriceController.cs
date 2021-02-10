using AutoMapper;
using BL.Models;
using BL.Services;
using BL.Services.IServices;
using CheckingStore.Models;
using DAL.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class SMPriceController : Controller
    {
        private readonly IInspectionService _inspectionService;
        private readonly ISMPriceService _sMPriceService;
        private readonly IInspection_TypeInspectionService _inspection_TypeInspectionService;

        private readonly IMapper _mapper;
        public SMPriceController()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<ISMPriceService>().To<SMPriceService>();
            _sMPriceService = ninjectKernel.Get<ISMPriceService>();

            ninjectKernel.Bind<IInspectionService>().To<InspectionService>();
            _inspectionService = ninjectKernel.Get<IInspectionService>();

            ninjectKernel.Bind<IInspection_TypeInspectionService>().To<Inspection_TypeInspectionService>();
            _inspection_TypeInspectionService = ninjectKernel.Get<IInspection_TypeInspectionService>();

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
                cgf.CreateMap<ShelfFillingBL, ShelfFillingModel>().ReverseMap();
                cgf.CreateMap<Inspection_TypeInspectionBL, Inspection_TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<TypeInspectionBL, TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<SMPriceBL, SMPriceModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }

        public ActionResult Index4(int LocationSMLocId, int LocationId, string Equipment, string Article, string u)
        {
            var Inspection = _inspectionService.GetByLocationIdArticleUserId(LocationId, Article.Substring(0, 6), u);
            var inspection_TypeInspections = _inspection_TypeInspectionService.GetByInspectionId(Inspection.Id);
            var inspection_TypeInspectionsModel = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(inspection_TypeInspections);
            //var localIdSM = _locationServices.GetById(LocationId).SMLocId;
            var smprice = _mapper.Map<SMPriceModel>(_sMPriceService.GetByArticleLocation(Article.Substring(0, 6), LocationSMLocId));

            ViewData["LocationId"] = LocationId;
            ViewData["PRICE"] = smprice.PRICE;
            ViewData["SHOWLEVEL"] = smprice.SHOWLEVEL;
            ViewData["SHORTNAME"] = smprice.SHORTNAME;
            ViewData["Article(shelf)"] = Article;
            ViewData["Img"] = "https://static.basket.ua/image/sku/original/" + Int32.Parse(Article.Substring(0, 6)) + ".jpg";
            ViewData["Equipment"] = Equipment;
            ViewData["userId"] = u;
            ViewBag.inspection_TypeInspections = inspection_TypeInspectionsModel;

            return View();
        }


    }
}