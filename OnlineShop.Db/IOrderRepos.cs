using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public interface IOrderRepos
    {
        void Add(Order order);

        List<Order> GetAll();

        Order TryGetById(Guid orderId);

        void UpdateStatus(Guid orderId, OrderStatus status);
    }
}