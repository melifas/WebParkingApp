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
        public ActionResult searchBooking(string lastName)
        {
            List<FullBookRoomModel> results = da.SearchBookings(lastName);
            if (results.Count!=0)
            {
                return View(results);
            }
            else
            {
                return View("searchBookingempty");
            }
            
        }

        public ActionResult Edit(int Id, string lastName)
        {
            FullBookRoomModel results = da.SearchBookings(lastName).Where(x=>x.Id == Id).FirstOrDefault();
            return View(results);
        }

        //POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
         public ActionResult Edit(int id, FullBookRoomModel model)
         {
             try
             {

                if (model.CheckedIn == true)
                {

                    da.CheckInClient(id);
                    
                }
                else
                {
                    da.CheckOutClient(id);
                }
                 
              }
             catch (Exception ex)
             {
                 ModelState.AddModelError("", ex.Message);
             }

            return RedirectToAction("BookingsNotChecked", "BookingDetails");
        }


 

    }
}