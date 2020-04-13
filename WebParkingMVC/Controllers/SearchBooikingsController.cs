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
            return View(results);
        }

        public ActionResult Edit(int Id, string lastName)
        {
            //CategoryViewModel result = CategoriesRepository.GetById(id);
            // EditInitialize(result);
            //return View(//result);

            /*using (WebParkingDBContex db = new WebParkingDBContex())
            {
                 var model = db.spBookingsSearch(lastName);
                return View(model);
            }*/

            FullBookRoomModel results = da.SearchBookings(lastName).Where(x=>x.Id == Id).FirstOrDefault();
            return View(results);
        }

        // POST: Categories/Edit/5
        //[HttpPost]

        //[ValidateAntiForgeryToken]
        /* public ActionResult Edit(int id, CategoryBindingModel model)
         {
             try
             {
                 bool result = CategoriesRepository.Update(id, model);
                 if (result)
                 {
                     return RedirectToAction("Index");
                 }
             }
             catch (Exception ex)
             {
                 ModelState.AddModelError("", ex.Message);
             }

             return View();
         }
 */

    }
}