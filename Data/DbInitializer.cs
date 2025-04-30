using VitzShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VitzShop.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Products.RemoveRange(context.Products);
            context.Categories.RemoveRange(context.Categories);
            context.SaveChanges(); // сохраняем изменения после удаления

            var categories = new List<Category>
            {
                new Category { Name = "Футболки" },
                new Category { Name = "Штаны" },
                new Category { Name = "Куртки" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges(); // сохраняем изменения, чтобы получить актуальные CategoryId

            var products = new List<Product>
            {

                new Product
                {
                    Name = "Зимняя куртка",
                    Description = "Теплая и стильная куртка",
                    Price = 5000,
                    ImageUrl = "Images/icon.jpg",
                    Size = "XL",
                    CategoryId = categories.First(c => c.Name == "Куртки").Id
                },
                new Product
                {
                    Name = "Белая футболка",
                    Description = "Классическая белая футболка",
                    Price = 1200,
                    ImageUrl = "Images/icon.jpg",
                    Size = "M",
                    CategoryId = categories.First(c => c.Name == "Футболки").Id // привязываем к категории
                },
                new Product
                {
                    Name = "Черные штаны",
                    Description = "Удобные повседневные штаны",
                    Price = 2500,
                    ImageUrl = "Images/icon.jpg",
                    Size = "L",
                    CategoryId = categories.First(c => c.Name == "Штаны").Id
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
