using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Entities;

namespace VitzShop.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category> 
    {
        public Task<Category> GetByNameAsync(Guid id);
        public Task<bool> ExistAsync(string name);
    }
}
