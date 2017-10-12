using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Microsoft.AspNet.Identity;
using MVCGroupE.Models;

namespace MVCGroupE.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {   
      //  private ApplicationDbContext db = new ApplicationDbContext();
      //  [Authorize]
        public ActionResult Index()
        {
            //var userId = User.Identity.GetUserId();
            //var checkingAccountId = db.Users.Where(c => c.Id == userId);
            //ViewBag.CheckingAccountId = checkingAccountId;
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