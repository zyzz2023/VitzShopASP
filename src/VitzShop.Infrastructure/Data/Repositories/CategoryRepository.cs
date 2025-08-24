using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitzShop.Infrastructure.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Category>> GetAllByGenderAsync(string gender, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Where(c => c.Gender.Value == gender)
                .ToListAsync(cancellationToken);
        }
        public async Task<Category> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Name.Value == name);
        }
        public async Task<bool> CategoryExistsAsync(string name)
        {
            return await _context.Categories
                .AnyAsync(c => c.Name.Value == name);
        }
        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await _context.Categories.AnyAsync(c => c.Name.Value == name);
        }
    }
}
