using OnlineShop.Db.Model;

namespace OnlineShop.Db
{
    public class ProductDbRepos : IProductRepos
    {
        private readonly DatabaseContext databaseContext;

        public ProductDbRepos(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product>? GetAll()
        {
            return this.databaseContext.Products.ToList();
        }

        public Product? TryByGuid(Guid guid)
        {
            return this.databaseContext.Products.FirstOrDefault(x => x.Id == guid);
        }

        public void Add(Product product)
        {
            product.ImagePath = "/images/" + product.ImagePath;
            this.databaseContext.Products.Add(product);
            this.databaseContext.SaveChanges(); // сохраняем изменения
        }

        public void Update(Product product)
        {
            var exstingProduct = this.databaseContext.Products.FirstOrDefault(x => x.Id == product.Id);

            if (exstingProduct == null)
            {
                return;
            }

            exstingProduct.Name = product.Name;
            exstingProduct.Cost = product.Cost;
            exstingProduct.Description = product.Description;
            exstingProduct.ImagePath = product.ImagePath;

            this.databaseContext.SaveChanges(); // сохраняем изменения
        }

        public void Remove(Product product)
        {
            this.databaseContext.Products.Remove(product);
            this.databaseContext.SaveChanges(); // сохраняем изменения
        }
    }
}
