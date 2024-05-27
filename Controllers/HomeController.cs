using Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Projekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
        public ActionResult Contact()
        {
            
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendMessage(KontaktFormaModel model)
        {
            if (ModelState.IsValid)
            {
               
                var fromAddress = new MailAddress(model.Email, model.Ime);
                var toAddress = new MailAddress("firm@example.com", "Firma");
                const string fromPassword = "yourpassword"; 
                string subject = model.Naslov;
                string body = model.Poruka;

               
                var smtp = new SmtpClient
                {
                    Host = "smtp.your-email-provider.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }

                
                ViewBag.Message = "Vaša poruka je uspješno poslana!";
                return View("Contact");
            }

           
            return View("Contact", model);
        }
    }
}