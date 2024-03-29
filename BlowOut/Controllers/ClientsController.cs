﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class ClientsController : Controller
    {
        private BlowOutContext db = new BlowOutContext();
        public static Instrument rentInstrument = new Instrument();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create(int ID, string rentType)
        {
            rentInstrument.Instrument_ID = ID;
            rentInstrument.Rent_Type = rentType;

            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_ID,First_Name,Last_Name,Address,City,State,Zip,Email,Phone_Number")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);                
                db.SaveChanges();
                
                db.Instruments.Find(rentInstrument.Instrument_ID).Client_ID =
                    db.Database.SqlQuery<int>("SELECT MAX(Client_Id) FROM Client").First();
                
                        
                db.SaveChanges();
                return RedirectToAction("Summary");
            }

            return View(client);
        }

        public ActionResult Summary()
        {
            string clientName = db.Database.SqlQuery<string>
                    ("SELECT First_Name FROM Client WHERE Client_Id = " +
                    db.Instruments.Find(rentInstrument.Instrument_ID).Client_ID).First();

            ViewBag.Client = clientName;

            return View(db.Instruments.Find(rentInstrument.Instrument_ID));
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Client_ID,First_Name,Last_Name,Address,City,State,Zip,Email,Phone_Number")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UpdateData", "Instruments");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);            
            db.SaveChanges();
            Instrument editInstrument = db.Database.SqlQuery<Instrument>("SELECT * FROM Instrument WHERE Client_ID = " + id).First();
            editInstrument.Client_ID = null;
            return RedirectToAction("UpdateInstrument", "Instruments", editInstrument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
