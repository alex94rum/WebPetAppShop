using Microsoft.AspNetCore.Mvc;
using OnlineShop.Db;
using OnlineShop.Db.Model;
using WebPetAppShop.Data;
using WebPetAppShop.Helpers;
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
        public IActionResult Buy(UserDeliveryInfoViewModel userInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), userInfo);
            }

            var existCart = this.cartRepos.TyGetByUserId(Constans.UserId);

            var order = new Order
            {
                UserInfo = Mapping.ToUser(userInfo),
                Items = existCart.Items,
            };

            if (existCart != null)
            {
                this.orderRepos.Add(order);
            }

            this.cartRepos.Clear(Constans.UserId);

            return View(nameof(Buy));
        }
    }
}
