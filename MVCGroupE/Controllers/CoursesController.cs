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
    public class CoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ViewResult Index(string searchString)
        {
            var courses = from s in db.Courses
                          select s;
            if (!string.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.CategoryName.Contains(searchString) || s.CategoryName.Contains(searchString));
            }
            return View(courses.ToList());
        }
        [Authorize]
        public ViewResult Pathway()
        {
            string userId = User.Identity.GetUserName();
            userId = "'" + userId + "'";
            var Result = db.Database.SqlQuery<Course>("SELECT * FROM Courses as c INNER JOIN Enrolments as e ON c.PrerequisiteId = e.CourseID INNER JOIN Students as s ON s.[Sid] = e.[Sid]  where e.Grade > 50 AND s.Email =" + userId);
 

            return View(Result);
            
        }

        [Authorize]
        public ViewResult PathwayAdmin()
        {
            
            var ResulltAdmin = db.Database.SqlQuery<Course>("SELECT * FROM Courses as c INNER JOIN Enrolments as e ON c.PrerequisiteId = e.CourseID INNER JOIN Students as s ON s.[Sid] = e.[Sid]  where e.Grade > 50");

            return View(ResulltAdmin);

        }

     
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,CourseName,Description,semester,CategoryName,Year,PrerequisiteId,Compulsory")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,CourseName,Description,semester,CategoryName,Year,PrerequisiteId,Compulsory")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
