using System;
using System.Collections.Generic;
using System.Linq;

namespace WebPetAppShop.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public UserDeliveryInfo? UserInfo { get; set; }

        public List<CartItem>? Items { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedDataTime { get; set; }

        public int Number { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Status = OrderStatus.Created;
            CreatedDataTime = DateTime.Now;
        }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
