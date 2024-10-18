using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.DataAccess;
using System.Collections.Generic;
using System.Linq;
using E_LearningPlatform.DataAccess.Repository;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
using E_LearningPlatform.DataAccess.ViewModels; // For RequestVM
using Microsoft.AspNetCore.Mvc.Rendering; // Required for SelectListItem

namespace E_LearningPlatformWeb.Areas.Admin.Controllers
{
    public class RequestController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public RequestController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Request
        public IActionResult Index()
        {
            List<Request> requests = unitOfWork.Request.GetAll().ToList();
            return View(requests);
        }

        // GET: Request/Create
        public IActionResult Create(int courseId)
        {
            var course = unitOfWork.Course.Get(courseId);
            if (course == null)
            {
                TempData["Error"] = "Course not found.";
                return RedirectToAction("Index", "Course");
            }

            var requestVM = new RequestVM
            {
                Request = new Request
                {
                    CourseId = course.CourseId,
                    Description = $"Request for {course.CourseName}" // Pre-fill description
                },
                CourseList = (IEnumerable<System.Web.Mvc.SelectListItem>)unitOfWork.Course.GetAll().Select(c => new SelectListItem
                {
                    Value = c.CourseId.ToString(),
                    Text = c.CourseName
                }).ToList() 
            };

            return View(requestVM);
        }

        // POST: Request/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RequestVM requestVM)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Request.Add(requestVM.Request);
                unitOfWork.Save();
                TempData["success"] = "Request Sent Successfully";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Error occurred while sending the request.";
            requestVM.CourseList = (IEnumerable<System.Web.Mvc.SelectListItem>)unitOfWork.Course.GetAll().Select(c => new SelectListItem
            {
                Value = c.CourseId.ToString(),
                Text = c.CourseName
            }).ToList(); // Using the correct SelectListItem
            return View(requestVM);
        }

        // GET: Request/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Invalid Request ID.";
                return RedirectToAction("Index");
            }

            Request requestFromDb = unitOfWork.Request.Get(u => u.RequestId == id);
            if (requestFromDb == null)
            {
                TempData["Error"] = "Request Not Found.";
                return RedirectToAction("Index");
            }

            var courseList = unitOfWork.Course.GetAll().Select(c => new SelectListItem
            {
                Value = c.CourseId.ToString(),
                Text = c.CourseName
            }).ToList();

            var requestVM = new RequestVM
            {
                Request = requestFromDb,
                CourseList = (IEnumerable<System.Web.Mvc.SelectListItem>)courseList // Using the correct SelectListItem
            };

            return View(requestVM);
        }

        // POST: Request/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RequestVM requestVM)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Request.Update(requestVM.Request);
                unitOfWork.Save();
                TempData["success"] = "Request Updated Successfully";
                return RedirectToAction("Index");
            }

            TempData["Error"] = "Error occurred while updating the request.";
            // Re-fetch course list in case of an error
            requestVM.CourseList = (IEnumerable<System.Web.Mvc.SelectListItem>)unitOfWork.Course.GetAll().Select(c => new SelectListItem
            {
                Value = c.CourseId.ToString(),
                Text = c.CourseName
            }).ToList(); // Using the correct SelectListItem
            return View(requestVM);
        }

        // GET: Request/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                TempData["Error"] = "Invalid Request ID.";
                return RedirectToAction("Index");
            }

            Request requestFromDb = unitOfWork.Request.Get(u => u.RequestId == id);
            if (requestFromDb == null)
            {
                TempData["Error"] = "Request Not Found.";
                return RedirectToAction("Index");
            }

            return View(requestFromDb);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            Request requestFromDb = unitOfWork.Request.Get(u => u.RequestId == id);
            if (requestFromDb == null)
            {
                TempData["Error"] = "Request Not Found.";
                return RedirectToAction("Index");
            }

            unitOfWork.Request.Remove(requestFromDb);
            unitOfWork.Save();
            TempData["success"] = "Request Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
