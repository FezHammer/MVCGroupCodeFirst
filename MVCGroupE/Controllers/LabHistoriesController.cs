using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCGroupE.Models;

namespace MVCGroupE.Controllers
{
    public class LabHistoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LabHistories
        public ActionResult Index()
        {
            var labHistories = db.LabHistories.Include(l => l.Course).Include(l => l.Students);
            return View(labHistories.ToList());
        }

        // GET: LabHistories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabHistory labHistory = db.LabHistories.Find(id);
            if (labHistory == null)
            {
                return HttpNotFound();
            }
            return View(labHistory);
        }

        // GET: LabHistories/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name");
            return View();
        }

        // POST: LabHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LabId,CourseId,SiD,LabDate,Attended")] LabHistory labHistory)
        {
            if (ModelState.IsValid)
            {
                db.LabHistories.Add(labHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", labHistory.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", labHistory.SiD);
            return View(labHistory);
        }

        // GET: LabHistories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabHistory labHistory = db.LabHistories.Find(id);
            if (labHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", labHistory.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", labHistory.SiD);
            return View(labHistory);
        }

        // POST: LabHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LabId,CourseId,SiD,LabDate,Attended")] LabHistory labHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(labHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName", labHistory.CourseId);
            ViewBag.SiD = new SelectList(db.Students, "SiD", "Name", labHistory.SiD);
            return View(labHistory);
        }

        // GET: LabHistories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LabHistory labHistory = db.LabHistories.Find(id);
            if (labHistory == null)
            {
                return HttpNotFound();
            }
            return View(labHistory);
        }

        // POST: LabHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LabHistory labHistory = db.LabHistories.Find(id);
            db.LabHistories.Remove(labHistory);
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
