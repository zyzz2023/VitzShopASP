using Microsoft.EntityFrameworkCore;
using VitzShop.Core.Entities;
using VitzShop.Infrastructure.Data;

namespace VitzShop.Infrastructure.Services
{
    public class CategoriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductService _productService;
        public CategoriesService(ApplicationDbContext context, ProductService productService)
        {
            _context = context;
            _productService = productService;
        }
        // Добавить категорию
        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        // Возвращает категорию по айди
        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        // Возвращает все категории
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        // Удаляет категории + все изображения товаров
        public async Task DeleteCategoryAsync(Category category)
        {
            List<Product> products = await _productService.GetProductsByCategoryIdAsync(category.Id);

            foreach (var product in products)
            {
                await _productService.DeleteProductAsync(product.Id);
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
        // Обновляет категорию
        public async Task UpdateCategoryAsync(Category category)
        {
            if (category != null)
            {
                _context.Categories.Update(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
