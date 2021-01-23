using AutoMapper;
using BL.Services;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckingStore.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        private readonly IMapper _mapper;
        public UserController()
        {
            var mapperCofig = new MapperConfiguration(cgf =>
            {
                cgf.CreateMap<UserBL, UserModel>().ReverseMap();
            });

            _mapper = new Mapper(mapperCofig);
            _userService = new UserService();

        }


        [HttpPost]
        public ActionResult Authorization(string Email, string Password)
        {
            var user = _userService.Authorization(Email, Password);
            if (user == null)
            {
                return View("Index");
            }
            else 
            {
                return RedirectToAction("Index2", "ResultСhecking");
            }
                
        }















        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
