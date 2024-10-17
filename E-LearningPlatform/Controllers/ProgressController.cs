using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.DataAccess;
using System.Collections.Generic;
using System.Linq;
using E_LearningPlatform.DataAccess.Repository;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
namespace E_LearningPlatformWeb.Areas.Admin.Controllers
{
    public class ProgressController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProgressController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Progress> Progresses = unitOfWork.Progress.GetAll().ToList();
            return View(Progresses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Progress Progress)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Progress.Add(Progress);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Invalid Progress state";
                return RedirectToAction("Index");
            }
            Progress? ProgressFromDb = unitOfWork.Progress.Get(u => u.Id == id);
            if (ProgressFromDb == null)
            {
                TempData["Error"] = "Progress Not Found!";
                return RedirectToAction("Index");
            }
            return View(ProgressFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Progress Progress)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Progress.Update(Progress);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Invalid progress ID";
                return RedirectToAction("Index");
            }
            Progress? ProgressFromDb = unitOfWork.Progress.Get(u => u.Id == id);
            if (ProgressFromDb == null)
            {
                TempData["Error"] = "progress Not Found!";
                return RedirectToAction("Index");
            }
            return View(ProgressFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Progress? ProgressFromDb = unitOfWork.Progress.Get(u => u.Id == id);
            if (ProgressFromDb == null)
            {
                TempData["Error"] = "progress Not Found!";
                return RedirectToAction("Index");
            }
            unitOfWork.Progress.Remove(ProgressFromDb);
            unitOfWork.Save();
            TempData["success"] = "progress Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
