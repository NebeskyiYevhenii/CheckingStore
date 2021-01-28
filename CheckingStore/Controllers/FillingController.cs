using AutoMapper;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class FillingController : Controller
    {
        //private readonly IInspectionService _inspectionService;
        //private readonly IMapper _mapper;
        //public FillingController()
        //{
        //    IKernel ninjectKernel = new StandardKernel();
        //    ninjectKernel.Bind<IInspectionService>().To<InspectionService>();
        //    ninjectKernel.Bind<IInspectionRepository>().To<InspectionRepository>();
        //    _inspectionService = ninjectKernel.Get<IInspectionService>();

        //    var mapperCofig = new MapperConfiguration(cgf =>
        //    {
        //        cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
        //        cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
        //    });

        //    _mapper = new Mapper(mapperCofig);
        //}

        // GET: Filling
        public ActionResult Index()
        {
            return View();
        }
    }
}