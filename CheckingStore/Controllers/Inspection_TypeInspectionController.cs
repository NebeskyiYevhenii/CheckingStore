using AutoMapper;
using BL.Models;
using BL.Services;
using BL.Services.IServices;
using CheckingStore.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class Inspection_TypeInspectionController : Controller
    {
        private readonly IInspection_TypeInspectionService _inspection_TypeInspectionService;
        private readonly IMapper _mapper;
        public Inspection_TypeInspectionController()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IInspection_TypeInspectionService>().To<Inspection_TypeInspectionService>();
            _inspection_TypeInspectionService = ninjectKernel.Get<IInspection_TypeInspectionService>();


            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<Inspection_TypeInspectionBL, Inspection_TypeInspectionModel>().ReverseMap();
                cgf.CreateMap<InspectionBL, InspectionModel>().ReverseMap();
                cgf.CreateMap<LocationBL, LocationModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }




        public ActionResult Update(int Inspection_typeInspectionId, bool rezult)
        {
            var inspection_TypeInspection = _inspection_TypeInspectionService.GetById(Inspection_typeInspectionId);
            
            inspection_TypeInspection.IsValid = rezult;
            inspection_TypeInspection.CreatDate = DateTime.Now;

            _inspection_TypeInspectionService.Update(inspection_TypeInspection);
            ViewData["rezult"] = rezult;
            return PartialView();
        }






        public ActionResult Index()
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;

            if (claimsIdentity == null)
                throw new HttpRequestValidationException("U must be logged in");

            var userId = claimsIdentity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var rez1 = _inspection_TypeInspectionService.GetAll().Where(x => x.CreatDate == DateTime.Parse("1900-01-01"));
            //var rez2 = _inspection_TypeInspectionService.GetAll();

            var NewInspection_TypeInspectionModels = _mapper.Map<IEnumerable<Inspection_TypeInspectionModel>>(rez1);
            var locations = NewInspection_TypeInspectionModels.Select(x => x.Inspection.Location.Name).Distinct().ToList();

            ViewData["userId"] = userId;
            
            return View(locations);
        }
    }
}