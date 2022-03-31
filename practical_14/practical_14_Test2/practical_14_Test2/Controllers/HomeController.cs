using practical_14_Test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace practical_14_Test2.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Login()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Studentdata model, string returnUrl)
        {

            using (StudentEntities objContext = new StudentEntities())
            {
                var objUser = objContext.Studentdatas.FirstOrDefault(x => x.Sname == model.Sname && x.Password == model.Password);
                if (objUser == null)
                {
                    ModelState.AddModelError("LogOnError", "Something is incorrect.");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(model.Sname, true);

                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                       && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {

                        return RedirectToAction("Index");
                    }
                }
            }

            return View(model);
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}