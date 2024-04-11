using System;
using FourModule.Entities;

namespace FourModule.Repositories.Abstractions
{
    public interface IBreedRepository
    {
        Task<BreedEntity> CreateBreedAsync(BreedEntity breed);
        Task<BreedEntity> GetBreedByIdAsync(int id);
        Task<List<BreedEntity>> GetAllBreedsAsync();
        Task<BreedEntity> UpdateBreedAsync(BreedEntity breed);
        Task DeleteBreedAsync(int id);
    }
}

