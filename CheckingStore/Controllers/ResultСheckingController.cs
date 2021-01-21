using AutoMapper;
using BL.Services;
using CheckingStore.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class ResultСheckingController : Controller
    {
        private readonly ResultCheckingService _resultCheckingService;

        private readonly IMapper _mapper;
        public ResultСheckingController()
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ResultСheckingBL, ResultСheckingModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
            _resultCheckingService = new ResultCheckingService();

        }

        // GET: ResultСhecking
        public ActionResult Index()
        {
            var ModelAll = _mapper.Map<IEnumerable<ResultСheckingModel>>(_resultCheckingService.GetAll());
            return View(ModelAll);
        }
        public ActionResult Index2()
        {
            return View();
        }

        // GET: ResultСhecking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResultСhecking/Create
        public ActionResult Create(ResultСheckingModel resultСheckingModel)
        {
            ResultСheckingBL ModelBL = _resultCheckingService.Create(_mapper.Map<ResultСheckingBL>(resultСheckingModel));
            ResultСheckingModel Model = _mapper.Map<ResultСheckingModel>(ModelBL);
            return View(Model);
        }

        // POST: ResultСhecking/Create
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

        // GET: ResultСhecking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResultСhecking/Edit/5
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

        // GET: ResultСhecking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResultСhecking/Delete/5
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
