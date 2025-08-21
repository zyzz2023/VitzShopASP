using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Entities;
using VitzShop.Domain.Interfaces;

namespace VitzShop.Domain.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<Product> GetByNameAsync(Guid id);
        public Task<IEnumerable<Product>> GetAllProductsByCategoryIdAsync(Guid categoryId);
    }
}
