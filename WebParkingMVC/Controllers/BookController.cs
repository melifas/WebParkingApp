using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebParkingMVC.Controllers
{
    public class BookController : Controller
    {

        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult BookRoom() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Book
        public ActionResult BookRoom(string firstName, string lastName, DateTime startDate, DateTime endDate, int ParkingTypeId)
        {
            if (ModelState.IsValid)
            {
                Data_Access da = new Data_Access();
                da.BookClient( firstName,  lastName,  startDate,  endDate,  ParkingTypeId);
                return RedirectToAction("Index");
            }

            return View();
           
        }
    }
}