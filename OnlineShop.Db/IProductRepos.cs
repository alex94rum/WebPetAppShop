using OnlineShop.Db.Model;

namespace OnlineShop.Db
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

        // удаление продукта
        void Remove(Product product);
    }
}