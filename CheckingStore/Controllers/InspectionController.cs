using AutoMapper;
using BL.Models;
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
    public class InspectionController : Controller
    {
        private readonly IInspectionService _inspectionService;
        private readonly IMapper _mapper;
        public InspectionController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IInspectionService>().To<InspectionService>();
            ninjectKernel.Bind<IInspectionRepository>().To<InspectionRepository>();
            _inspectionService = ninjectKernel.Get<IInspectionService>();

            //_locationService = locationService;
            //_locationService = new BL.Services.LocationService(;

            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }

        // GET: Inspection
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            if (claimsIdentity == null)
                throw new HttpRequestValidationException("U must be logged in");

            var userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var rez = _inspectionService.GetAllLocationByUser("3e1174e2-098a-454b-a141-9c5867eec9ea");

            var models = _mapper.Map<IEnumerable<LocationModel>>(rez);

            return View(models);
        }



        // GET: Inspection/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inspection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inspection/Create
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

        // GET: Inspection/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inspection/Edit/5
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

        // GET: Inspection/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inspection/Delete/5
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
