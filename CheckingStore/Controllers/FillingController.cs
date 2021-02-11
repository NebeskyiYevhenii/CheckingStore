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
    }
}