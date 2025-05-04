using VitzShop.Data;
using VitzShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace VitzShop.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Получить все продукты
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        // Получить продукт по Id
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        // (Опционально) Добавить новый продукт
        public async Task AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        // (Опционально) Удалить продукт
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
        // Категории
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }
        public async Task<List<Product>> GetProductsByCategoryAndGenderAsync(int categoryId, string gender)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId && p.Gender.ToLower() == gender)
                .ToListAsync();
        }
        public async Task<List<Product>> SearchProductsAsync(string search)
        {
            return await _context.Products
                .Where(p => p.Name.Contains(search) || p.Description.Contains(search))
                .ToListAsync();
        }

    }
}
