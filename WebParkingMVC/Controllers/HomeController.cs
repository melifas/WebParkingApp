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
            //da.AvailableParkings

            return View();
        }

       /* public ActionResult AvailiableParkings()
        {
            List<sp_getparkings_Result> result = null;

            using (WebParkingDBEntities db = new WebParkingDBEntities())
            {
                result = db.sp_getparkings(new DateTime(2019, 12, 20), new DateTime(2019, 12, 23)).ToList();
            }

            return View(result);
        }*/


    }
}