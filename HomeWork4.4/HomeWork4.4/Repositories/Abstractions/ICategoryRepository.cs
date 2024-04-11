using System;
using FourModule.Entities;
using FourModule.Repositories;

namespace FourModule.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<CategoryEntity> CreateCategoryAsync(CategoryEntity category);
        Task<CategoryEntity> GetCategoryByIdAsync(int id);
        Task<List<CategoryEntity>> GetAllCategoriesAsync();
        Task<CategoryEntity> UpdateCategoryAsync(CategoryEntity category);
        Task DeleteCategoryAsync(int id);
    }
}

