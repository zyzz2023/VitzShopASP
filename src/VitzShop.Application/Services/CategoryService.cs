using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitzShop.Application.Common;
using VitzShop.Application.DTOs;
using VitzShop.Application.Interfaces;
using VitzShop.Application.Mappers;
using VitzShop.Domain.Repository;
using VitzShop.Domain.Entities;
using VitzShop.Domain.ValueObjects;
using VitzShop.Domain.Exceptions;
using VitzShop.Domain.Exceptions.InvalidExceptions;

namespace VitzShop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CategoryDto>> GetCategoryByIdAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                return Result<CategoryDto>.Failure($"Could not find category {id}");

            return Result<CategoryDto>.Success(CategoryMapper.MapToDto(category));
        }
        public async Task<Result<IEnumerable<CategoryDto>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllAsync(cancellationToken);
            if (result is null)
                return Result<IEnumerable<CategoryDto>>.Failure("Can't find some categories.");

            var resultDto = result.Select(x => CategoryMapper.MapToDto(x));
            return Result<IEnumerable<CategoryDto>>.Success(resultDto);

        }
        public async Task<Result<IEnumerable<CategoryDto>>> GetAllByGenderAsync(string gender, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllByGenderAsync(gender, cancellationToken);
            if (result is null)
                return Result<IEnumerable<CategoryDto>>.Failure("Can't find some categories.");

            var resultDto = result.Select(x => CategoryMapper.MapToDto(x));
            return Result<IEnumerable<CategoryDto>>.Success(resultDto);

        }
        public async Task<Result<CategoryDto>> CreateCategoryAsync(string categoryName, string imageUrl, string categoryGender)
        {
            if (await _categoryRepository.ExistsByNameAsync(categoryName))
                return Result<CategoryDto>.Failure($"Category already exists by name {categoryName}.");

            try
            {
                var name = Name.Create(categoryName);
                var url = Url.Create(imageUrl);
                var gender = Gender.Create(categoryGender);

                var result = Category.Create(name, url, gender);

                await _categoryRepository.AddAsync(result);
                await _unitOfWork.CommitAsync();

                return Result<CategoryDto>.Success(CategoryMapper.MapToDto(result));
            }
            catch (InvalidNameException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid category Name {ex.Message}");
            }
            catch (InvalidUrlException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid URL address : {ex.Message}");
            }
            catch (InvalidGenderException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid gender : {ex.Message}");
            }
        }
        public async Task<Result> DeleteCategoryAsync(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                return Result.Failure($"Could not find category {id}");

            if (await _productRepository.IsExistByCategoryIdAsync(id))
                return Result.Failure($"cannot delete a category that contains products");

            await _categoryRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
        public async Task<Result<CategoryDto>> UpdateCategoryAsync(Guid id, string categoryName, string imageUrl)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                return Result<CategoryDto>.Failure($"Could not find category {id} - {categoryName}");

            try
            {
                var name = Name.Create(categoryName);
                var url = Url.Create(imageUrl);

                category.ChangeCategoryName(name);
                category.ChangeImageUrl(url);

                await _unitOfWork.CommitAsync();

                return Result<CategoryDto>.Success(CategoryMapper.MapToDto(category));
            }
            catch (InvalidNameException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid category Name {ex.Message}");
            }
            catch (InvalidUrlException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid URL address : {ex.Message}");
            }
        }
        public async Task<Result<CategoryDto>> ChangeCategoryNameAsync(Guid id, string categoryName)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                return Result<CategoryDto>.Failure($"Could not find category {id} - {categoryName}");

            try
            {
                var name = Name.Create(categoryName);

                category.ChangeCategoryName(name);

                await _unitOfWork.CommitAsync();

                return Result<CategoryDto>.Success(CategoryMapper.MapToDto(category));
            }
            catch (InvalidNameException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid category Name {ex.Message}");
            }
        }
        public async Task<Result<CategoryDto>> ChangeCategoryImageUrlAsync(Guid id, string imageUrl)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
                return Result<CategoryDto>.Failure($"Could not find category {id}");

            try
            {
                var url = Url.Create(imageUrl);

                category.ChangeImageUrl(url);

                await _unitOfWork.CommitAsync();

                return Result<CategoryDto>.Success(CategoryMapper.MapToDto(category));
            }
            catch (InvalidUrlException ex)
            {
                await _unitOfWork.RollbackAsync();
                return Result<CategoryDto>.Failure($"Invalid URL address : {ex.Message}");
            }
        }
    }
}
