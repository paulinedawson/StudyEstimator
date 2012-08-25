using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyEstimator_MVC.Models.Services
{
    public class ILogInSVC_WS_Impl : ILogInSVC
    {
        public string AuthenticateLogIn(string username, string password)
        {
            HelloWS.Service1 ws = new HelloWS.Service1();
            bool s = ws.AuthUser(username, password);
            Console.WriteLine(s.ToString());
            Console.ReadLine();
            return s.ToString();
        }
    }
}