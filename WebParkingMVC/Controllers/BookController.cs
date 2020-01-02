using LibraryWebParking.Repository;
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

        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult BookRoom() 
        {
            return View();
        }

        /*[HttpPost]*/
        /*[ValidateAntiForgeryToken]*/
        [Route("Book/CreateBooking/{ParkingTypeId}")]
        public ActionResult CreateBooking(string firstName, string lastName, DateTime? startDate, DateTime? endDate, int? ParkingTypeId)
        {

            /*BookRoomModel book = new BookRoomModel();
            book.FirstName = firstName;
            book.LastName = lastName;
            book.startDate = startDate;
            book.endDate = endDate;
            book.ParkingtypeId = ParkingTypeId;*/
            /*if (ModelState.IsValid)
            {
                Data_Access da = new Data_Access();
                da.BookClient(firstName, lastName, startDate, endDate, ParkingTypeId);
                return RedirectToAction("Index");
            }*/
            return View();
           
        }
    }
}