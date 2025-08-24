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
        Task<Result<IEnumerable<CategoryDto>>> GetAllByGenderAsync(string gender, CancellationToken cancellationToken);
        Task<Result<IEnumerable<CategoryDto>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<CategoryDto>> CreateCategoryAsync(string name, string imageUrl);
        Task<Result> DeleteCategoryAsync(Guid id);
        Task<Result<CategoryDto>> ChangeCategoryNameAsync(Guid id, string name);
        Task<Result<CategoryDto>> ChangeCategoryImageUrlAsync(Guid id, string imageUrl);
        Task<Result<CategoryDto>> UpdateCategoryAsync(Guid id, string name, string imageUrl);
        Task<Result<CategoryDto>> GetCategoryByIdAsync(Guid id);
    }
}
