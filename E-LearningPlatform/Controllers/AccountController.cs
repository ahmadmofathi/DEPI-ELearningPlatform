using E_LearningPlatform.DataAccess.ViewModels;
using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace E_LearningPlatform.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Account> _userManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<Account> USM, SignInManager<Account> SIM, RoleManager<IdentityRole> RM)
        {
            _userManager = USM;
            _signInManager = SIM;
            _roleManager = RM;
        }

   

        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterVM NewUser)
        {
            Account user1 = new Account() { UserName = NewUser.Name, Email = NewUser.Email,FirstName=NewUser.fristName,LastName=NewUser.lastName };
            IdentityResult result = await _userManager.CreateAsync(user1, NewUser.Password);
            IdentityRole role1 = new IdentityRole() { Name = "defualt User" };
            await _roleManager.CreateAsync(role1);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user: user1, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Failed to Register");
            return View("Register", NewUser);


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM LogUser)
        {
            var result = await _signInManager.PasswordSignInAsync(LogUser.Name, LogUser.Password, LogUser.RememberMe, false);
            if (result.Succeeded)
            {

                return RedirectToAction("Index", "Home");


            }

            ModelState.TryAddModelError("", "Login Failed");
            return View("Index", "Home");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Assign(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ViewData["Role"] = new SelectList(_roleManager.Roles, "Id", "Name");
            UserRoleVM Ur = new UserRoleVM()
            {
                UserId = user.Id,
                UserName = user.UserName
            };
            return View(Ur);
        }
        [HttpPost]
        public async Task<IActionResult> Assign(UserRoleVM UR)
        {
            var user = await _userManager.FindByIdAsync(UR.UserId);
            var role1 = await _roleManager.FindByIdAsync(UR.RoleId);
            var resualt = await _userManager.AddToRoleAsync(user, role1.Name);
            if (resualt.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ViewData["Role"] = new SelectList(_roleManager.Roles, "Id", "Name");
            return View(UR);
        }


        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
    }
}
