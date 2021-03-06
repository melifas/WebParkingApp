﻿using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebParkingMVC.Controllers
{
    public class HomeController : Controller
    {

        Data_Access da = new Data_Access();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult AvailableParkingTypes()
        {
            ViewBag.startDate = DateTime.Now.Date;
            ViewBag.endDate = DateTime.Now.Date.AddDays(3);
            List<spgetAvailableparkingsTypeCount> model = new List<spgetAvailableparkingsTypeCount>();
            return View(model);
        }

        [HttpPost]
        public ActionResult AvailableParkingTypes(DateTime startDate, DateTime endDate)
        {
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;       
            List<spgetAvailableparkingsTypeCount> model = da.AvailableParkings(startDate, endDate);            
            return View(model);
        }
    }
}