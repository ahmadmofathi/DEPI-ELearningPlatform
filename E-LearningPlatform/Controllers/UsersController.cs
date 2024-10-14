using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningPlatform.Models;
using E_LearningPlatform.Utility.Service;

namespace E_LearningPlatform.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGenericService<User> _userService;

        public UsersController(IGenericService<User> userService)
        {
            _userService = userService;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            var users = _userService.GetAll(); // Using the generic service to get all users
            return View(users);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            var user = _userService.GetById(id); // Using the generic service to get a specific user
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                _userService.Add(user); // Using the generic service to create a user
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                _userService.Update(id,user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _userService.RemoveById(id); // Using the generic service to delete the user
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
