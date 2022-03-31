
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
        DesignationDataContext database = new DesignationDataContext();
        // GET: Designation
        public ActionResult Index()
        {
            var desdata = from des in database.Designations select des;
            
            return View(desdata);
            
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Designation designation)
        {
            database.Designations.InsertOnSubmit(designation);
            database.SubmitChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult Details(int id)
        {
            var model = database.Designations.Single(x => x.Id == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = database.Designations.Single(x => x.Id == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Designation designation)
        {

            Model.App_Data.Designation des = database.Designations.Single(x => x.Id == designation.Id);
            des.DesignationName = designation.DesignationName;
            database.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var model = database.Designations.Single(x => x.Id == id);
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
            var model = database.Designations.Single(x => x.Id == id);

            database.Designations.DeleteOnSubmit(model);
            database.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}