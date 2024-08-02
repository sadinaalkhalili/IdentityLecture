using IdentityLecture2.Models;
using IdentityLecture2.Models.ViewModel;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace IdentityLecture2.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<Identity> _signInManager;
        private readonly UserManager<Identity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(SignInManager<Identity> signInManager, UserManager<Identity> userManager,RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View("Register");
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel Model)
        {

            if (ModelState.IsValid)
            {

                var newUser = new Identity
                {
                    UserName = Model.UserName,
                    Email = Model.Email,
                    firstName = Model.firstName, lastName = Model.lastName,
                };
                var result = await _userManager.CreateAsync(newUser, Model.Password);
       
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel Model)
        
        
        
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(Model.UserName);
                if(user is not null)
                {
                    if( await _signInManager.CanSignInAsync(user))
                    {
                       var result= await _signInManager.PasswordSignInAsync(user, Model.Password,true,false);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                
                

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> EditUser()
        {
            var lstRoles = _roleManager.Roles.ToList();
            var lstUsers = _userManager.Users.ToList();
          
            return View((lstRoles,lstUsers)) ;
        }

    }
}
