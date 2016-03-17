using ContosoUniversity.DAL;
using ContosoUniversity.Models;
using ContosoUniversity.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.Controllers {
    public class StudentController : Controller
    {
        public ActionResult Index() {
            StudentsViewModel vm = new StudentsViewModel();
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DetailsViewModel vm = new DetailsViewModel(id);

            if (vm.Student == null)
            {
                return HttpNotFound();
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CreateViewModel vm = new CreateViewModel(viewModel.Student.LastName, viewModel.Student.FirstMidName, viewModel.Student.EnrollmentDate);
                if (vm.SaveStudent() > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("DB Error", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new EditViewModel(id));
        }

    }
}