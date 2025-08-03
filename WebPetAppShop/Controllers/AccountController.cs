using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db.Model;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> singInManager;

        public AccountController(IUsersManager usersManager, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.usersManager = usersManager;
            this.userManager = userManager;
            this.singInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View(nameof(Login));
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = this.singInManager.PasswordSignInAsync(login.UserName, login.Password, login.Remember, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный пароль");
                }

                return View();
            }

            return View(login);
        }

        public IActionResult Register()
        {
            return View(nameof(Register));
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
                return View();
            }

            if (ModelState.IsValid)
            {
                this.usersManager.Add(new UserAccount()
                {
                    Name = register.UserName,
                    Phone = register.Phone,
                    Password = register.Password,
                });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return RedirectToAction(nameof(Register));
        }
    }
}
