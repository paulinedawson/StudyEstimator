//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using StudyEstimator_MVC.Models;
//using System.Web.SessionState;


//namespace StudyEstimator_MVC.Controllers
//{

//    public class StudyParametersController : Controller
//    {
//        //private StudyEstimateContext db = new StudyEstimateContext();

//        //
//        // GET: /StudyParameters/

//        public ViewResult Index()
//        {
           
            
//            var studyEstimates = db.StudyParameters.Include(a => a.Study).Include(a => a.Parameter);
//            return View(studyEstimates.ToList());
//           // return View(db.StudyParameters.ToList());
//        }

//        //
//        // GET: /StudyParameters/Details/5

//        public ViewResult Details(int id)
//        {
//            StudyParameters studyparameter = db.StudyParameters
//              .Include(i => i.Study)
//              .Include(i => i.Parameter)
//              .SingleOrDefault(x => x.StudyParametersID == id);

//            return View(studyparameter);
//        }

//        //
//        // GET: /StudyParameters/Create

//        public ActionResult Create()
//        {
//            //setup for a dropdown list when assigning parameters to studies
//            ViewBag.ParameterID = new SelectList(db.Parameters, "ParameterID", "Param_Item");
//            ViewBag.StudyID = new SelectList(db.Studies, "StudyID", "StudyName");
//            return View();
//        } 

//        //
//        // POST: /StudyParameters/Create

//        [HttpPost]
//        public ActionResult Create(StudyParameters studyparameters)
//        {
//            if (ModelState.IsValid)
//            {
//                db.StudyParameters.Add(studyparameters);
//                db.SaveChanges();
//                return RedirectToAction("Index");  
//            }

//            return View(studyparameters);
//        }
        
//        //
//        // GET: /StudyParameters/Edit/5
 
//        public ActionResult Edit(int id)
//        {
//            //setup for a dropdown list when assigning parameters to studies
//            ViewBag.ParameterID = new SelectList(db.Parameters, "ParameterID", "Param_Item");
//            ViewBag.StudyID = new SelectList(db.Studies, "StudyID", "StudyName");
            
//            StudyParameters studyparameters = db.StudyParameters
//             .Include(i => i.Study)
//             .Include(i => i.Parameter)
//             .SingleOrDefault(x => x.StudyParametersID == id);
            
//            return View(studyparameters);
            
//            //StudyParameters studyparameters = db.StudyParameters.Find(id);
//            //return View();
//        }

//        //
//        // POST: /StudyParameters/Edit/5

//        [HttpPost]
//        public ActionResult Edit(StudyParameters studyparameters)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(studyparameters).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(studyparameters);
//        }

//        //
//        // GET: /StudyParameters/Delete/5
 
//        public ActionResult Delete(int id)
//        {
//            StudyParameters studyparameters = db.StudyParameters
//              .Include(i => i.Study)
//              .Include(i => i.Parameter)
//              .SingleOrDefault(x => x.StudyParametersID == id);

//          //  StudyParameters studyparameters = db.StudyParameters.Find(id);
//            return View(studyparameters);
//        }

//        //
//        // POST: /StudyParameters/Delete/5

//        [HttpPost, ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int id)
//        {            
//            StudyParameters studyparameters = db.StudyParameters.Find(id);
//            db.StudyParameters.Remove(studyparameters);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            db.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}