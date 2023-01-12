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
    public class StudentsController : Controller
    {
        private AdmissionEntities4 db = new AdmissionEntities4();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Gender1).Include(s => s.Nationality1).Include(s => s.Religion1);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.Gender = new SelectList(db.Genders, "Gender1", "Gender1");
            ViewBag.Nationality = new SelectList(db.Nationalities, "Nationality1", "Nationality1");
            ViewBag.Religion = new SelectList(db.Religions, "Religion1", "Religion1");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,FirstName,Surname,OtherName,Gender,DateOfBirth,Age,Image,PhoneNumber,EmailAddress,Hometown,P_O_Box,HouseAddress,Nationality,Religion")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Create","Guardians");
            }

            ViewBag.Gender = new SelectList(db.Genders, "Gender1", "Gender1", student.Gender);
            ViewBag.Nationality = new SelectList(db.Nationalities, "Nationality1", "Nationality1", student.Nationality);
            ViewBag.Religion = new SelectList(db.Religions, "Religion1", "Religion1");
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gender = new SelectList(db.Genders, "Gender1", "Gender1", student.Gender);
            ViewBag.Nationality = new SelectList(db.Nationalities, "Nationality1", "Nationality1", student.Nationality);
            ViewBag.Religion = new SelectList(db.Religions, "Religion1", "Religion1");
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,FirstName,Surname,OtherName,Gender,DateOfBirth,Age,Image,PhoneNumber,EmailAddress,Hometown,P_O_Box,HouseAddress,Nationality,Religion")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gender = new SelectList(db.Genders, "Gender1", "Gender1", student.Gender);
            ViewBag.Nationality = new SelectList(db.Nationalities, "Nationality1", "Nationality1", student.Nationality);
            ViewBag.Religion = new SelectList(db.Religions, "Religion1", "Religion1");
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
