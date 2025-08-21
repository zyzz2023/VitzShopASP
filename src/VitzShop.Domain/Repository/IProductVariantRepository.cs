using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Entities;
using VitzShop.Domain.Interfaces;

namespace VitzShop.Domain.Repository
{
    public interface IProductVariantRepository : IRepository<ProductVariant>
    {
        public Task<ProductVariant> GetBySkuAsync(string sku);
        public Task<IEnumerable<ProductVariant>> GetAllByProductIdAsync(Guid productId);
    }
}
