using System;
using FourModule.Dtos;

namespace FourModule.Services.Abstractions
{
	public interface IPetService
	{
        Task<PetDto> CreatePet(CreatePetDto pet);
        Task<PetDto> GetPet(int id);
        Task<List<PetDto>> GetAllPets();
        Task<PetDto> UpdatePet(UpdatePetDto updatePetDto);
        Task DeletePet(int id);

    }
}

