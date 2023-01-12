using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdmissionSystem.Models;

namespace AdmissionSystem.Controllers
{
    public class LogInsController : Controller
    {
        private AdmissionEntities4 db = new AdmissionEntities4();

        // GET: LogIns
        public ActionResult Index()
        {
            var logIns = db.LogIns.Include(l => l.Serial1).Include(l => l.Serial2);
            return View(logIns.ToList());
        }

        // GET: LogIns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // GET: LogIns/Create
        public ActionResult Create()
        {
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1");
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1");
            return View();
        }

        // POST: LogIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SchoolId,Serial,Pin")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.LogIns.Add(logIn);
                    db.SaveChanges();
                    return RedirectToAction("Create", "Students");
                }
                catch (Exception)
                {

                    ViewBag.errormessage = "Something went wrong with your serial please try again.";
                }
              
            }

            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1", logIn.Serial);
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1", logIn.Serial);
            return View(logIn);
        }

        // GET: LogIns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1", logIn.Serial);
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1", logIn.Serial);
            return View(logIn);
        }

        // POST: LogIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SchoolId,Serial,Pin")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1", logIn.Serial);
            ViewBag.Serial = new SelectList(db.Serials, "Serial1", "Serial1", logIn.Serial);
            return View(logIn);
        }

        // GET: LogIns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: LogIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LogIn logIn = db.LogIns.Find(id);
            db.LogIns.Remove(logIn);
            db.SaveChanges();
            return RedirectToAction("Index");
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
