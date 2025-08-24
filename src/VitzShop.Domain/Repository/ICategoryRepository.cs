using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Domain.Entities;

namespace VitzShop.Domain.Repository
{
    public interface ICategoryRepository : IRepository<Category> 
    {
        public Task<IEnumerable<Category>> GetAllByGenderAsync(string gender, CancellationToken cancellationToken);
        public Task<Category> GetByNameAsync(string name);
        public Task<bool> ExistsByNameAsync(string name);
    }
}
