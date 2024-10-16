using Microsoft.AspNetCore.Mvc;
using TechneStore.DataAccess;
using System.Collections.Generic;
using System.Linq;
using TechneStore.DataAccess.Repository;
using TechneStore.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
namespace TechneStoreWeb.Areas.Admin.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public EnrollmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Enrollment> enrollments = unitOfWork.Enrollment.GetAll().ToList();
            return View(enrollments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Enrollment.Add(enrollment);
                unitOfWork.Save();
                TempData["success"] = "Done!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error";
            return View("Create");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Done!";
                return RedirectToAction("Index");
            }
            Enrollment? enrollmentFromDb = unitOfWork.Enrollment.Get(u => u.Id == id);
            if (enrollmentFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(enrollmentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Enrollment.Update(enrollment);
                unitOfWork.Save();
                TempData["success"] = "Enrollment Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error ";
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Done!";
                return RedirectToAction("Index");
            }
            Enrollment? enrollmentFromDb = unitOfWork.Enrollment.Get(u => u.Id == id);
            if (enrollmentFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(enrollmentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Enrollment? enrollmentFromDb = unitOfWork.Enrollment.Get(u => u.Id == id);
            if (enrollmentFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            unitOfWork.Enrollment.Remove(enrollmentFromDb);
            unitOfWork.Save();
            TempData["success"] = "Enrollment Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
