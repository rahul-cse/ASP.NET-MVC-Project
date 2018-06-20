using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;


namespace MvcApplication1.Controllers
{
    public class StudentDbController : Controller
    {

        long stdid;
        //
        // GET: /StudentDb/

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Studentdb(string search)
        {
            MvcDatabase1Entities1 db = new MvcDatabase1Entities1();
            StudentsInfo stdinfo = new StudentsInfo();
            Student_information_viewmodel vm = new Student_information_viewmodel();
            int StuId = Convert.ToInt32(search);
            var v = db.StudentsInfoes.Where(x=>x.StudentId==StuId ).SingleOrDefault();
            if (v != null)
            {
               // stdinfo = db.StudentsInfoes.SingleOrDefault();



                //udent_information_viewmodel vm = new Student_information_viewmodel();
                vm.StudentId = v.StudentId;
                vm.FirstName = v.FirstName;
                vm.LastName = v.LastName;
                vm.Class = v.Class;
                vm.Gender = v.Gender;



                //return View(vm);
            }
            return View(vm);
        }
        
        
        public ActionResult Insert(Student_information_viewmodel model)
        {
            try
            {
                MvcDatabase1Entities1 db = new MvcDatabase1Entities1();
                
                StudentsInfo stden = new StudentsInfo();
                
                stden.StudentId = model.StudentId;
                stden.FirstName = model.FirstName;
                stden.LastName = model.LastName;
                stden.Class = model.Class;
                stden.DateOfBirth = model.DateOfBirth;
                stden.Group = model.Group;
                stden.Gender = model.Gender;
                stden.PresentAddress = model.PresentAddress;

                stdid = model.StudentId;

                db.StudentsInfoes.Add(stden);

                db.SaveChanges();
               ViewBag.Message = "Your Student Information have saved";
                
                
                
            }
            catch (Exception ex)
            {
                // throw ex;
            }
           
           
            ModelState.Clear();
            return View();
        }
    }
}
