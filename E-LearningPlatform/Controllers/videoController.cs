﻿using E_LearningPlatform.DataAccess.Repository.IRepository;
using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
<<<<<<< HEAD
=======
using E_LearningPlatform.DataAccess.Repository.IRepository;
>>>>>>> fde47c85bdd86ad23fbfbe25812cdddda84131dc

namespace E_LearningPlatform.Controllers
{
    public class videoController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public videoController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Video> videos = unitOfWork.Video.GetAll().ToList();
            return View(videos);
        }

        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(unitOfWork.Course.GetAll().ToList(), "CourseId", "CourseName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Video video)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Video.Add(video);
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
            Video? VideoFromDb = unitOfWork.Video.Get(u => u.VideoId== id);
            ViewData["CourseId"] = new SelectList(unitOfWork.Course.GetAll().ToList(), "CourseId", "CourseName");

            if (VideoFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(VideoFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Video video)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Video.Update(video);
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
            Video? VideoFromDb = unitOfWork.Video.Get(u => u.VideoId == id);
            if (VideoFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            return View(VideoFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Video? VideoFromDb = unitOfWork.Video.Get(u => u.VideoId == id);
            if (VideoFromDb == null)
            {
                TempData["Error"] = "Error!";
                return RedirectToAction("Index");
            }
            unitOfWork.Video.Remove(VideoFromDb);
            unitOfWork.Save();
            TempData["success"] = "Enrollment Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
