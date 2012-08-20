using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyEstimator_MVC.Models;
using StudyEstimator_MVC.Models.Services;

namespace StudyEstimator_MVC.Controllers
{ 
    public class StudyController : Controller
    {

        private IStudySvcSQLImpl _study = new IStudySvcSQLImpl();
        public StudyController() { }
  
        //public StudyController(IStudySVC study)
        //{
        //    //this._study = _study;
        //    _study = study;
        //} 

        // GET: /Study/
        public ViewResult Index()
        {
            //return View();
            return View(_study.FindAllStudies().ToList());
      }

        //
        // GET: /Study/Details/5

        public ViewResult Details(int id)
        {
            Study study = _study.FindStudy(id);
            return View(study);
        }

        //
        // GET: /Study/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Study/Create

        [HttpPost]
        public ActionResult Create(Study study)
        {
            if (ModelState.IsValid)
            {
                _study.StoreStudy(study);
                //db.Studies.Add(study);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_study);
        }
        
        //
        // GET: /Study/Edit/5
 
        public ActionResult Edit(int id)
        {
            //Study study = db.Studies.Find(id);
            Study study = _study.FindStudy(id);
            return View(study);
        }

        //
        // POST: /Study/Edit/5

        [HttpPost]
        public ActionResult Edit(Study study)
        {
            if (ModelState.IsValid)
            {
             //   db.Entry(study).State = EntityState.Modified;
               // db.SaveChanges();

                _study.UpdateStudy(study);
                return RedirectToAction("Index");
            }
            return View(_study);
        }

        //
        // GET: /Study/Delete/5
 
        public ActionResult Delete(int id)
        {
          //  Study study = db.Studies.Find(id);
            _study.FindStudy(id);
            return View(_study);
        }

        //
        // POST: /Study/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Study study = _study.FindStudy(id);
            _study.DeleteStudy(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
          //  base.Dispose(disposing);
        }
    }
}