//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using VitzShop.Domain.Entities;
//using VitzShop.Domain.Interfaces;

//namespace VitzShop.Domain.Repository
//{
//    public interface IProductImageRepository : IRepository<Image>
//    {
//        public Task<Image> GetByUrlAsync(string url);
//        public Task<IEnumerable<Image>> GetAllByProductVariantIdAsync(Guid productVariantId);
//        public Task<Image> GetByProductIdAsync(Guid productId);
//        public Task<Image> GetByCategoryIdAsync(Guid categoryId);
//    }
//}
