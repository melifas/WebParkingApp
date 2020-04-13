using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices.Internal;
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


        public Parkings FindParking(string PNumber)
        {
            using (WebParkingDBContex db = new WebParkingDBContex())
            {

                Parkings p = da.FindParking(PNumber);
                return p;
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
                using (WebParkingDBContex db = new WebParkingDBContex())
                {
                    if (FindParking(parkingModel.ParkingNumber)!=null)
                    {
                        ModelState.AddModelError("", "Dublicate");
                    }
                    else
                    {
                        da.AddParking(parkingModel.ParkingNumber, parkingModel.ParkingTypeId);
                        return RedirectToAction("SeeAllParkings", "Parking");
                    }                                    
                }
            }
            IEnumerable<SelectListItem> ParkingsTypeList = da.getParkingsType().Select(m => new SelectListItem() { Text = m.Title, Value = m.Id.ToString() }).ToArray();
            ViewBag.ParkingsTypes = ParkingsTypeList;
            return View(parkingModel);
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
                    Parkings p = db.Parkings
                        .Include(m => m.Bookings)
                        .Where(m => m.Id == id)
                        .FirstOrDefault();

                    if (p != null)
                    {
                        if (p.Bookings.Count > 0)
                        {
                            ViewBag.Message = "Αδυναμία διαγραφής Θέσης όταν υπάρχει κράτηση γι αυτη";

                            return View();
                        }
                        else
                        {
                            db.Parkings.Remove(p);
                            db.SaveChanges();
                            return RedirectToAction("SeeAllParkings", "Parking");
                        }
                    }
                }

            }
            catch(Exception e)
            {
                return RedirectToAction("SeeAllParkings");
            }

            return RedirectToAction("SeeAllParkings");
        }
        
    }
}
