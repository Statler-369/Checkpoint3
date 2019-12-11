using BlowOut.DAL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        
        private BlowOutContext db = new BlowOutContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(email, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return RedirectToAction("UpdateData", "Instruments");

            }
            else
            {
                return View();
            }
        }

        public ActionResult Rentals()
        {            

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult RentInstrument(int Instrument_ID)
        {

            return View(db.Instruments.Find(Instrument_ID));
        }
        
        public ActionResult RentPrice(string sName, string rentType)
        {
            ViewBag.Rent = rentType;
            return View();
        }
    }
}
