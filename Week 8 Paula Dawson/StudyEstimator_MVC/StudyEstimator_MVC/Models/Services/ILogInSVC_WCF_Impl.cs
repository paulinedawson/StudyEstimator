using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyEstimator_MVC.ServiceReference1;

namespace StudyEstimator_MVC.Models.Services
{
    public class ILogInSVC_WCF_Impl : ILogInSVC
    {
        public string AuthenticateLogIn(string username, string password)
        {
            try
            {
                //call the WCF Service
                bool retVal = false;
                ServiceReference1.Service1Client proxy = new Service1Client();
                retVal = proxy.AuthUser(username, password);
                return retVal.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            } 
        }
    }
}