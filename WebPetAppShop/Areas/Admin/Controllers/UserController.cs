using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area(Constants.AdminRoleName)]
    [Authorize(Roles = Constants.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            var userAccounts = this.usersManager.GetAll();
            return View(userAccounts);
        }

        public IActionResult Detail(string name)
        {
            var userAccount = this.usersManager.TryGetByName(name);
            return View(userAccount);
        }

        public IActionResult ChangePassword(string name)
        {
            var changePassword = new ChangePassword()
            {
                UserName = name,
            };

            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать");
                return View();
            }

            if (ModelState.IsValid)
            {
                this.usersManager.ChangePassword(changePassword.UserName, changePassword.Password);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(ChangePassword));
        }
    }
}
