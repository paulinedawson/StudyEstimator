using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyEstimator_MVC.Models;


namespace StudyEstimator_MVC.Controllers
{
    public class HomeController : Controller
    {
 
        public ActionResult Index()
        {
           //adding a session variable
            Session["CurrentStudy"] = "Study One is the Best!";
            
            ViewBag.Message = "Welcome to the Study Estimator!";

            //return View();
            return View(HttpContext.Application["SiteCounter"] as string); 
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
