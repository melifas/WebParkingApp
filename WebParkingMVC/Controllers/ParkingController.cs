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
        public ActionResult Index()
        {
            return View();
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
                 return RedirectToAction("Index","Home");
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Parking/Delete/5
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
