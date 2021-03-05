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
using System.Web.UI;

namespace CheckingStore.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationServices _locationService;
        private readonly ISMPrice_MSService _sMPrice_MSService;
        private readonly IShelfFillingService _shelfFillingService;
        private readonly IInspection_TypeInspectionService _inspection_TypeInspectionService;
        private readonly IMapper _mapper;
        public LocationController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ILocationServices>().To<LocationService>();
            _locationService = ninjectKernel.Get<ILocationServices>();

            ninjectKernel.Bind<ISMPrice_MSService>().To<SMPrice_MSService>();
            _sMPrice_MSService = ninjectKernel.Get<ISMPrice_MSService>();

            ninjectKernel.Bind<IShelfFillingService>().To<ShelfFillingService>();
            _shelfFillingService = ninjectKernel.Get<IShelfFillingService>();

            ninjectKernel.Bind<IInspection_TypeInspectionService>().To<Inspection_TypeInspectionService>();
            _inspection_TypeInspectionService = ninjectKernel.Get<IInspection_TypeInspectionService>();

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
                //cgf.CreateMap<Location, LocationModel>().ReverseMap();
                cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
                cgf.CreateMap<ShelfFillingBL, ShelfFillingModel>().ReverseMap();
                cgf.CreateMap<Inspection_TypeInspectionBL, Inspection_TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<TypeInspectionBL, TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<SMPriceBL, SMPriceModel>().ReverseMap();
                cgf.CreateMap<SmPrice_MSBL, SmPrice_MSModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }



        //public ActionResult Index()
        //{
        //    var allItem = _mapper.Map<IEnumerable<LocationModel>>(_locationService.GetAll());
        //    return View(allItem);
        //}
        //public class itemStatistic
        //{
        //    public string ItemName {get;set;}
        //    public int CountVerifiedArt { get;set;}
        //    public int CountNoVerifiedArt { get;set;}

        //}


        //[OutputCache(Duration = 1800, Location = OutputCacheLocation.Server)]
        public ActionResult Index2(string DateCheck, string LocationName, string u)
        {
            List<ShelfFillingModel> newEquipments = new List<ShelfFillingModel>();
            List<itemStatistic> itemStatistics = new List<itemStatistic>();
            
            //id локации
            int LocationId = _locationService.GetAll().Where(x => x.Name == LocationName).FirstOrDefault().Id;
            //Все новые инспекции
            var NewInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(_inspection_TypeInspectionService.GetAll().Where(x => x.CreatDate == DateTime.Parse("1900-01-01")  && x.Inspection.LocationId == LocationId && x.Inspection.UserId == u));
            //Все инспекции
            var AllInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(_inspection_TypeInspectionService.GetAll().Where(x => x.Inspection.LocationId == LocationId && x.Inspection.UserId == u));
            //Все старые инспекции
            var OldInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(_inspection_TypeInspectionService.GetAll().Where(x => x.CreatDate != DateTime.Parse("1900-01-01")));

            //все тоары по инспекциям юзера и локации
            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocId(u, LocationId);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);

            //Все новые инспекции назначенные на отфильтрованную дату
            if (DateCheck != "" && DateCheck != null)
            {
                NewInspection_TypeInspectionModels = NewInspection_TypeInspectionModels.Where(x => x.Inspection.CheckDate.ToString("dd.MM.yyyy") == DateCheck).ToList();
                AllInspection_TypeInspectionModels = AllInspection_TypeInspectionModels.Where(x => x.Inspection.CheckDate.ToString("dd.MM.yyyy") == DateCheck).ToList();

                foreach (var item in shelfFillingModels)
                {
                    foreach (var item1 in AllInspection_TypeInspectionModels)
                    {
                        if (item.Article == item1.Inspection.Article && item.LocationId == item1.Inspection.Location.SMLocId && !item.EquipmentName.Contains("TEMP"))
                        {
                            //Кол-во инспекций
                            var CountArt = NewInspection_TypeInspectionModels
                                .Where(x=>x.Inspection.Article == item.Article && x.Inspection.Location.SMLocId == item.LocationId)
                                .Select(x => x.Inspection)
                                .Distinct()
                                .Count();
                            //Кол-во не пройденых инспекций
                            var CountNoVerifieArt = AllInspection_TypeInspectionModels
                                .Where(x=>x.Inspection.Article == item.Article && x.Inspection.Location.SMLocId == item.LocationId && x.CreatDate == DateTime.Parse("1900-01-01"))
                                .Select(x => x.Inspection)
                                .Distinct()
                                .Count();
                            // var CountVerifiedArt = NewInspection_TypeInspectionModels.Where(x=>x.)
                            itemStatistics.Add(new itemStatistic { ItemName = item.EquipmentName, CountVerifiedArt = CountArt - CountNoVerifieArt, CountNoVerifiedArt = CountNoVerifieArt });
                            newEquipments.Add(item);
                            break;
                        }
                    }
                }
                var equipments = newEquipments.Select(x => x.EquipmentName).Distinct().ToList();
                //var equipments1 = itemStatistics.Distinct().ToList();
                var equipments1 = itemStatistics.GroupBy(x=>x.ItemName);

                List<itemStatistic> result = itemStatistics
                    .GroupBy(l => l.ItemName)
                    .Select(cl => new itemStatistic
                    {
                        ItemName = cl.First().ItemName,
                        CountVerifiedArt = cl.Sum(v => v.CountVerifiedArt),
                        CountNoVerifiedArt = cl.Sum(c => c.CountNoVerifiedArt),
                    }).ToList();

                ViewData["Location"] = LocationName;
                ViewData["LocationId"] = LocationId;
                ViewData["userId"] = u;
                ViewData["NewInspection_TypeInspectionModels"] = NewInspection_TypeInspectionModels;
                ViewData["DateCheck"] = DateCheck;

                //return View(equipments1);
                return View(result);
            }

            return View();
        }

        //[OutputCache(Duration = 1800, Location = OutputCacheLocation.Server)]
        public ActionResult Index3(string DateCheck, int LocationId, string Equipment, string u)
        {
            List<ShelfFillingModel> newEquipments = new List<ShelfFillingModel>();
            List<string> articles = new List<string>();
            var location = _locationService.GetById(LocationId);
            var ShelfFillingBLs = _shelfFillingService.GetEquipmentByUserIdLocIdEquipment(u, LocationId, Equipment);
            var shelfFillingModels = _mapper.Map<IEnumerable<ShelfFillingModel>>(ShelfFillingBLs);
            var Inspection_TypeInspections = _inspection_TypeInspectionService
                .GetAll()
                .Where(x => x.CreatDate == DateTime.Parse("1900-01-01"));

            if (DateCheck != "" && DateCheck != null)
            {
                Inspection_TypeInspections = _inspection_TypeInspectionService
                    .GetAll()
                    .Where(x => x.CreatDate == DateTime.Parse("1900-01-01") && x.Inspection.CheckDate.ToString("dd.MM.yyyy") == DateCheck);
            }


            var NewInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(Inspection_TypeInspections);

            foreach (var item in shelfFillingModels)
            {
                foreach (var item1 in NewInspection_TypeInspectionModels)
                {
                    if (item.Article == item1.Inspection.Article && item.LocationId == item1.Inspection.Location.SMLocId)
                    {
                        newEquipments.Add(item);
                        articles.Add(_sMPrice_MSService.GetAllByArtLoc(item.Article, location.SMLocId).FirstOrDefault().ShortName + " (" + item.Article + ")");
                        break; 
                    }
                }
            }

            ViewData["LocationId"] = location.Id;
            ViewData["LocationName"] = location.Name;
            ViewData["SMLocId"] = location.SMLocId;
            ViewData["Equipment"] = Equipment;
            ViewData["Articles"] = articles;
            ViewData["DateCheck"] = DateCheck;
            ViewData["userId"] = u;
            var rez = newEquipments.OrderByDescending(x => x.ShelfNumber).ToList();
            return View(rez);
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
