using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyEstimator_MVC.Controllers;
using System.Web.Mvc;
//using StudyEstimator_MVC.Models;

namespace TestProject1.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        [TestMethod]
        public void TestLogOn()
        {
            AccountController controller = new AccountController();
            
            // Act 
            ViewResult result = controller.LogOn() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
