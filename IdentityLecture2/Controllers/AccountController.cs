using Microsoft.AspNetCore.Mvc;

namespace IdentityLecture2.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
