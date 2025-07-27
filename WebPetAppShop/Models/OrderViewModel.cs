using System;
using System.Collections.Generic;
using System.Linq;

namespace WebPetAppShop.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public UserDeliveryInfoViewModel? UserInfo { get; set; }

        public List<CartItemViewModel>? Items { get; set; }

        public OrderStatusViewModel Status { get; set; }

        public DateTime CreatedDataTime { get; set; }

        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            Status = OrderStatusViewModel.Created;
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
