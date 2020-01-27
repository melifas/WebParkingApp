using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParkingMVC.Models;
using FullBookRoomModel = WebParkingMVC.Models.FullBookRoomModel;

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
            ViewBag.startDate = DateTime.Now.Date;
            ViewBag.endDate = DateTime.Now.Date.AddDays(3);
            IEnumerable<SelectListItem> Bookings = da.getPositionsNotBooked().Select(m=>new SelectListItem() { Text = m.ParkingNumber, Value = m.Id.ToString() }).ToArray();
            IEnumerable<SelectListItem> Clients = da.getListofCustomers().Select(m => new SelectListItem() { Text = m.LatName, Value = m.Id.ToString() }).ToArray();
            ViewBag.Bookings = Bookings;
            ViewBag.Clients = Clients;

            
            FullBookRoomModel model = new FullBookRoomModel() { StartDate = new DateTime(), EndDate = new DateTime()};
            return View(model);
        }

        // POST: BookingDetails/Create
        [HttpPost]
        public ActionResult CreateBooking(FullBookRoomModel fullBookRoomModel)
        {
            if (ModelState.IsValid)
            {
                da.BookingFromAdmin(fullBookRoomModel.StartDate, fullBookRoomModel.EndDate, fullBookRoomModel.ParkingId,fullBookRoomModel.ClientId);
                return RedirectToAction("SeeAllBookings", "BookingDetails");
            }
            else
            {
                return View(fullBookRoomModel);
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
