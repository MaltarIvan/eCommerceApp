using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using eTickets.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Users()
        {
            var users = await _appDbContext.Users.ToListAsync();

            List<UserVM> userVMs = new List<UserVM>();

            foreach(ApplicationUser applicationUser in users)
            {
                UserVM userVM = new UserVM()
                {
                    Id = new Guid(applicationUser.Id),
                    FullName = applicationUser.FullName,
                    Email = applicationUser.Email
                };

                userVMs.Add(userVM);
            }

            return View(userVMs);
        }

        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user != null)
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (isPasswordValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
            }

            TempData["Error"] = "Wrong credidentials";

            return View(loginVM);
        }

        public IActionResult Register()
        {
            var response = new RegisterVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.Email);

            if (user != null)
            {
                TempData["Error"] = "There already is a user with the same email address";

                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                Email = registerVM.Email,
                FullName = registerVM.FullName,
                UserName = registerVM.Email
            };

            var result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

                return View("RegisterCompleted");
            }

            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
