using System;
using FourModule.Dtos;

namespace FourModule.Services.Abstractions
{
	public interface IBreedService
	{
        Task<BreedDto> CreateBreed(string breedName, int categoryId);
        Task<BreedDto> GetBreed(int id);
        Task<List<BreedDto>> GetAllBreeds();
        Task<BreedDto> UpdateBreed(int id, string breedName, int categoryId);
        Task DeleteBreed(int id);
    }
}

