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
    public class HighSchoolsController : Controller
    {
        private AdmissionEntities4 db = new AdmissionEntities4();

        // GET: HighSchools
        public ActionResult Index()
        {
            var highSchools = db.HighSchools.Include(h => h.ExamType1).Include(h => h.Region).Include(h => h.Year1);
            return View(highSchools.ToList());
        }

        // GET: HighSchools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighSchool highSchool = db.HighSchools.Find(id);
            if (highSchool == null)
            {
                return HttpNotFound();
            }
            return View(highSchool);
        }

        // GET: HighSchools/Create
        public ActionResult Create()
        {
            ViewBag.ExamType = new SelectList(db.ExamTypes, "ExamType1", "ExamType1");
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionId");
            ViewBag.Year = new SelectList(db.Years, "Year1", "Year1");
            return View();
        }

        // POST: HighSchools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HighSchoolId,NameOfSHS,P_O_Box,ClubAssociation,PositionHeld,IndexNumber,ExamType,RegionId,Year")] HighSchool highSchool)
        {
            if (ModelState.IsValid)
            {
                db.HighSchools.Add(highSchool);
                db.SaveChanges();
                return RedirectToAction("Create","CourseInfoes");
            }

            ViewBag.ExamType = new SelectList(db.ExamTypes, "ExamType1", "ExamType1", highSchool.ExamType);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionId", highSchool.RegionId);
            ViewBag.Year = new SelectList(db.Years, "Year1", "Year1", highSchool.Year);
            return View(highSchool);
        }

        // GET: HighSchools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighSchool highSchool = db.HighSchools.Find(id);
            if (highSchool == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExamType = new SelectList(db.ExamTypes, "ExamType1", "ExamType1", highSchool.ExamType);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionId", highSchool.RegionId);
            ViewBag.Year = new SelectList(db.Years, "Year1", "Year1", highSchool.Year);
            return View(highSchool);
        }

        // POST: HighSchools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HighSchoolId,NameOfSHS,P_O_Box,ClubAssociation,PositionHeld,IndexNumber,ExamType,RegionId,Year")] HighSchool highSchool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(highSchool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExamType = new SelectList(db.ExamTypes, "ExamType1", "ExamType1", highSchool.ExamType);
            ViewBag.RegionId = new SelectList(db.Regions, "RegionId", "RegionId", highSchool.RegionId);
            ViewBag.Year = new SelectList(db.Years, "Year1", "Year1", highSchool.Year);
            return View(highSchool);
        }

        // GET: HighSchools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HighSchool highSchool = db.HighSchools.Find(id);
            if (highSchool == null)
            {
                return HttpNotFound();
            }
            return View(highSchool);
        }

        // POST: HighSchools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HighSchool highSchool = db.HighSchools.Find(id);
            db.HighSchools.Remove(highSchool);
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
