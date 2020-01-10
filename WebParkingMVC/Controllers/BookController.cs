﻿using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParkingMVC.Models;

namespace WebParkingMVC.Controllers
{
    public class BookController : Controller
    {
        Data_Access da = new Data_Access();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookRoom(int id = 0, DateTime start = new DateTime(), DateTime end = new DateTime())
        {
            if (id == 0)
            {
                Response.Redirect("~/Home/SearchAvalilableParkingTypes");
            }
            BookRoomModel model = new BookRoomModel() { ParkingtypeId = id, startDate = start, endDate = end };

            IEnumerable<SelectListItem> ParkingsTypeList = da.getParkingsType().Select(m => new SelectListItem() { Text = m.Title, Value = m.Id.ToString() }).ToArray();
            ViewBag.ParkingsTypes = ParkingsTypeList;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookRoom(BookRoomModel model)
        {           
            if (ModelState.IsValid)
            {
                da.BookClient(model.FirstName, model.LastName, model.startDate, model.endDate, model.ParkingtypeId);                
                return RedirectToAction("Index");
            }
            return View(model);              
        }



        public ActionResult CreateBooking(int id = 0)
        {
            if (id == 0)
            {
                Response.Redirect("~/Home/SearchAvalilableParkingTypes");
            }

            return View();
        }       
    }
}