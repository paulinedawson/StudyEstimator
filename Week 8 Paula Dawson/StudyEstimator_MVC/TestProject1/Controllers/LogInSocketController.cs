using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyEstimator_MVC.Controllers;
using StudyEstimator_MVC.Models;
using System.Web.Mvc;

namespace TestProject1.Controllers
{
    [TestClass]
    public class LogInSocketControllerTest
    {
        [TestMethod]
        public void TestMethodSocketLogOn()
        {
            LogInSocketController controller = new LogInSocketController();
            LogIn LogOn = new LogIn();
            LogOn.PassWord = "223344";
            LogOn.UserName = "pdawson";          
           
            // Act 
            ViewResult result = controller.LogOn(LogOn,"") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
