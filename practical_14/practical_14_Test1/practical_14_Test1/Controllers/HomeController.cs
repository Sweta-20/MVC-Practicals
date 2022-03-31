using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace practical_14_Test1.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Users = @"SF-CPU-311\deval")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Users = @"SF-CPU-311\SimformSolutions")]
        public ActionResult SimformLogin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}