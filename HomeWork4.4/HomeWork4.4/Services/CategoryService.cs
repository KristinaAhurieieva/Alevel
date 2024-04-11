using System;
using FourModule.Services.Abstractions;
using FourModule.Repositories.Abstractions;
using FourModule.Entities;
using FourModule.Dtos;
using FourModule.Data;
using FourModule.Repositories;

namespace FourModule.Services
{
    public class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;

        public CategoryService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICategoryRepository categoryRepository,
            ILogger<CategoryService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<CategoryDto> CreateCategory(string categoryName)
        {
            var createdCategory = new CategoryEntity { CategoryName = categoryName };
            await _categoryRepository.CreateCategoryAsync(createdCategory);

            return new CategoryDto
            {
                Id = createdCategory.Id,
                CategoryName = createdCategory.CategoryName
            };
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryEntity == null)
                return null;

            return new CategoryDto
            {
                Id = categoryEntity.Id,
                CategoryName = categoryEntity.CategoryName
            };
        }
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(category => new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            }).ToList();
        }

        public async Task<CategoryDto> UpdateCategory(int id, string categoryName)
        {
            var categoryEntity = await _categoryRepository.GetCategoryByIdAsync(id);
            if (categoryEntity == null)
            {
                return null;
            }

            categoryEntity.CategoryName = categoryName;

            await _categoryRepository.UpdateCategoryAsync(categoryEntity);

            return new CategoryDto
            {
                Id = categoryEntity.Id,
                CategoryName = categoryEntity.CategoryName
            };
        }

        public async Task DeleteCategory(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                try
                {
                    await _categoryRepository.DeleteCategoryAsync(id);
                    _loggerService.LogInformation($"Deleted category {id}");
                }
                catch (Exception error)
                {
                    _loggerService.LogWarning(error.Message);
                }
            });
        }

       
    }

}