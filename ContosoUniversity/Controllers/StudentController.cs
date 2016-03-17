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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(new EditViewModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                EditViewModel evm = new EditViewModel();
                if (evm.Update(vm.Student) > 0)
                {
                    return RedirectToAction("Details", "Student", new { id = vm.Student.ID });
                }
                else
                {
                    return View(vm);
                }
            }

            return View(vm);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            DetailsViewModel dvm = new DetailsViewModel(id);
            
            if (dvm.Student == null)
            {
                return HttpNotFound();
            }
            return View(dvm);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EditViewModel evm = new EditViewModel(id);

            if (evm.Delete() > 0)
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View(evm);
            }
        }
    }
}