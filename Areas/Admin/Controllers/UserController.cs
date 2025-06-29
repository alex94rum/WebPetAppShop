using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Data;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IProductRepos productRepos;
        private readonly IOrderRepos orderRepos;
        private readonly IRolesRepos rolesRepos;

        public UserController(IProductRepos productRepos, IOrderRepos orderRepos, IRolesRepos rolesRepos)
        {
            this.productRepos = productRepos;
            this.orderRepos = orderRepos;
            this.rolesRepos = rolesRepos;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
