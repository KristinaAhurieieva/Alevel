using System;
using FourModule.Entities;

namespace FourModule.Repositories.Abstractions
{
    public interface IPetRepository
    {
        Task<PetEntity> CreatePetAsync(PetEntity pet);
        Task<PetEntity> GetPetByIdAsync(int id);
        Task<List<PetEntity>> GetAllPetsAsync();
        Task<PetEntity> UpdatePetAsync(PetEntity pet);
        Task DeletePetAsync(int id);
        Task<List<(string CategoryName, int UniqueBreedCount)>> GroupByCategoryAndCountUniqueBreedAsync();
    }
}

