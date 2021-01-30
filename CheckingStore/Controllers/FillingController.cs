using AutoMapper;
using BL.Models;
using BL.Services;
using BL.Services.IServices;
using CheckingStore.Models;
using DAL.Models;
using DAL.Repositories;
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
        private readonly IShelfFillingService _shelfFillingService;
        private readonly ILocationServices _locationServices;
        private readonly IMapper _mapper;
        public FillingController()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<ILocationServices>().To<LocationService>();
            _locationServices = ninjectKernel.Get<ILocationServices>();

            ninjectKernel.Bind<IShelfFillingService>().To<ShelfFillingService>();
            _shelfFillingService = ninjectKernel.Get<IShelfFillingService>();


            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IShelfFillingService>().To<ShelfFillingService>();
            //ninjectKernel.Bind<IShelfFillingRepository>().To<ShelfFillingRepository>();
            //ninjectKernel.Bind<ILocationServices>().To<LocationService>();

            //_shelfFillingService = ninjectKernel.Get<IShelfFillingService>();



            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
                cgf.CreateMap<ShelfFillingBL, ShelfFillingModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }

        // GET: Filling
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2(int LocationId)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            if (claimsIdentity == null)
                throw new HttpRequestValidationException("U must be logged in");

            //var userId = ClaimsIdentity
            var userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            //var userId = "";//ClaimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocId(userId, LocationId);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
            var equipments = shelfFillingModels.Select(x => x.EquipmentName).Distinct();

            ViewData["Location"] = _locationServices.GetById(LocationId).Name;
            ViewData["LocationId"] = _locationServices.GetById(LocationId).Id;
            ViewBag.Equipments = equipments;
            
            return View();
        }

        public ActionResult Index3(int LocationId, string Equipment)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity == null)
                throw new HttpRequestValidationException("U must be logged in");
            var userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;


            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocIdEquipment(userId, LocationId, Equipment);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
            var articles = shelfFillingModels.Select(x => x.Article+ " (" + x.ShelfNumber + ")").Distinct();
            
            ViewData["LocationId"] = _locationServices.GetById(LocationId).Id;
            ViewData["Equipment"] = Equipment;
            ViewData["Articles"] = articles;
            //ViewBag.Equipments = equipments;
            
            return View();
        }
    }
}