using System;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface IOrderRepos
    {
        void Add(Order order);

        List<Order> GetAll();

        Order? TryGetById(Guid orderId);

        void UpdateStatus(Guid orderId, OrderStatus status);
    }
}