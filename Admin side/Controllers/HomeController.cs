using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin_side.Models;

namespace Admin_side.Controllers
{
    public class HomeController : Controller
    {
        dbmsProject01Entities2 db = new dbmsProject01Entities2();
        
        public ActionResult Adminlogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adminlogin(tbladmin log)
        {
            var na = db.tbladmins.Where(x => x.AdminName == log.AdminName && x.Password == log.Password).Count();

       
            
            //var val = new SelectList(db.loginusers, "UserID", "Username");
          

            if (na > 0)
            {
               
                return RedirectToAction("Index", "Home");
            }

            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();

            }

        }
        public ActionResult Index()
        {
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