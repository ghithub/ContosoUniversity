using ContosoUniversity.DAL;
using ContosoUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers {
    public class StudentController : Controller
    {
        public ActionResult Index() {
            StudentsViewModel vm = new StudentsViewModel();
            return View(vm);
        }       
    }
}