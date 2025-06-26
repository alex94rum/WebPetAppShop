using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using WebPetAppShop.Data;
using WebPetAppShop.Models;

namespace WebPetAppShop.Controllers
{
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
            var orders = this.orderRepos.GetAll();
            return View(orders);
        }

        public IActionResult OrderDetails(Guid orderId, int number)
        {
            var order = this.orderRepos.TryGetById(orderId);
            if (order != null)
            {
                order.Number = number;
            }

            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus status)
        {
            this.orderRepos.UpdateStatus(orderId, status);

            return RedirectToAction("Orders");
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            var roles = this.rolesRepos.GetAll();
            return View(roles);
        }

        public IActionResult RemoveRole(string name)
        {
            this.rolesRepos.Remove(name);

            return RedirectToAction("Roles");
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (this.rolesRepos.TryByName(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже есть");
            }

            if (ModelState.IsValid)
            {
                this.rolesRepos.Add(role);
                return RedirectToAction("Roles");
            }

            return View(role);
        }


        public IActionResult Products()
        {
            var products = this.productRepos.GetAll();

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

            this.productRepos.Add(product);

            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(Guid productId)
        {
            var product = this.productRepos.TryByGuid(productId);

            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            this.productRepos.Update(product);

            return RedirectToAction("Products");
        }
    }
}
