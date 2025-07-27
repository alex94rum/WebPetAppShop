using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Db.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public UserDeliveryInfo UserInfo { get; set; }

        public List<CartItem> Items { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedDataTime { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            CreatedDataTime = DateTime.Now;
        }
    }
}
