using practical_10.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practical_10.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EmpDetailsEntities1 emp = new EmpDetailsEntities1();
        public ActionResult Employee(EmpTbl obj)
        {
                return View(obj);
        }
        public ActionResult Add(EmpTbl model)
        {
           
            if (ModelState.IsValid)
            {
                EmpTbl obj = new EmpTbl();
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.DOB = model.DOB;
                obj.Address = model.Address;

                if (model.Id == 0)
                {
                    emp.EmpTbls.Add(obj);
                    emp.SaveChanges();
                    return RedirectToAction("EmpView");
                }
                else
                {
                    emp.Entry(obj).State = EntityState.Modified;
                    emp.SaveChanges();
                    return RedirectToAction("EmpView");
                }
            }
            ModelState.Clear();
            return View("Employee");
            return RedirectToAction("EmpView");
        }
        
        public ActionResult EmpView()
        {
            var v = emp.EmpTbls.ToList();
            return View(v);
        }
        public ActionResult Delete(int id)
        {
            var data = emp.EmpTbls.Where(x => x.Id == id).First();
            emp.EmpTbls.Remove(data);
            emp.SaveChanges();
            var list = emp.EmpTbls.ToList();
            return View("EmpView",list);
        }

    }
}