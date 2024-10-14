using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.Models;
using E_LearningPlatform.Utility.Service;

namespace E_LearningPlatform.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IGenericService<Instructor> _instructorService;

        public InstructorsController(IGenericService<Instructor> instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: InstructorsController
        public ActionResult Index()
        {
            var instructors = _instructorService.GetAll(); // Using the generic service to get all instructors
            return View(instructors);
        }

        // GET: InstructorsController/Details/5
        public ActionResult Details(int id)
        {
            var instructor = _instructorService.GetById(id); // Using the generic service to get a specific instructor
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // GET: InstructorsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                _instructorService.Add(instructor); // Using the generic service to create an instructor
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorsController/Edit/5
        public ActionResult Edit(int id)
        {
            var instructor = _instructorService.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: InstructorsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instructor instructor)
        {
            try
            {
                _instructorService.Update(id, instructor); // Using the generic service to update the instructor
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorsController/Delete/5
        public ActionResult Delete(int id)
        {
            var instructor = _instructorService.GetById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // POST: InstructorsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _instructorService.RemoveById(id); // Using the generic service to delete the instructor
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
