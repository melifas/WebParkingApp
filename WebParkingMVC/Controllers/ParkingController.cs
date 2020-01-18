using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParkingMVC.Models;

namespace WebParkingMVC.Controllers
{
    public class ParkingController : Controller
    {
        Data_Access da = new Data_Access();
        // GET: Parking
        public ActionResult SeeAllParkings()
        {

            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                
                return View(da.getParkingWithTypes());
            }

           
        }

        // GET: Parking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Parking/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> ParkingsTypeList = da.getParkingsType().Select(m => new SelectListItem() { Text = m.Title, Value = m.Id.ToString() }).ToArray();
            ViewBag.ParkingsTypes = ParkingsTypeList;
            return View();
        }



        // POST: Parking/Create
        [HttpPost]
        public ActionResult Create(ParkingModel parkingModel)
        {           
            if (ModelState.IsValid)
            {
                da.AddParking(parkingModel.ParkingNumber,parkingModel.ParkingTypeId);
                 return RedirectToAction("SeeAllParkings", "Parking");
            }
            else
            {
                return View(parkingModel);
            }
            
        }


        // GET: Parking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Parking/Edit/5
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

        // GET: Parking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            using (WebParkingDBContex db = new WebParkingDBContex())
            {
                return View(db.Parkings.Where(x=>x.Id==id).FirstOrDefault());
            }
            
        }

        // POST: Parking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (WebParkingDBContex db = new WebParkingDBContex())
                {
                    Parkings parking = db.Parkings.Where(x => x.Id == id).FirstOrDefault();                   
                    db.Parkings.Remove(parking);
                    db.SaveChanges();
                    return RedirectToAction("SeeAllParkings", "Parking");
                }
                
            }
            catch
            {
                return View();
            }            
        }
    }
}
