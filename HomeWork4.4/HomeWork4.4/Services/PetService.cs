using System;
using FourModule.Repositories.Abstractions;
using FourModule.Data;
using FourModule.Dtos;
using FourModule.Entities;
using FourModule.Services.Abstractions;

namespace FourModule.Services
{
    public class PetService : BaseDataService<ApplicationDbContext>, IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly ILogger<PetService> _loggerService;
        private readonly IBreedService _breedService;

        public PetService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IPetRepository petRepository, IBreedService breedService,
            ILogger<PetService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _petRepository = petRepository;
            _loggerService = loggerService;
        }

        public async Task<PetDto> CreatePet(CreatePetDto pet)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var breed = await _breedService.GetBreed(pet.BreedId);
                int categoryId = breed.CategoryId;

                var petEntity = new PetEntity
                {
                    Name = pet.Name,
                    Age = pet.Age,
                    CategoryId = categoryId,
                    BreedId = pet.BreedId,
                    LocationId = pet.LocationId,
                    ImageUrl = pet.ImageUrl,
                    Description = pet.Description
                };

                await _petRepository.CreatePetAsync(petEntity);

                _loggerService.LogInformation($"Created pet = {pet.Name}");

                return new PetDto();
            });
        }


        public async Task<PetDto> GetPet(int id)
        {
            var petEntity = await _petRepository.GetPetByIdAsync(id);

            if (petEntity == null)
            {
                _loggerService.LogWarning($"Pet with = {id} not found");
                return null;
            }

            return new PetDto
            {
                Id = petEntity.Id,
                Name = petEntity.Name,
                Age = petEntity.Age,
                CategoryId = petEntity.CategoryId,
                BreedId = petEntity.BreedId,
                LocationId = petEntity.LocationId,
                ImageUrl = petEntity.ImageUrl,
                Description = petEntity.Description
            };
        }

        public async Task<List<PetDto>> GetAllPets()
        {
            var pets = await _petRepository.GetAllPetsAsync();

            return pets.Select(pet => new PetDto
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                CategoryId = pet.CategoryId,
                BreedId = pet.BreedId,
                LocationId = pet.LocationId,
                ImageUrl = pet.ImageUrl,
                Description = pet.Description
            }).ToList();
        }

        public async Task<PetDto> UpdatePet(UpdatePetDto updatePetDto)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var pet = await _petRepository.GetPetByIdAsync(updatePetDto.Id);

                if (pet == null)
                {
                    _loggerService.LogWarning($"Pet {updatePetDto.Id} not found");

                    return new PetDto();
                }

                pet.Name = updatePetDto.Name;
                pet.Age = updatePetDto.Age;
                pet.CategoryId = updatePetDto.CategoryId;
                pet.BreedId = updatePetDto.BreedId;
                pet.LocationId = updatePetDto.LocationId;
                pet.ImageUrl = updatePetDto.ImageUrl;
                pet.Description = updatePetDto.Description;

                await _petRepository.UpdatePetAsync(pet);

                _loggerService.LogInformation($"Updated pet {updatePetDto.Id}");

                return new PetDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    Age = pet.Age,
                    CategoryId = pet.CategoryId,
                    BreedId = pet.BreedId,
                    LocationId = pet.LocationId,
                    ImageUrl = pet.ImageUrl,
                    Description = pet.Description
                };
            });
        }

        public async Task DeletePet(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                try
                {
                    await _petRepository.DeletePetAsync(id);
                    _loggerService.LogInformation($"Deleted pet {id}");
                }
                catch(Exception error)
                {
                    _loggerService.LogWarning(error.Message);
                }
            });
        }

    }
}