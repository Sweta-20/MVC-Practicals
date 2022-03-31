using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using static practical_09.App_Start.Filter;

namespace practical_09.Controllers
{
    public class HomeController : Controller
    {
        public class Emp
        {
            public string EID { get; set; }
            public string EName { get; set; }
            public string Salary { get; set; }
        }
        public JsonResult jsonResult()
        {
            //https://localhost:44379/Home/JsonResult/
            //JSonResult Pass in Emp method
            Emp emp = new Emp()//create Emp object
            {
                EID = "101",
                EName = "Deval Patel",
                Salary = "33000"
            };
            return Json(emp, JsonRequestBehavior.AllowGet);
        }
        //GET: Item
        public EmptyResult emptyResult()
        {
            ViewBag.ItemList = "This is emptyResult...";/*https://localhost:44379/Home/emptyResult*/
            return new EmptyResult();
        }

        public RedirectResult redirectResult()//https://localhost:44379/Home/RedirectResult/
        {
            return Redirect("Home/Contact");
        }

        [HandleError]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult jsResult()
        {
            return new JavaScriptResult("window.location.href = 'http://ontime.simformsolutions.com/login/'");
        }

        public class JavaScriptResult : ContentResult
        {
            public JavaScriptResult(string script)
            {
                this.Content = script;
                this.ContentType = "application/javascript";
            }
        }

        public ContentResult contentResult()//https://localhost:44379/Home/ContentResult
        {
            return Content("Hello ASP.NET MVC 5", "text/plain", System.Text.Encoding.UTF8);
        }

        public FileContentResult DownloadContent()//https://localhost:44379/Home/DownloadContent
        {
            var myfile = System.IO.File.ReadAllBytes("C:/Users/deval/Desktop/helloworld.txt");
            return new FileContentResult(myfile, "application/txt");
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}
        [OutputCache(Duration =360)]
        public ActionResult DateTest()
        {
            ViewBag.date = DateTime.Now.ToString();
            return View();
        }
        [MyExceptionFilter]
        public int Exception()
        {
            int a = 65;
            int b = 0;
            int c = a / b; 
            return c;
        }

        public class MyExceptionFilter : FilterAttribute, IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                if (!filterContext.ExceptionHandled)
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "Error"
                    }; 
                }
                filterContext.ExceptionHandled = true;
            }
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}