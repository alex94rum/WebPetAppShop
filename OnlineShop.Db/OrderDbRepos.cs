using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db
{
    public class OrderDbRepos : IOrderRepos
    {
        private readonly DatabaseContext databaseContext;

        public OrderDbRepos(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Order order)
        {
            this.databaseContext.Orders.Add(order);
            this.databaseContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return this.databaseContext.Orders
                            .Include(x => x.UserInfo)
                            .Include(x => x.Items)
                            .ThenInclude(x => x.Product)
                            .ToList();
        }

        public Order? TryGetById(Guid orderId)
        {
            return this.databaseContext.Orders.Include(x => x.UserInfo)
                 .Include(x => x.Items)
                 .ThenInclude(x => x.Product)
                 .FirstOrDefault(x => x.Id == orderId);
        }

        public void UpdateStatus(Guid orderId, OrderStatus status)
        {
            var order = this.TryGetById(orderId);
            if (order != null)
            {
                order.Status = status;
                this.databaseContext.SaveChanges();
            }
        }
    }
}
