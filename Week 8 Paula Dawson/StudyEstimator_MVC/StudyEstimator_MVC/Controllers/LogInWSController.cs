using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyEstimator_MVC.Models;
using StudyEstimator_MVC.Models.Services;

namespace StudyEstimator_MVC.Controllers
{
    public class LogInWSController : Controller
    {
        //
        // GET: /LogInWS/
        private ILogInSVC_WS_Impl _LogOnWS = new ILogInSVC_WS_Impl();
        public LogInWSController() { }
        

        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(LogIn model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string retVal = _LogOnWS.AuthenticateLogIn(model.UserName, model.PassWord);
                if (retVal == "True")
                {
                    ModelState.AddModelError("", "The user is Authenticated with WS.");
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
