using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyEstimator_MVC.Models;
using StudyEstimator_MVC.Models.Services;

namespace StudyEstimator_MVC.Controllers
{ 
    public class LogInWCFController : Controller
    {
        private ILogInSVC_WCF_Impl _LogOnWCF = new ILogInSVC_WCF_Impl();
        public LogInWCFController() { }
        //
        // GET: /LogInWCF/

        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(LogIn model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string retVal = _LogOnWCF.AuthenticateLogIn(model.UserName, model.PassWord);
                if (retVal == "True")
                {
                    ModelState.AddModelError("", "The user is Authenticated with WCF.");
                }
                else if (retVal == "False")
                {
                    ModelState.AddModelError("", "The user is not Authenticated.");
                }
                else
                {
                    ModelState.AddModelError("", retVal + " Did you start the service?");
                }
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}