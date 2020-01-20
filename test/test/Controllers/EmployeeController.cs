using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using ClassLibrary1;

namespace test.Controllers
{
    public class EmployeeController : Controller
    {
        Data_Access da = new Data_Access();
        public object Data_Access { get; private set; }

        // GET: Employee
        public ActionResult SignUp()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult SignUp(  EmployeeModel em )
        {
            if (ModelState.IsValid)
            {
                
                da.CreateEmployee(em.Id,em.FirstName,em.lastName,em.Password);
                return RedirectToAction("SignUp");                
            };
            return View();
        }

        public ActionResult ListCustomers()
        {           
            return View(da.LoadEmployees());

        }


    }
}