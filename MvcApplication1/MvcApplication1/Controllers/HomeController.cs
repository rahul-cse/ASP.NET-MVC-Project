using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Admin()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(Admin_Login u)
        {
            if(ModelState.IsValid)
            {
                using (MvcDatabase1Entities de = new MvcDatabase1Entities())
               {
                    var v = de.Admin_Login.Where(a => a.username.Equals(u.username) && a.password.Equals(u.password)).FirstOrDefault(); { }
                    
                    if (v != null)
                    {
                        Session["Loggedusername"] = v.username.ToString();
                        return RedirectToAction("After_Login");
                    }
                    else
                        ViewBag.info = "Your Admin information is incorrect";
                }
            }
            return View(u);
        }

        public ActionResult After_Login()
        {
            if (Session["Loggedusername"] == null)
            {
                return RedirectToAction("Admin");
            }
            return View();
        }

        public ActionResult Insert_Notice()
        {
            return View();
        } 
    }
}
