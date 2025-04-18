using System;

namespace WebPetAppShop.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public Product? Product { get; set; }

        public decimal Amount { get; set; }

        public decimal Cost
        {
            get
            {
                return this.Product?.Cost * Amount ?? 0;
            }
        }
    }
}
