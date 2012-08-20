using System;
using System.Data.Entity;
using System.Collections.Generic;

namespace StudyEstimator_MVC.Models
{
    public class Study
    {
        public int StudyID { get; set; }
        public string StudyName { get; set; }
        public string StudyManager { get; set; }
        public DateTime StudyCreated { get; set; }


    }

    public class Parameter
    {
        public int ParameterID { get; set; }
        public string Param_Item { get; set; }
    }

    public class StudyParameters
    {
        public int StudyParametersID { get; set; }
        public int StudyID { get; set; }
        public int ParameterID { get; set; }      
        public int Qty { get; set; }
        public decimal Cost { get; set; }

        public Study Study { get; set; }
        public Parameter Parameter { get; set; }
    }

    //public class StudyEstimateContext : DbContext
    //{
    //    public DbSet<Study> Studies { get; set; }
    //    public DbSet<Parameter> Parameters { get; set; }
    //    public DbSet<StudyParameters> StudyParameters { get; set; }
    //}
    
}