using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practical_09.Controllers
{
    public class EmpController : Controller
    {
        [Route]
        public ActionResult find(string name)
        {
            var i = Server.HtmlEncode(name);
            return Content(i);
        }
        //GET: Emp
        //public ActionResult Index()
        //{
        //    return View();
        //}


    }
}