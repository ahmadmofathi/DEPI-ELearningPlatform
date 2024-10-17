using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using TechneStore.DataAccess.Repository.IRepository;

namespace E_LearningPlatform.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Category> categories = unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Add(category);
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
            Category? CategoryFromDb = unitOfWork.Category.Get(u => u.CategoryId == id);
            if (CategoryFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(CategoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Update(category);
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
            Category? CategoryFromDb = unitOfWork.Category.Get(u => u.CategoryId == id);
            if (CategoryFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(CategoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? CategoryFromDb = unitOfWork.Category.Get(u => u.CategoryId == id);
            if (CategoryFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            unitOfWork.Category.Remove(CategoryFromDb);
            unitOfWork.Save();
            TempData["success"] = "Enrollment Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
