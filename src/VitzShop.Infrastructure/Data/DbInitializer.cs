using Microsoft.EntityFrameworkCore;
using System.Linq;
using VitzShop.Core.Entities;
using VitzShop.Domain.Entities;

namespace VitzShop.Infrastructure.Data
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
                new Category { Name = "Футболки", ImageUrl = "Images/categoryTShirts.png" },
                new Category { Name = "Штаны", ImageUrl = "Images/categoryTrousers.png" },
                new Category { Name = "Шорты" , ImageUrl = "Images/categoryShirtTrousers.png"},
                new Category { Name = "Головные уборы", ImageUrl = "Images/categoryHead.png"}
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
                    Images = new List<Image>
                    {
                        new Image { Url = "Images/trousers1.jpg" },
                        new Image { Url = "Images/trousers2.jpg" },
                        new Image { Url = "Images/trousers3.jpg" }
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
                    Images = new List<Image>
                    {
                        new Image { Url = "Images/icon.jpg" },
                        new Image { Url = "Images/icon.jpg" }
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
                    Images = new List<Image>
                    {
                        new Image { Url = "Images/icon.jpg" },
                        new Image { Url = "Images/icon.jpg" }
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
                    Images = new List<Image>
                    {
                        new Image { Url = "Images/icon.jpg" },
                        new Image { Url = "Images/icon.jpg" }
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
                    Images = new List<Image>
                    {
                        new Image { Url = "Images/icon.jpg" },
                        new Image { Url = "Images/icon.jpg" }
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
                    Images = new List<Image>
                    {
                        new Image { Url = "Images/icon.jpg" },
                        new Image { Url = "Images/icon.jpg" }
                    }
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
