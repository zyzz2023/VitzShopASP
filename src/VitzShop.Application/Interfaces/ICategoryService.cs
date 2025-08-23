using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Application.Common;
using VitzShop.Application.DTOs;

namespace VitzShop.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryDto>>> GetAll(CancellationToken cancellationToken);
        Task<Result<CategoryDto>> CreateCategoryAsync(string name, string imageUrl, CancellationToken cancellationToken);
        Task<Result> DeleteCategoryAsync(Guid id, CancellationToken cancellationToken);
        Task<Result<CategoryDto>> ChangeCategoryNameAsync(Guid id, string name, CancellationToken cancellationToken);
        Task<Result<CategoryDto>> ChangeCategoryImageUrlAsync(Guid id, string imageUrl, CancellationToken cancellationToken);
        Task<Result<CategoryDto>> UpdateCategoryAsync(Guid id, string name, string imageUrl, CancellationToken cancellationToken);
        Task<Result<CategoryDto>> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
