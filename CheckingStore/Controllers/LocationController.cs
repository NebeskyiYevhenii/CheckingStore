using AutoMapper;
using BL.Models;
using BL.Services.IServices;
using CheckingStore.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL.Services;
using Ninject;

namespace CheckingStore.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationServices _locationService;
        private readonly IShelfFillingService _shelfFillingService;
        private readonly IMapper _mapper;
        public LocationController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ILocationServices>().To<LocationService>();
            _locationService = ninjectKernel.Get<ILocationServices>();

            ninjectKernel.Bind<IShelfFillingService>().To<ShelfFillingService>();
            _shelfFillingService = ninjectKernel.Get<IShelfFillingService>();

            //_locationService = locationService;
            //_locationService = new BL.Services.LocationService(;

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
                cgf.CreateMap<Location, LocationModel>().ReverseMap();
                cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
                cgf.CreateMap<ShelfFillingBL, ShelfFillingModel>().ReverseMap();
                cgf.CreateMap<Inspection_TypeInspectionBL, Inspection_TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<TypeInspectionBL, TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<SMPriceBL, SMPriceModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }


        // GET: Location
        public ActionResult Index()
        {
            var allItem = _mapper.Map<IEnumerable<LocationModel>>(_locationService.GetAll());
            return View(allItem);
        }

        //public ActionResult Index2(int LocationId, string u)
        //{
        //    var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocId(u, LocationId);
        //    var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
        //    var equipments = shelfFillingModels.Select(x => x.EquipmentName).Distinct();

        //    ViewData["Location"] = _locationService.GetById(LocationId).Name;
        //    ViewData["LocationId"] = _locationService.GetById(LocationId).Id;
        //    ViewData["userId"] = u;
        //    ViewBag.Equipments = equipments;

        //    return View();
        //}
        public ActionResult Index2(string LocationName, string u)
        {
            int LocationId = _locationService.GetAll().Where(x => x.Name == LocationName).FirstOrDefault().Id;
            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocId(u, LocationId);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
            var equipments = shelfFillingModels.Select(x => x.EquipmentName).Distinct();

            ViewData["Location"] = _locationService.GetById(LocationId).Name;
            ViewData["LocationId"] = _locationService.GetById(LocationId).Id;
            ViewData["userId"] = u;
            ViewBag.Equipments = equipments;

            return View();
        }



        public ActionResult Index3(int LocationId, string Equipment, string u)
        {

            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocIdEquipment(u, LocationId, Equipment);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
            var articles = shelfFillingModels.Select(x => x.Article + " (" + x.ShelfNumber + ")").Distinct();

            ViewData["LocationId"] = _locationService.GetById(LocationId).Id;
            ViewData["SMLocId"] = _locationService.GetById(LocationId).SMLocId;
            ViewData["Equipment"] = Equipment;
            ViewData["Articles"] = articles;
            ViewData["userId"] = u;

            return View();
        }



        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Location/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
