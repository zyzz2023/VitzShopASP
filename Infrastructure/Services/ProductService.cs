using Microsoft.EntityFrameworkCore;
using VitzShop.Core.Entities;
using VitzShop.Infrastructure.Data;

namespace VitzShop.Infrastructure.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        // (Опционально) Добавить новый продукт
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
        // Удалить продукт
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                var mainPhoto = "wwwroot/" + product.ImageUrl;
                if (File.Exists(mainPhoto))
                {
                    File.Delete(mainPhoto);
                    Console.WriteLine("Файл удален");
                }
                else
                {
                    Console.WriteLine($"Файл по пути {mainPhoto} не найден");
                }

                foreach (var image in product.Images)
                {
                    var filePath = "wwwroot/" + image.Url;


                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        Console.WriteLine("Файл удален");
                    }
                    else
                    {
                        Console.WriteLine($"Файл по пути {filePath} не найден");
                    }
                }

                _context.ProductImages.RemoveRange(product.Images);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        // Возвращает все продукты
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        // Получить продукт по Id
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        // Обновляет продукт
        public async Task UpdateProductAsync(Product product)
        {
            if (product != null)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
        }
        // Возвращает продукты по категории
        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
        // Возвращает продукты по категории и гендеру
        public async Task<List<Product>> GetProductsByCategoryAndGenderAsync(int categoryId, string gender)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId && p.Gender.ToLower() == gender.ToLower())
                .ToListAsync();
        }
        // Поиск продуктов
        public async Task<List<Product>> SearchProductsAsync(string search)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(search) || p.Description.Contains(search))
                .ToListAsync();
        }
    }
}
