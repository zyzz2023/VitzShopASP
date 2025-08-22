using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Repository;
using VitzShop.Domain.ValueObjects;

namespace VitzShop.Infrastructure.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Name.Value == name, cancellationToken);
        }
        public async Task<Product> GetBySkuAsync(string sku, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.Variants)
                .FirstOrDefaultAsync(p => p.Variants.Any(p => p.Sku == sku), cancellationToken);
        }
        public async Task<IEnumerable<Product>> GetAllProductsByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken)
        {
                return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.MainImage)
                .Include(p => p.Variants)
                .ToListAsync(cancellationToken);
        }
        //public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId)
        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => p.Name.Value.Contains(searchTerm) ||
                p.Description.Value.Contains(searchTerm))
                .Include(p => p.MainImage)
                .ToListAsync(cancellationToken);
        }
        public async Task<Product> GetProductWithVariantsAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(p => p.Variants)
                .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
        }
        public async Task<Product> GetProductWithDetailsAsync(Guid productId, CancellationToken cancellationToken)
        {
            return await _context.Products
            .Include(p => p.MainImage)
            .Include(p => p.Variants)
            .ThenInclude(v => v.Images)
            .FirstOrDefaultAsync(p => p.Id == productId, cancellationToken);
        }
    }
}
