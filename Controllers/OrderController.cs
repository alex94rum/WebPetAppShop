using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Data;

namespace WebPetAppShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartRepos cartRepos;
        private readonly IOrderRepos orderRepos;

        public OrderController(ICartRepos cartRepos, IOrderRepos orderRepos)
        {
            this.cartRepos = cartRepos;
            this.orderRepos = orderRepos;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Buy()
        {
            var existCart = this.cartRepos.TyGetByUserId(Constans.UserId);

            if (existCart != null)
            {
                this.orderRepos.Add(existCart);
            }

            this.cartRepos.Clear(Constans.UserId);

            return View("Buy");
        }
    }
}
