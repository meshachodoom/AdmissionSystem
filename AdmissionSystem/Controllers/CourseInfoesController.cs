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
    public class CourseInfoesController : Controller
    {
        private AdmissionEntities4 db = new AdmissionEntities4();

        // GET: CourseInfoes
        public ActionResult Index()
        {
            var courseInfoes = db.CourseInfoes.Include(c => c.FeeStatu).Include(c => c.Hall1).Include(c => c.Program11).Include(c => c.Program21).Include(c => c.Program31).Include(c => c.Program41);
            return View(courseInfoes.ToList());
        }

        // GET: CourseInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInfo courseInfo = db.CourseInfoes.Find(id);
            if (courseInfo == null)
            {
                return HttpNotFound();
            }
            return View(courseInfo);
        }

        // GET: CourseInfoes/Create
        public ActionResult Create()
        {
            ViewBag.FeeStatus = new SelectList(db.FeeStatus, "FeeStatus", "FeeStatus");
            ViewBag.Hall = new SelectList(db.Halls, "Hall1", "Hall1");
            ViewBag.Program1 = new SelectList(db.Program1, "Program11", "Program11");
            ViewBag.Program2 = new SelectList(db.Program2, "Program21", "Program21");
            ViewBag.Program3 = new SelectList(db.Program3, "Program31", "Program31");
            ViewBag.Program4 = new SelectList(db.Program4, "Program41", "Program41");
            return View();
        }

        // POST: CourseInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Hall,FeeStatus,Program1,Program2,Program3,Program4")] CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                    db.CourseInfoes.Add(courseInfo);
                    db.SaveChanges();
                    return RedirectToAction("Register","CourseInfoes");
               
            }

            ViewBag.FeeStatus = new SelectList(db.FeeStatus, "FeeStatus", "FeeStatus", courseInfo.FeeStatus);
            ViewBag.Hall = new SelectList(db.Halls, "Hall1", "Hall1", courseInfo.Hall);
            ViewBag.Program1 = new SelectList(db.Program1, "Program11", "Program11", courseInfo.Program1);
            ViewBag.Program2 = new SelectList(db.Program2, "Program21", "Program21", courseInfo.Program2);
            ViewBag.Program3 = new SelectList(db.Program3, "Program31", "Program31", courseInfo.Program3);
            ViewBag.Program4 = new SelectList(db.Program4, "Program41", "Program41", courseInfo.Program4);
            return View(courseInfo);
        }
        public ActionResult Register()
        {
            return View();
        }

        // GET: CourseInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInfo courseInfo = db.CourseInfoes.Find(id);
            if (courseInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FeeStatus = new SelectList(db.FeeStatus, "FeeStatus", "FeeStatus", courseInfo.FeeStatus);
            ViewBag.Hall = new SelectList(db.Halls, "Hall1", "Hall1", courseInfo.Hall);
            ViewBag.Program1 = new SelectList(db.Program1, "Program11", "Program11", courseInfo.Program1);
            ViewBag.Program2 = new SelectList(db.Program2, "Program21", "Program21", courseInfo.Program2);
            ViewBag.Program3 = new SelectList(db.Program3, "Program31", "Program31", courseInfo.Program3);
            ViewBag.Program4 = new SelectList(db.Program4, "Program41", "Program41", courseInfo.Program4);
            return View(courseInfo);
        }

        // POST: CourseInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Hall,FeeStatus,Program1,Program2,Program3,Program4")] CourseInfo courseInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FeeStatus = new SelectList(db.FeeStatus, "FeeStatus", "FeeStatus", courseInfo.FeeStatus);
            ViewBag.Hall = new SelectList(db.Halls, "Hall1", "Hall1", courseInfo.Hall);
            ViewBag.Program1 = new SelectList(db.Program1, "Program11", "Program11", courseInfo.Program1);
            ViewBag.Program2 = new SelectList(db.Program2, "Program21", "Program21", courseInfo.Program2);
            ViewBag.Program3 = new SelectList(db.Program3, "Program31", "Program31", courseInfo.Program3);
            ViewBag.Program4 = new SelectList(db.Program4, "Program41", "Program41", courseInfo.Program4);
            return View(courseInfo);
        }

        // GET: CourseInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseInfo courseInfo = db.CourseInfoes.Find(id);
            if (courseInfo == null)
            {
                return HttpNotFound();
            }
            return View(courseInfo);
        }

        // POST: CourseInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseInfo courseInfo = db.CourseInfoes.Find(id);
            db.CourseInfoes.Remove(courseInfo);
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
