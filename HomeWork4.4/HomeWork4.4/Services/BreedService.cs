using System;
using FourModule.Services.Abstractions;
using FourModule.Data;
using FourModule.Repositories.Abstractions;
using FourModule.Dtos;
using FourModule.Models;
using Microsoft.EntityFrameworkCore;
using FourModule.Entities;
using FourModule.Repositories;

namespace FourModule.Services
{
    public class BreedService : BaseDataService<ApplicationDbContext>, IBreedService
    {
        private readonly IBreedRepository _breedRepository;
        private readonly ILogger<BreedService> _loggerService;

        public BreedService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            IBreedRepository breedRepository,
            ILogger<BreedService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _breedRepository = breedRepository;
            _loggerService = loggerService;
        }

        public async Task<BreedDto> CreateBreed(string breedName, int categoryId)
        {
            var breedEntity = await _breedRepository.CreateBreedAsync(new BreedEntity { BreedName = breedName });
            return new BreedDto { Id = breedEntity.Id, BreedName = breedName };
        }


        public async Task<BreedDto> GetBreed(int id)
        {
            var breedEntity = await _breedRepository.GetBreedByIdAsync(id);
            if (breedEntity == null)
                return null;

            return new BreedDto { Id = breedEntity.Id, BreedName = breedEntity.BreedName };
        }

        public async Task<List<BreedDto>> GetAllBreeds()
        {
            var breedEntities = await _breedRepository.GetAllBreedsAsync();
            return breedEntities.Select(breedEntity => new BreedDto { Id = breedEntity.Id, BreedName = breedEntity.BreedName }).ToList();
        }

        public async Task<BreedDto> UpdateBreed(int id, string breedName, int categoryId)
        {
            var breedEntity = await _breedRepository.GetBreedByIdAsync(id);
            if (breedEntity == null)
                return null;

            breedEntity.BreedName = breedName;
            breedEntity.CategoryId = categoryId;

            await _breedRepository.UpdateBreedAsync(breedEntity);

            return new BreedDto { Id = breedEntity.Id, BreedName = breedName };
        }

        public async Task DeleteBreed(int id)
        {
            try
            {
                await _breedRepository.DeleteBreedAsync(id);
                _loggerService.LogInformation($"Deleted breed {id}");
            }
            catch (Exception error)
            {
                _loggerService.LogWarning(error.Message);
            }
        }
        
    }

}

