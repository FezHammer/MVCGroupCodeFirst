using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCGroupE.Models;
using Microsoft.AspNet.Identity;

namespace MVCGroupE.Controllers
{
    public class NewEnrolmentsController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NewEnrolments
        public ActionResult Index(string UserSearch)
        {
            var enrolments = db.Enrolments.Include(e => e.Course).Include(e => e.Students);
            if (!string.IsNullOrEmpty(UserSearch))
            {
                enrolments = enrolments.Where(s => s.Course.CourseName.Contains(UserSearch) || s.Course.CourseName.Contains(UserSearch));
            }
            return View(enrolments.ToList());
        }

        // GET: NewEnrolments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = db.Enrolments.Find(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }

        // GET: NewEnrolments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name");
            return View();
        }

        // POST: NewEnrolments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollId,SiD,CourseId,EnrolmentYear,EnrolmentSemester,Grade")] Enrolment enrolment)
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.Students.Where(c => c.ApplicationUserId == userId).First().SiD;


            if (ModelState.IsValid)
            {
                enrolment.SiD = checkingStudentId;
                db.Enrolments.Add(enrolment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrolment.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", enrolment.SiD);
            return View(enrolment);
        }

        // GET: NewEnrolments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = db.Enrolments.Find(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrolment.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", enrolment.SiD);
            return View(enrolment);
        }

        // POST: NewEnrolments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollId,SiD,CourseId,EnrolmentYear,EnrolmentSemester,Grade")] Enrolment enrolment)
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.Students.Where(c => c.ApplicationUserId == userId).First().SiD;


            if (ModelState.IsValid)
            {
                enrolment.SiD = checkingStudentId;
                db.Entry(enrolment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrolment.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", enrolment.SiD);
            return View(enrolment);
        }

        // GET: NewEnrolments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrolment enrolment = db.Enrolments.Find(id);
            if (enrolment == null)
            {
                return HttpNotFound();
            }
            return View(enrolment);
        }

        // POST: NewEnrolments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrolment enrolment = db.Enrolments.Find(id);
            db.Enrolments.Remove(enrolment);
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
