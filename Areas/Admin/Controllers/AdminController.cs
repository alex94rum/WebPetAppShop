using Microsoft.AspNetCore.Mvc;
using System;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductRepos productRepos;
        private readonly IOrderRepos orderRepos;
        private readonly IRolesRepos rolesRepos;

        public AdminController(IProductRepos productRepos, IOrderRepos orderRepos, IRolesRepos rolesRepos)
        {
            this.productRepos = productRepos;
            this.orderRepos = orderRepos;
            this.rolesRepos = rolesRepos;
        }

        public IActionResult Orders()
        {
            var orders = orderRepos.GetAll();
            return View(orders);
        }

        public IActionResult OrderDetails(Guid orderId, int number)
        {
            var order = orderRepos.TryGetById(orderId);
            if (order != null)
            {
                order.Number = number;
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            orderRepos.UpdateStatus(orderId, status);

            return RedirectToAction("Orders");
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = rolesRepos.GetAll();
            return View(roles);
        }

        public IActionResult RemoveRole(string name)
        {
            rolesRepos.Remove(name);

            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepos.TryByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }

            if (ModelState.IsValid)
            {
                rolesRepos.Add(role);
                return RedirectToAction("Roles");
            }

            return View(role);
        }


        public IActionResult Products()
        {
            var products = productRepos.GetAll();

            return View(products);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid) 
            {
                return View(product);
            }

            productRepos.Add(product);

            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(Guid productId)
        {
            var product = productRepos.TryByGuid(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            productRepos.Update(product);

            return RedirectToAction("Products");
        }
    }
}
