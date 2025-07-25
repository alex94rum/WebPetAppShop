﻿using System;

namespace WebPetAppShop.Models
{
    public class CartItemViewModel
    {
        public Guid Id { get; set; }

        public ProductViewModel? Product { get; set; }

        public int Amount { get; set; }

        public decimal Cost
        {
            get
            {
                return this.Product?.Cost * Amount ?? 0;
            }
        }
    }
}
