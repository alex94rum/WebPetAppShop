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

        public List<Order> GetAll()
        {
            return this.orders;
        }

        public Order? TryGetById(Guid orderId)
        {
            return this.orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = this.TryGetById(orderId);

            if (order != null)
            {
                order.Status = status;
            }
        }
    } 
}
