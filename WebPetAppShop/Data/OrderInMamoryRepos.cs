using OnlineShop.Db;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public class OrderInMamoryRepos : IOrderRepos
    {
        private List<OrderViewModel> orders = new List<OrderViewModel>();

        public void Add(OrderViewModel order)
        {
            this.orders.Add(order);
        }

        public void Add(Order order)
        {
            
        }

        public List<OrderViewModel> GetAll()
        {
            return this.orders;
        }

        public OrderViewModel? TryGetById(Guid orderId)
        {
            return this.orders.FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatusViewModel status)
        {
            var order = this.TryGetById(orderId);

            if (order != null)
            {
                order.Status = status;
            }
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            throw new NotImplementedException();
        }

        List<Order> IOrderRepos.GetAll()
        {
            throw new NotImplementedException();
        }

        Order IOrderRepos.TryGetById(Guid orderId)
        {
            throw new NotImplementedException();
        }
    } 
}
