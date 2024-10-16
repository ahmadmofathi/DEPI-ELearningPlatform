using E_LearningPlatform.DataAccess.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_LearningPlatform.Controllers
{
    public class MangeRolesController : Controller
    {
        public readonly RoleManager<IdentityRole> roleManager;
        public MangeRolesController(RoleManager<IdentityRole> Rm)
        {
            roleManager = Rm;
        }
        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM roleVm)
        {
            IdentityRole role1 = new IdentityRole();
            role1.Name = roleVm.Name;
            var result = await roleManager.CreateAsync(role1);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error Creating Role");
            return View(roleVm);
        }
    }
}
