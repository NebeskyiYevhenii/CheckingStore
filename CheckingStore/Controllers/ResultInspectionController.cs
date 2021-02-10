using AutoMapper;
using BL.Services.IServices;
using CheckingStore.Models;
using DAL.Models;
using Ninject;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class ResultInspectionController : Controller
    {

        private readonly IResultInspectionService _resultInspectionService;
        private readonly IMapper _mapper;
        public ResultInspectionController()
        {
            IKernel ninjectKernel = new StandardKernel();

            ninjectKernel.Bind<IResultInspectionService>().To<ResultInspectionService>();
            _resultInspectionService = ninjectKernel.Get<IResultInspectionService>();


            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<ResultInspectionBL, ResultInspectionModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
        }

        public ActionResult RecordResult(int Inspection_typeInspectionId, bool rezult)
        {
            ResultInspectionModel ResultInspectionModel = new ResultInspectionModel(Inspection_typeInspectionId, rezult);
            _resultInspectionService.Create(_mapper.Map<ResultInspectionBL>(ResultInspectionModel));
            ViewData["rezult"] = rezult;
            return PartialView();
        }
    }
}