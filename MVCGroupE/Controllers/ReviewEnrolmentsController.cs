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
    // Class marked to be only accable from admin lvl access 
    public class ReviewEnrolmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReviewEnrolments
        public ActionResult Index( string UserSearch)
        {
            var enrolments = db.Enrolments.Include(e => e.Course).Include(e => e.Students);
            return View(enrolments.ToList());

            //if (!string.IsNullOrEmpty(UserSearch))
            //{
            //    enrolments = enrolments.Where(s => s.Course.CourseName.Contains(UserSearch) || s.Course.CourseName.Contains(UserSearch));
            //}
        }
        public ActionResult IndexAdmin(string AdminSearch, string AdminSearchName)
        {
            var enrolments = db.Enrolments.Include(e => e.Course).Include(e => e.Students);

            if (!string.IsNullOrEmpty(AdminSearch))
            {
                enrolments = enrolments.Where(s => s.Course.CourseName.Contains(AdminSearch) || s.Course.CourseName.Contains(AdminSearch));
            }
            if (!string.IsNullOrEmpty(AdminSearchName))
            {
                enrolments = enrolments.Where(s => s.Students.Name.Contains(AdminSearchName) || s.Students.Name.Contains(AdminSearchName));
            }
            return View(enrolments.ToList());
        }

        // GET: ReviewEnrolments/Details/5
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

        // GET: ReviewEnrolments/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name");
            return View();
        }

        // POST: ReviewEnrolments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollId,SiD,CourseId,EnrolmentYear,EnrolmentSemester,Grade")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Enrolments.Add(enrolment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrolment.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", enrolment.SiD);
            return View(enrolment);
        }

        // GET: ReviewEnrolments/Edit/5
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

        // POST: ReviewEnrolments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollId,SiD,CourseId,EnrolmentYear,EnrolmentSemester,Grade")] Enrolment enrolment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enrolment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", enrolment.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", enrolment.SiD);
            return View(enrolment);
        }

        // GET: ReviewEnrolments/Delete/5
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

        // POST: ReviewEnrolments/Delete/5
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
