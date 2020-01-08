using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebParkingMVC.Controllers
{
    public class SearchBooikingsController : Controller
    {
        Data_Access da = new Data_Access();
        // GET: SearchBooikings
        public ActionResult searchBooking()
        {
            List<spBookingsSearch_Result> results = new List<spBookingsSearch_Result>();
            return View(results);
        }

        [HttpPost]
        public ActionResult searchBooking(string lastName, DateTime startDate)
        {
            List<spBookingsSearch_Result> results = da.SearchBookings(lastName, startDate);
            return View(results);
        }


    }
}