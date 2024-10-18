using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.DataAccess.ViewModels;
using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (course!=null)
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
            if (course!=null)
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
        public IActionResult GetAllUsersCourses()
        {

            var courses=unitOfWork.Course.GetAll();
            return View(courses);
        }
        public IActionResult GetCourseDeatails(int id )
        {
            var course =unitOfWork.Course.Get(e=>e.CourseId == id);

            if (course !=null)
            {
                return View(course);

            }
            return RedirectToAction("index","Home");
        }

        public IActionResult AssignRequest(int id)
        {
            Request request = new Request();
            request.CourseId = id;
            request.CreationDate = DateTime.Now;
            request.RequestStatus = "pending";
            request.Description = "enrollment Request";
            unitOfWork.Request.Add(request);
            return View("Index","Home");

        }
    }
}
