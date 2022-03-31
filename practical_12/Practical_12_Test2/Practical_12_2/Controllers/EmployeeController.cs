using Model.App_Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Practical_12_2.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeelinqDataContext db = new EmployeelinqDataContext();
        DesignationDataContext db1 = new DesignationDataContext();
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> employees = db.Employees.ToList();
            List<Designation> designations = db1.Designations.ToList();
            var Emp = from e in employees
                      join d in designations on e.Designation_ID equals d.Id
                      select new ViewModel
                      {
                            employee = e,
                            designation = d
                      };
            ;
           // var desdetails = from des in db.Employees select des;
           
            return View(Emp);
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
        public ActionResult Create(Employee employee)
        {

            db.Employees.InsertOnSubmit(employee);
            db.SubmitChanges();
            return RedirectToAction("Index");

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
        public ActionResult Edit(Employee employee)
        {

            Employee des = db.Employees.Single(x => x.ID == employee.ID);
            des.FName = employee.FName;
            des.MName = employee.MName;
            des.LName = employee.LName;
            des.DOB = employee.DOB;
            des.MobileNumber = employee.MobileNumber;
            des.Salary = employee.Salary;
            des.Address = employee.Address;
            des.Designation_ID = employee.Designation_ID;
            db.SubmitChanges();
            return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult CountRecord()
        {
            List<Employee> emp = db.Employees.ToList();
            List<Designation> des = db1.Designations.ToList();

            var QSCount1 = (from employee in emp
                            join sa in db1.Designations on employee.Designation_ID equals sa.Id
                            group sa by sa.DesignationName into data
                            select new CountR
                            {
                                DesignationName = data.Max(r => r.DesignationName),
                                Cnt = data.Count(),
                            });
            string json = JsonConvert.SerializeObject(QSCount1);
            List<CountR> countEmps = JsonConvert.DeserializeObject<List<CountR>>(json);
            return View(countEmps);
        }
    }
}