using LibraryWebParking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebParkingMVC.Models;
using LibraryWebParking.Repository;

namespace WebParkingMVC.Controllers
{
    public class ClientController : Controller
    {
        Data_Access da = new Data_Access(); 
        // GET: Client
        public ActionResult Details(int id)
        {
            var model = da.ClientDetails(id);
            return View(model);                
        }
    }
}