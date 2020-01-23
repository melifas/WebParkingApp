using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebParkingMVC.Controllers
{
    public class BookingDetailsController : Controller
    {
        Data_Access da = new Data_Access();
        // GET: BookingDetails
        public ActionResult SeeAllBookings()
        {

            using (WebParkingDBContex db = new WebParkingDBContex())
            {

                return View(da.getBookingDetails());
            }
        }

        // GET: BookingDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookingDetails/Create
        public ActionResult CreateBooking()
        {
            
            IEnumerable<SelectListItem> Bookings = da.getBookingDetails().Select(m=>new SelectListItem() { Text = m.ParkingNumber, Value = m.Id.ToString() }).ToArray();
            IEnumerable<SelectListItem> Clients = da.getBookingDetails().Select(m => new SelectListItem() { Text = m.LatName, Value = m.Id.ToString() }).ToArray();
            ViewBag.Bookings = Bookings;
            ViewBag.Clients = Clients;
            return View();
        }

        // POST: BookingDetails/Create
        [HttpPost]
        public ActionResult CreateBooking(FormCollection collection)
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

        // GET: BookingDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BookingDetails/Edit/5
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

        // GET: BookingDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookingDetails/Delete/5
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
