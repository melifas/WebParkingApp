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
            Data_Access da = new Data_Access();
            var avalilable = da.getParkingsType();

            return View(avalilable);
        }


        [HttpPost]
        public ActionResult AvailableParkingTypes(DateTime startDate, DateTime endDate)
        {
            Data_Access da = new Data_Access();

            return View(da.AvailableParkings(startDate, endDate));
        }

        

    }
}