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
        private readonly IInspection_TypeInspectionService _inspection_TypeInspectionService;
        private readonly IMapper _mapper;
        public LocationController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ILocationServices>().To<LocationService>();
            _locationService = ninjectKernel.Get<ILocationServices>();

            ninjectKernel.Bind<IShelfFillingService>().To<ShelfFillingService>();
            _shelfFillingService = ninjectKernel.Get<IShelfFillingService>();

            ninjectKernel.Bind<IInspection_TypeInspectionService>().To<Inspection_TypeInspectionService>();
            _inspection_TypeInspectionService = ninjectKernel.Get<IInspection_TypeInspectionService>();

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



        public ActionResult Index()
        {
            var allItem = _mapper.Map<IEnumerable<LocationModel>>(_locationService.GetAll());
            return View(allItem);
        }




        public ActionResult Index2(string LocationName, string u)
        {
            List<ShelfFillingModel> newEquipments = new List<ShelfFillingModel>();
            var NewInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(_inspection_TypeInspectionService.GetAll().Where(x => x.CreatDate == DateTime.Parse("1900-01-01")));
            int LocationId = _locationService.GetAll().Where(x => x.Name == LocationName).FirstOrDefault().Id;
            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocId(u, LocationId);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);

            foreach(var item in shelfFillingModels)
            {
                foreach (var item1 in NewInspection_TypeInspectionModels)
                {
                    //var art1 = item.Article;
                    //var art2 = item1.Inspection.Article;
                    //var loc1 = item.LocationId;
                    //var loc2 = item1.Inspection.Location.SMLocId;

                    if (item.Article == item1.Inspection.Article && item.LocationId == item1.Inspection.Location.SMLocId)
                    {
                        newEquipments.Add(item);
                        break;
                    }

                }
            }



            var equipments = newEquipments.Select(x => x.EquipmentName).Distinct();

            ViewData["Location"] = LocationName;
            ViewData["LocationId"] = LocationId;
            ViewData["userId"] = u;
            ViewData["NewInspection_TypeInspectionModels"] = NewInspection_TypeInspectionModels;
            ViewBag.Equipments = equipments;

            return View();
        }

        public ActionResult Index3(int LocationId, string Equipment, string u)
        {
            List<ShelfFillingModel> newEquipments = new List<ShelfFillingModel>();
            var location = _locationService.GetById(LocationId);
            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocIdEquipment(u, LocationId, Equipment);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);

            var NewInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(_inspection_TypeInspectionService.GetAll().Where(x => x.CreatDate == DateTime.Parse("1900-01-01")));

            foreach (var item in shelfFillingModels)
            {
                foreach (var item1 in NewInspection_TypeInspectionModels)
                {
                    if (item.Article == item1.Inspection.Article && item.LocationId == item1.Inspection.Location.SMLocId)
                    {
                        newEquipments.Add(item);
                        break;
                    }
                }
            }


            var articles = newEquipments.Select(x => x.Article + " (" + x.ShelfNumber + ")").Distinct();

            ViewData["LocationId"] = location.Id;
            ViewData["LocationName"] = location.Name;
            ViewData["SMLocId"] = location.SMLocId;
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
