using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        private List<Instrument> instrumentList = new List<Instrument>
        {
            new Instrument{InstrumentName = "Trumpet", NewPrice=55, UsedPrice=25},
            new Instrument{InstrumentName = "Trombone", NewPrice=60, UsedPrice=35},
            new Instrument{InstrumentName = "Tuba", NewPrice=70, UsedPrice=50},
            new Instrument{InstrumentName = "Flute", NewPrice=40, UsedPrice=25},
            new Instrument{InstrumentName = "Clarinet", NewPrice=35, UsedPrice=27},
            new Instrument{InstrumentName = "Saxophone", NewPrice=42, UsedPrice=30}
        };


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Rentals()
        {            

            return View();
        }

        public ActionResult RentInstrument(string sName)
        {

            return View(instrumentList.Find(item => item.InstrumentName == sName));
        }

        public ActionResult RentPrice(string sName, string rentType)
        {
            ViewBag.Rent = rentType; //Pass the view the type of rental the person would like.
            return View(instrumentList.Find(instrument => instrument.InstrumentName == sName));
        }
    }
}