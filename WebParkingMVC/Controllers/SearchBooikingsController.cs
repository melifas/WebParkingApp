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
            List<FullBookRoomModel> results = new List<FullBookRoomModel>();
            return View(results);
        }

        [HttpPost]
        public ActionResult searchBooking(string lastName, DateTime startDate)
        {
            List<FullBookRoomModel> results = da.SearchBookings(lastName, startDate);
            return View(results);
        }


    }
}