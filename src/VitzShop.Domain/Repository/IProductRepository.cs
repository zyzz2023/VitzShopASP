using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Entities;

namespace VitzShop.Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<Product> GetByNameAsync(string name, CancellationToken cancellationToken);
        public Task<Product> GetBySkuAsync(string sku, CancellationToken cancellationToken);
        public Task<IEnumerable<Product>> GetAllProductsByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken);
        public Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, CancellationToken cancellationToken);
        public Task<Product> GetProductWithVariantsAsync(Guid productId, CancellationToken cancellationToken);
        public Task<Product> GetProductWithDetailsAsync(Guid productId, CancellationToken cancellationToken);
    }
}
