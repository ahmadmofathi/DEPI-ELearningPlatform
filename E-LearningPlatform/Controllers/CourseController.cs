using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using E_LearningPlatform.DataAccess.Repository.IRepository;

namespace E_LearningPlatform.Controllers
{
    public class CourseController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CourseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Course> courses = unitOfWork.Course.GetAll().ToList();
            return View(courses);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(unitOfWork.Category.GetAll().ToList(), "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Course.Add(course);
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
            Course? courseFromDb = unitOfWork.Course.Get(u => u.CourseId == id);
            ViewData["CategoryId"] = new SelectList(unitOfWork.Category.GetAll().ToList(), "CategoryId", "CategoryName");
            if (courseFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(courseFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Course.Update(course);
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
            Course? CourseFromDb = unitOfWork.Course.Get(u => u.CourseId == id);
            if (CourseFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(CourseFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Course? CourseFromDb = unitOfWork.Course.Get(u => u.CourseId == id);
            if (CourseFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            unitOfWork.Course.Remove(CourseFromDb);
            unitOfWork.Save();
            TempData["success"] = "Enrollment Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
