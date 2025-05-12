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
                new Category { Name = "Шорты" },
                new Category { Name = "Головные уборы" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges(); // сохраняем изменения, чтобы получить актуальные CategoryId

            var products = new List<Product>
            {

                new Product
                {
                    Name = "Trousers VITZ",
                    Description = "Мужские штаны, Черные штаны",
                    Price = 3600,
                    Gender = "Мужской",
                    ImageUrl = "Images/trousers1.jpg",
                    SizeM = 3,
                    SizeL = 2,
                    SizeXl = 1,
                    CategoryId = categories.First(c => c.Name == "Штаны").Id,
                    Images = new List<ProductImage>
                    {
                        new ProductImage { Url = "Images/trousers1.jpg" },
                        new ProductImage { Url = "Images/trousers2.jpg" },
                        new ProductImage { Url = "Images/trousers3.jpg" }
                    }
                },
                new Product
                {
                    Name = "Белая футболка",
                    Description = "Классическая белая футболка",
                    Price = 1200,
                    Gender = "Женский",
                    ImageUrl = "Images/icon.jpg",
                    SizeM = 3,
                    SizeL = 2,
                    SizeXl = 1,
                    CategoryId = categories.First(c => c.Name == "Футболки").Id, // привязываем к категории
                    Images = new List<ProductImage>
                    {
                        new ProductImage { Url = "Images/icon.jpg" },
                        new ProductImage { Url = "Images/icon.jpg" }
                    }
                },
                new Product
                {
                    Name = "Черные штаны",
                    Description = "Удобные повседневные штаны",
                    Price = 2500,
                    Gender = "Мужской",
                    ImageUrl = "Images/icon.jpg",
                    SizeM = 3,
                    SizeL = 2,
                    SizeXl = 1,
                    CategoryId = categories.First(c => c.Name == "Штаны").Id,
                    Images = new List<ProductImage>
                    {
                        new ProductImage { Url = "Images/icon.jpg" },
                        new ProductImage { Url = "Images/icon.jpg" }
                    }
                },
                new Product
                {
                    Name = "Белая кепка",
                    Description = "Отличная защита от солнца",
                    Price = 2500,
                    Gender = "Мужской",
                    ImageUrl = "Images/icon.jpg",
                    SizeM = 3,
                    SizeL = 2,
                    SizeXl = 1,
                    CategoryId = categories.First(c => c.Name == "Головные уборы").Id,
                    Images = new List<ProductImage>
                    {
                        new ProductImage { Url = "Images/icon.jpg" },
                        new ProductImage { Url = "Images/icon.jpg" }
                    }
                },
                new Product
                {
                    Name = "Черная Кепка",
                    Description = "Стильная кепка",
                    Price = 2500,
                    Gender = "Женский",
                    ImageUrl = "Images/icon.jpg",
                    SizeM = 3,
                    SizeL = 2,
                    SizeXl = 1,
                    CategoryId = categories.First(c => c.Name == "Головные уборы").Id,
                    Images = new List<ProductImage>
                    {
                        new ProductImage { Url = "Images/icon.jpg" },
                        new ProductImage { Url = "Images/icon.jpg" }
                    }
                },
                new Product
                {
                    Name = "Черная футболка",
                    Description = "Стильная кепка",
                    Price = 2500,
                    Gender = "Мужской",
                    ImageUrl = "Images/icon.jpg",
                    SizeM = 3,
                    SizeL = 2,
                    SizeXl = 1,
                    CategoryId = categories.First(c => c.Name == "Головные уборы").Id,
                    Images = new List<ProductImage>
                    {
                        new ProductImage { Url = "Images/icon.jpg" },
                        new ProductImage { Url = "Images/icon.jpg" }
                    }
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
