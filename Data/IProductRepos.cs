using System;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface IProductRepos
    {
        Product? TryByGuid(Guid guid);

        public List<Product>? GetAll();
    }
}