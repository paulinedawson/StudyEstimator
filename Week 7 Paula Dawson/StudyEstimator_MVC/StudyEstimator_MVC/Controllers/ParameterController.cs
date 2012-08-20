//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using StudyEstimator_MVC.Models;

//namespace StudyEstimator_MVC.Controllers
//{ 
//    public class ParameterController : Controller
//    {
//        //private StudyEstimateContext db = new StudyEstimateContext();

//        //
//        // GET: /Parameter/

//        public ViewResult Index()
//        {
//            return View(db.Parameters.ToList());
//        }

//        //
//        // GET: /Parameter/Details/5

//        public ViewResult Details(int id)
//        {
//           // Parameter parameter = db.Parameters.Find(id);
//           // return View(parameter);
//        }

//        //
//        // GET: /Parameter/Create

//        public ActionResult Create()
//        {
//            return View();
//        } 

//        //
//        // POST: /Parameter/Create

//        [HttpPost]
//        public ActionResult Create(Parameter parameter)
//        {
//            if (ModelState.IsValid)
//            {
//                //db.Parameters.Add(parameter);
//                //db.SaveChanges();
//                return RedirectToAction("Index");  
//            }

//            return View(parameter);
//        }
        
//        //
//        // GET: /Parameter/Edit/5
 
//        public ActionResult Edit(int id)
//        {
//            //Parameter parameter = db.Parameters.Find(id);
//            //return View(parameter);
//        }

//        //
//        // POST: /Parameter/Edit/5

//        [HttpPost]
//        public ActionResult Edit(Parameter parameter)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(parameter).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(parameter);
//        }

//        //
//        // GET: /Parameter/Delete/5
 
//        public ActionResult Delete(int id)
//        {
//            Parameter parameter = db.Parameters.Find(id);
//            return View(parameter);
//        }

//        //
//        // POST: /Parameter/Delete/5

//        [HttpPost, ActionName("Delete")]
//        public ActionResult DeleteConfirmed(int id)
//        {            
//            Parameter parameter = db.Parameters.Find(id);
//            db.Parameters.Remove(parameter);
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