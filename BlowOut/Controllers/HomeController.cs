using BlowOut.DAL;
using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/***********************************************************
 * Status so far:
 * I have connected this project to a database and created the client and instrument tables.
 * I have changed the models to match the tables.
 * I have inserted the instrument information into the instrument table.
 * I have created the object that lets us speak with the database(db)
 * 
 * Left to do:
 * Because I changed the models, none of the controllers worked. 
 *      I deleted all of the code dealing with the instrument model.
 * Task: Recreate the pages we created before, using the database tables.
 *      - Reference the pictures
 *      - Determine New or Used Price
 * Create the capability to add clients to a database
 *      - Scaffold a client controller using the database tables
 * Create a 'Summary' View
 *      - Thank customer by name
 *      - Display all of the data discussed in the project requirements
 * Flush out the 'About' View
 * **********************************************************/

namespace BlowOut.Controllers
{
    public class HomeController : Controller
    {
        
        private BlowOutContext db = new BlowOutContext();

        public ActionResult Index()
        {
            return View();
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
