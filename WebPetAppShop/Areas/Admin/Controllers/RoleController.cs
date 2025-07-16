using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Areas.Admin.Model;
using WebPetAppShop.Data;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepos rolesRepos;

        public RoleController(IRolesRepos rolesRepos)
        {
            this.rolesRepos = rolesRepos;
        }

        public IActionResult Index()
        {
            var roles = rolesRepos.GetAll();
            return View(roles);
        }

        public IActionResult Remove(string name)
        {
            rolesRepos.Remove(name);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesRepos.TryByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }

            if (ModelState.IsValid)
            {
                rolesRepos.Add(role);
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }
    }
}
