using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyEstimator_MVC.Models.Services
{
    public interface IStudySVC
    {
        Study FindStudy(int id); 
        List<Study> FindAllStudies();
        Study StoreStudy(Study study);
        Study UpdateStudy(Study study);
        int DeleteStudy(int studyID);   

    }
}