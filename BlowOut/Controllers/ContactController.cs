using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Message = "Please call Support at <strong><u>801-555-1212</u></strong>. Thank you!";
            return View();
        }

        [Route("Contact/Email/{email}/{name}")]
        public ActionResult Email(string email, string name)
        {
            ViewBag.Message = "Thank you " + name + ". We will send an email to " + email + ".";

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("statlertest", "Yellowjackets1");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("statlertest@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Blow Out";
            mailMessage.Body = "Thank you for contacting BlowOut Instrument Rentals! Let us know how we can best help you.";
            client.Send(mailMessage);

            return View("Index");
        }
    }
}