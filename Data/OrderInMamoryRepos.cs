using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class OrderInMamoryRepos : IOrderRepos
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            this.orders.Add(order);
        }
    }
}
