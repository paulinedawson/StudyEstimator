using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyEstimator_MVC.Controllers;
using StudyEstimator_MVC.Models;

namespace TestProject1.Controllers
{
    [TestClass]
    public class StudyControllerTest
    {
               
            [TestMethod]
            public void TestViewStudy()
            {
                // Arrange
               StudyController controller = new StudyController();
               Study study = new Study();
               study.StudyCreated = DateTime.Parse("2/2/2012");
               study.StudyManager = "Paula Dawson";
               study.StudyName = "New StudyName2";
                // Act 
                ViewResult result = controller.Create(study) as ViewResult;

                // Assert
                Assert.IsNotNull(result);
            }
  
    }
}
