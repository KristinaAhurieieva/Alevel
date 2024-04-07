using System;
using FourModule.Dtos;

namespace FourModule.Services.Abstractions
{
	public interface ICategoryService
	{
        Task<CategoryDto> CreateCategory(string categoryName);
        Task<CategoryDto> GetCategory(int id);
        Task<List<CategoryDto>> GetAllCategories();
        Task<CategoryDto> UpdateCategory(int id, string categoryName);
        Task DeleteCategory(int id);

    }
}

