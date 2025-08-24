using Microsoft.EntityFrameworkCore;
using OnlineShop.Db.Model;
using System;
using System.Collections.Generic;

namespace OnlineShop.Db
{
    public class DatabaseContext : DbContext
    {
        // Доступ к таблицам
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) 
        { 
            Database.Migrate(); // создаем бд при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>()
            {
                new Product()
                {
                    Id = new Guid("6498025C-CEC5-43E5-8740-403FC45E9396"),
                    Name = "Курс по C#",
                    Cost = 100,
                    Description = "Описание курса по C#",
                    ImagePath = "/images/c-sharp.png",
                },

                new Product()
                {
                    Id = new Guid("064F9892-393B-4B1B-85A5-BA611ACD90DF"),
                    Name = "Курс по Java",
                    Cost = 99,
                    Description = "Описание курса по Java",
                    ImagePath = "/images/java.png",
                }
            });
        }
    }
}
