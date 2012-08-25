using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyEstimator_MVC.Models.Services
{
    public interface ILogInSVC
    {
        string AuthenticateLogIn(string username,string password);
    }
}