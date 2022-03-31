using Model.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
namespace Practical_12_2.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeelinqDataContext db = new EmployeelinqDataContext();
        DesignationLinqDataContext db1 = new DesignationLinqDataContext();
        // GET: Employee
        public ActionResult Index()
        {
            var desdata = from des in db.Employees select des;
           
            return View(desdata);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var desdata = from des in db.Employees select des;
            ViewBag.deslist = new SelectList(db1.Designations, "ID", "DesignationName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model.App_Data.Employee employee)
        {
            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges();
            return View();

        }
        public ActionResult Details(int id)
        {
            var model = db.Employees.Single(x => x.ID == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Employees.Single(x => x.ID == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Model.App_Data.Employee employee)
        {

            Model.App_Data.Employee des = db.Employees.Single(x => x.ID == employee.ID);
            des.FirstName = employee.FirstName;
            des.MiddleName = employee.MiddleName;
            des.LastName = employee.LastName;
            des.DOB = employee.DOB;
            des.MobileNumber = employee.MobileNumber;
            des.Salary = employee.Salary;
            des.Address = employee.Address;
            des.Designation_ID = employee.Designation_ID;
            db.SubmitChanges();
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            var model = db.Employees.Single(x => x.ID == id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            var model = db.Employees.Single(x => x.ID == id);

            db.Employees.DeleteOnSubmit(model);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}