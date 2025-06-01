using Microsoft.AspNetCore.Mvc;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

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

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", userInfo);
            }

            var existCart = this.cartRepos.TyGetByUserId(Constans.UserId);

            var order = new Order()
            {
                UserInfo = userInfo,
                Items = existCart?.Items,
            };

            if (existCart != null)
            {
                this.orderRepos.Add(order);
            }

            this.cartRepos.Clear(Constans.UserId);

            return View("Buy");
        }
    }
}
