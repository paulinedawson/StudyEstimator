using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudyEstimator_MVC.Models
{
    public class LogIn
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }

    //public class LogInWCFContext : DbContext
    //{
    //    public DbSet<LogInWCF> LogInWCF { get; set; }

    //}

}