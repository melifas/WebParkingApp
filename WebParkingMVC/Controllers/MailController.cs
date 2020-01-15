using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebParkingMVC.Models;
using System.Net;
using System.Net.Mail;

/*namespace WebParkingMVC.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
       *//* public ActionResult SendEmail(WebParkingMVC.Models.gmailModel model)
        {
            MailMessage mm = new MailMessage("melifas1978@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host= "smtp.gmail.com";
            smtp.Port = 465;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("melifas1978@gmail.com", "y4854001");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Succesfully delivred";
            return View();
        }*//*

        
    }
}*/