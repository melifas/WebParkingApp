﻿using LibraryWebParking.Model;
using LibraryWebParking.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using WebParkingMVC.Models;

namespace WebParkingMVC.Controllers
{
    public class BookController : Controller
    {
        Data_Access da = new Data_Access();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookRoom(int id = 0, DateTime start = new DateTime(), DateTime end = new DateTime())
        {
            if (id == 0)
            {
                Response.Redirect("~/Home/SearchAvalilableParkingTypes");
            }
            BookRoomModel model = new BookRoomModel() { ParkingtypeId = id, startDate = start, endDate = end };
            

            IEnumerable<SelectListItem> ParkingsPositons = da.getAvailableParkingPositions(start, end, id).Select(m => new SelectListItem() { Text = m.ParkingNumber, Value = m.Id.ToString() }).ToArray();
            ViewBag.ParkingsTypes = ParkingsPositons;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookRoom(BookRoomModel model)
        {
            if (ModelState.IsValid)
            {
                string fileNme = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extention = Path.GetExtension(model.ImageFile.FileName);
                fileNme = fileNme + DateTime.Now.ToString("yymmssfff") + extention;
                model.ImagePath = "~/Image/" + fileNme;
                fileNme = Path.Combine(Server.MapPath("~/Image/"), fileNme);
                model.ImageFile.SaveAs(fileNme);

                
                da.BookClient(model.FirstName, model.LastName, model.ImagePath, model.Email, model.Phone, model.startDate, model.endDate, model.ParkingtypeId);

                ModelState.Clear();
                //Αποστολή mail ασύγχρονα                
                HostingEnvironment.QueueBackgroundWorkItem(ct => SendMailAsync(model));

                return RedirectToAction("Index");
            }
            return View(model);
        }
      

        private async void SendMailAsync(BookRoomModel model)
        {
            using (SmtpClient client = new SmtpClient())
            {
                WebParkingDBContex db = new WebParkingDBContex();
                TimeSpan timeStaying = model.endDate.Date.Subtract(model.startDate.Date);
                ParkingTypes parkingtype = db.ParkingTypes.Where(x => x.Id == model.ParkingtypeId).FirstOrDefault();
                var totalPrice = timeStaying.Days * parkingtype.Price;

                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                MailAddress from = new MailAddress(smtpSection.From);
                MailAddress to = new MailAddress(model.Email,
                                                string.Format("{0} {1} {2} {3} {4}", 
                                                model.LastName, 
                                                model.FirstName, 
                                                model.startDate, 
                                                model.endDate,
                                                totalPrice                                                
                                                ));

                MailMessage message = new MailMessage(from, to);
                message.Subject = "Reservation Details";
                //Διάβασε το template.txt
                string template = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/Content/templates/template.txt"));

                message.Body = string.Format(template, model.FirstName, model.LastName,model.startDate,model.endDate, string.Format("{0:C0}", totalPrice));
                message.IsBodyHtml = false;

                client.Send(message);
            }
        }
     

        public ActionResult CreateBooking(int id = 0)
        {
            if (id == 0)
            {
                Response.Redirect("~/Home/SearchAvalilableParkingTypes");
            }

            return View();
        }
    }
}