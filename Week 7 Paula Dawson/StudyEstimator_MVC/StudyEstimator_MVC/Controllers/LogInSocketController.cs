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
    public class LogInSocketController : Controller
    {
        private ILogInSVC_Sockets_Impl _LogOnSocket = new ILogInSVC_Sockets_Impl();
        public LogInSocketController() { }
        //
        // GET: /LogInSocket/

        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(LogIn model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string retVal = _LogOnSocket.AuthenticateLogIn(model.UserName, model.PassWord);
                if (retVal == "True")
                {
                    ModelState.AddModelError("", "The user is Authenticated with Sockets.");
                }
                else if (retVal == "False")
                {
                    ModelState.AddModelError("", "The user is not Authenticated.");
                }
                else
                {
                    ModelState.AddModelError("", retVal);
                }
                
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}