using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class userstudentdbController : Controller
    {
        //
        // GET: /userstudentdb/

        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult ustudb(string search)
        {
            MvcDatabase1Entities1 db = new MvcDatabase1Entities1();
            StudentsInfo stdinfo = new StudentsInfo();
            Student_information_viewmodel vm = new Student_information_viewmodel();
            int StuId = Convert.ToInt32(search);
            var v = db.StudentsInfoes.Where(x => x.StudentId == StuId).SingleOrDefault();
            if (v != null)
            {
                // stdinfo = db.StudentsInfoes.SingleOrDefault();



                //udent_information_viewmodel vm = new Student_information_viewmodel();
                vm.StudentId = v.StudentId;
                vm.FirstName = v.FirstName;
                vm.LastName = v.LastName;
                vm.Class = v.Class;
                vm.Gender = v.Gender;
                vm.PresentAddress = v.PresentAddress;



                //return View(vm);
            }
            return View(vm);
        }

    }
}
