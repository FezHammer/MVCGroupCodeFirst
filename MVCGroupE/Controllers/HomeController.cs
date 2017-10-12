﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCGroupE.Models;

namespace MVCGroupE.Controllers
{
   
    public class HomeController : Controller
    {   
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var checkingStudentId = db.Students.Where(c => c.ApplicationUserId == userId).First().SiD;
            ViewBag.CheckingStudentId = checkingStudentId;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}