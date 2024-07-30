using IdentityLecture2.Models;
using IdentityLecture2.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace IdentityLecture2.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel Model)
        {

            if (ModelState.IsValid)
            {

                var newUser = new IdentityUser
                {
                    UserName = Model.UserName,
                    Email = Model.Email
                };
                var result = await _userManager.CreateAsync(newUser, Model.Password);
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(newUser, "User");
                }
            }

            return View();
        }
    }
}
