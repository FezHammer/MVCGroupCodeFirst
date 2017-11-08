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
using Rotativa;





 





namespace MVCGroupE.Controllers
{
    public class FurtureClassesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FurtureClasses
        public ActionResult Index()
        {

            var furtureClasses = db.FurtureClasses.Include(f => f.Course).Include(f => f.Students);
            return View(furtureClasses.ToList());
        }

        public ActionResult DownloadPdf()
        {
            var furtureClasses = db.FurtureClasses.Include(f => f.Course).Include(f => f.Students);
            var courses = db.Courses;
            return new Rotativa.MVC.ViewAsPdf("Index", furtureClasses.ToList());
        }





        // GET: FurtureClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurtureClasses furtureClasses = db.FurtureClasses.Find(id);
            if (furtureClasses == null)
            {
                return HttpNotFound();
            }
            return View(furtureClasses);
        }

        // GET: FurtureClasses/Create
        public ActionResult Create()
        {
           
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: FurtureClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FurtureCourseID,CourseId,SiD,Year,Semester")] FurtureClasses furtureClasses)
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.Students.Where(c => c.ApplicationUserId == userId).First().SiD;
            furtureClasses.SiD = checkingStudentId;
            
              
                db.FurtureClasses.Add(furtureClasses);
                db.SaveChanges();
                return RedirectToAction("Index");
            

           
        }

        // GET: FurtureClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurtureClasses furtureClasses = db.FurtureClasses.Find(id);
            if (furtureClasses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", furtureClasses.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", furtureClasses.SiD);
            return View(furtureClasses);
        }

        // POST: FurtureClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FurtureCourseID,CourseId,SiD,Year,Semester")] FurtureClasses furtureClasses)
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.Students.Where(c => c.ApplicationUserId == userId).First().SiD;

          
                furtureClasses.SiD = checkingStudentId;
                db.Entry(furtureClasses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
         
        }

        // GET: FurtureClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FurtureClasses furtureClasses = db.FurtureClasses.Find(id);
            if (furtureClasses == null)
            {
                return HttpNotFound();
            }
            return View(furtureClasses);
        }

        // POST: FurtureClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FurtureClasses furtureClasses = db.FurtureClasses.Find(id);
            db.FurtureClasses.Remove(furtureClasses);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult GeneratePDF()
        //{
        //    return new Rotativa.ActionAsPdf("GetPersons");
        //}

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
