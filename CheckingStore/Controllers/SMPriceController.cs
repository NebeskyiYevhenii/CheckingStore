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
using System.Web.UI;

namespace CheckingStore.Controllers
{
    public class SMPriceController : Controller
    {
        private readonly IInspectionService _inspectionService;
        private readonly ISMPrice_MSService _sMPrice_MSService;
        //private readonly ISMPriceService _sMPriceService;
        private readonly IInspection_TypeInspectionService _inspection_TypeInspectionService;

        private readonly IMapper _mapper;
        public SMPriceController()
        {
            IKernel ninjectKernel = new StandardKernel();

            //ninjectKernel.Bind<ISMPriceService>().To<SMPriceService>();
            //_sMPriceService = ninjectKernel.Get<ISMPriceService>();

            ninjectKernel.Bind<ISMPrice_MSService>().To<SMPrice_MSService>();
            _sMPrice_MSService = ninjectKernel.Get<ISMPrice_MSService>();

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
                cgf.CreateMap<SmPrice_MSBL, SmPrice_MSModel>().ReverseMap();
                cgf.CreateMap<SMPriceBL, SMPriceModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }

        
        public ActionResult Update(string DateCheck, int LocationSMLocId, int LocationId, string Equipment, string Article, string u, int Inspection_typeInspectionId, bool rezult)
        {
            var prices1 = _sMPrice_MSService.GetAllByArtLoc(Article, LocationSMLocId).FirstOrDefault();
            var inspection_TypeInspection = _inspection_TypeInspectionService.GetById(Inspection_typeInspectionId);

            inspection_TypeInspection.IsValid = rezult;
            inspection_TypeInspection.CreatDate = DateTime.Now;
            inspection_TypeInspection.Remains = prices1.Remains;
            inspection_TypeInspection.ShowLevel = prices1.ShowLevel;
            inspection_TypeInspection.Price = prices1.Price;
            inspection_TypeInspection.RemainsDate = prices1.RemainsDate;

            _inspection_TypeInspectionService.Update(inspection_TypeInspection);

            var Inspection = _inspectionService.GetByLocationIdArticleUserId(LocationId, Article.Substring(0, 6), u);
            //var inspection_TypeInspections = _inspection_TypeInspectionService.GetByInspectionId(Inspection.Id).Where(x=>x.CreatDate == DateTime.Parse("1900-01-01"));
            var inspection_TypeInspections = _inspection_TypeInspectionService.GetByInspectionId(Inspection.Id);
            var inspection_TypeInspectionsModel = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(inspection_TypeInspections);
            //var localIdSM = _locationServices.GetById(LocationId).SMLocId;
            //var smprice = _mapper.Map<SMPriceModel>(_sMPriceService.GetByArticleLocation(Article.Substring(0, 6), LocationSMLocId));

            var prices = _sMPrice_MSService.GetAllByArtLoc(Article, LocationSMLocId).FirstOrDefault();
            var smprice = _mapper.Map<SmPrice_MSModel>(prices);

            ViewData["LocationId"] = LocationId;
            ViewData["LocationSMLocId"] = LocationSMLocId;
            ViewData["PRICE"] = smprice.Price;
            ViewData["SHOWLEVEL"] = smprice.ShowLevel;
            ViewData["SHORTNAME"] = smprice.ShortName;
            ViewData["Article(shelf)"] = Article;
            ViewData["Article"] = Article.Substring(0, 6);
            ViewData["Img"] = "https://static.basket.ua/image/sku/original/" + Int32.Parse(Article.Substring(0, 6)) + ".jpg";
            ViewData["Equipment"] = Equipment;
            ViewData["userId"] = u;
            ViewData["DateCheck"] = DateCheck;
            ViewBag.inspection_TypeInspections = inspection_TypeInspectionsModel;
            return PartialView();
        }

        public ActionResult Index4(string DateCheck, int LocationSMLocId, int LocationId, string Equipment, string Article, string u)
        {
            var Inspection = _inspectionService.GetByLocationIdArticleUserId(LocationId, Article, u);
            var inspection_TypeInspections = _inspection_TypeInspectionService.GetByInspectionId(Inspection.Id).Where(x => x.CreatDate == DateTime.Parse("1900-01-01"));
            var inspection_TypeInspectionsModel = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(inspection_TypeInspections);
            //var localIdSM = _locationServices.GetById(LocationId).SMLocId;
            //var smprice = _mapper.Map<SMPriceModel>(_sMPriceService.GetByArticleLocation(Article.Substring(0, 6), LocationSMLocId));
            var prices = _sMPrice_MSService.GetAllByArtLoc(Article, LocationSMLocId).FirstOrDefault();
            var smprice = _mapper.Map<SmPrice_MSModel>(prices);

            ViewData["LocationId"] = LocationId;
            ViewData["LocationSMLocId"] = LocationSMLocId;
            ViewData["PRICE"] = smprice.Price;
            ViewData["SHOWLEVEL"] = smprice.ShowLevel;
            ViewData["SHORTNAME"] = smprice.ShortName;
            ViewData["Article(shelf)"] = Article;
            ViewData["Article"] = Article.Substring(0, 6);
            ViewData["Img"] = "https://static.basket.ua/image/sku/original/" + Int32.Parse(Article.Substring(0, 6)) + ".jpg";
            ViewData["Equipment"] = Equipment;
            ViewData["userId"] = u;
            ViewData["DateCheck"] = DateCheck;
            ViewBag.inspection_TypeInspections = inspection_TypeInspectionsModel;

            return View();
        }


    }
}