using Model;
using Model.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practical_12_2.Controllers
{
    public class DesignationController : Controller
    {
        DesignationLinqDataContext db = new DesignationLinqDataContext();
        // GET: Designation
        public ActionResult Index()
        {
            var desdata = from des in db.Designations select des;
            
            return View(desdata);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model.App_Data.Designation designation)
        {
            db.Designations.InsertOnSubmit(designation);
            db.SubmitChanges();
            return View();
            
        }
        public ActionResult Details(int id)
        {
            var model = db.Designations.Single(x => x.ID == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Designations.Single(x => x.ID == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model.App_Data.Designation designation)
        {

            Model.App_Data.Designation des = db.Designations.Single(x => x.ID == designation.ID);
            des.DesignationName = designation.DesignationName;
            db.SubmitChanges();
            return View(designation);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Designations.Single(x => x.ID == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,FormCollection form)
        {
            var model = db.Designations.Single(x => x.ID == id);
            
            db.Designations.DeleteOnSubmit(model);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}