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
        private readonly IMapper _mapper;
        public LocationController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ILocationServices>().To<LocationService>();
            _locationService = ninjectKernel.Get<ILocationServices>();

            //_locationService = locationService;
            //_locationService = new BL.Services.LocationService(;

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
                cgf.CreateMap<Location, LocationModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }


        // GET: Location
        public ActionResult Index()
        {
            var allItem = _mapper.Map<IEnumerable<LocationModel>>(_locationService.GetAll());
            return View(allItem);
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
