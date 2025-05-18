using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class OrderInMamoryRepos : IOrderRepos
    {
        private List<Cart> orders = new List<Cart>();

        public void Add(Cart cart)
        {
            this.orders.Add(cart);
        }
    }
}
