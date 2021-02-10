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
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class FillingController : Controller
    {
        private readonly IInspectionService _inspectionService;


        private readonly IMapper _mapper;
        public FillingController()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IInspectionService>().To<InspectionService>();
            _inspectionService = ninjectKernel.Get<IInspectionService>();


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



        public ActionResult Index()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            if (claimsIdentity == null)
                throw new HttpRequestValidationException("U must be logged in");

            var userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var rez1 = _inspectionService.
            var rez = _inspectionService.GetAllLocationByUser(userId);

            var locations = _mapper.Map<IEnumerable<LocationModel>>(rez);


            ViewData["userId"] = userId;
            return View(locations);
        }



        //public ActionResult Index2(int LocationId, string u)
        //{
        //    var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocId(u, LocationId);
        //    var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
        //    var equipments = shelfFillingModels.Select(x => x.EquipmentName).Distinct();

        //    ViewData["Location"] = _locationServices.GetById(LocationId).Name;
        //    ViewData["LocationId"] = _locationServices.GetById(LocationId).Id;
        //    ViewData["userId"] = u;
        //    ViewBag.Equipments = equipments;

        //    return View();
        //}



        //public ActionResult Index3(int LocationId, string Equipment, string u)
        //{

        //    var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocIdEquipment(u, LocationId, Equipment);
        //    var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
        //    var articles = shelfFillingModels.Select(x => x.Article + " (" + x.ShelfNumber + ")").Distinct();

        //    ViewData["LocationId"] = _locationServices.GetById(LocationId).Id;
        //    ViewData["Equipment"] = Equipment;
        //    ViewData["Articles"] = articles;
        //    ViewData["userId"] = u;

        //    return View();
        //}



        //public ActionResult Index4(int LocationId, string Equipment, string Article, string u)
        //{
        //    var Inspection = _inspectionService.GetByLocationIdArticleUserId(LocationId, Article.Substring(0, 6), u);
        //    var inspection_TypeInspections = _inspection_TypeInspectionService.GetByInspectionId(Inspection.Id);
        //    var inspection_TypeInspectionsModel = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(inspection_TypeInspections);
        //    var localIdSM = _locationServices.GetById(LocationId).SMLocId;
        //    var smprice = _mapper.Map<SMPriceModel>(_sMPriceService.GetByArticleLocation(Article.Substring(0, 6), localIdSM));


        //    ViewData["PRICE"] = smprice.PRICE;
        //    ViewData["SHOWLEVEL"] = smprice.SHOWLEVEL;
        //    ViewData["Article(shelf)"] = Article;
        //    ViewData["Img"] = "https://static.basket.ua/image/sku/original/" + Int32.Parse(Article.Substring(0, 6)) + ".jpg";
        //    ViewData["Equipment"] = Equipment;
        //    ViewBag.inspection_TypeInspections = inspection_TypeInspectionsModel;

        //    return View();
        //}
    }
}