using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
