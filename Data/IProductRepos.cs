using System;
using System.Collections.Generic;
using WebPetAppShop.Models;

namespace WebPetAppShop.Data
{
    public interface IProductRepos
    {
        // получения продукта по Guid
        Product? TryByGuid(Guid guid);

        // получение всех продуктоа
        public List<Product>? GetAll();

        // добавление продукта
        void Add(Product product);

        // обновление продукта
        void Update(Product product);
    }
}