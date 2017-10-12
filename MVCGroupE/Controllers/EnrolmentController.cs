using MVCGroupE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MVCGroupE.Controllers
{
    [Authorize]
    public class EnrolmentController : Controller
    {   
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enrolment
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Index(Enrolment Enrolment)
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.Students.Where(c => c.ApplicationUserId == userId).First().SiD;
            //string test = checkingStudentId;

            Enrolment.SiD = checkingStudentId;
           
            //if (ModelState.IsValid)
            //{
                db.Enrolments.Add(Enrolment);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            //}
            //return View();
        }
        
    }
}