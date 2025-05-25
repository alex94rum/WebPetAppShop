using System;
using System.Collections.Generic;

namespace WebPetAppShop.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public UserDeliveryInfo? UserInfo { get; set; }

        public List<CartItem>? Items { get; set; }

        public Order()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
