using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.DataAccess;
using System.Collections.Generic;
using System.Linq;
using E_LearningPlatform.DataAccess.Repository;
using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;

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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Request.Add(request);
                unitOfWork.Save();
                TempData["success"] = "Request Sent Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error occurred while sending the request.";
            return View(request);
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
            return View(requestFromDb);
        }

        // POST: Request/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Request.Update(request);
                unitOfWork.Save();
                TempData["success"] = "Request Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Error occurred while updating the request.";
            return View(request);
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
