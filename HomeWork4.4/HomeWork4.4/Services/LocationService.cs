using System;
using FourModule.Services.Abstractions;
using FourModule.Repositories.Abstractions;
using FourModule.Data;
using FourModule.Entities;
using FourModule.Dtos;

namespace FourModule.Services
{
    public class LocationService : BaseDataService<ApplicationDbContext>, ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger<LocationService> _loggerService;

        public LocationService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ILocationRepository locationRepository,
            ILogger<LocationService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _locationRepository = locationRepository;
            _loggerService = loggerService;
        }

        public async Task<LocationDto> CreateLocation(string locationName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var location = new LocationEntity
                {
                    LocationName = locationName
                };

                await _locationRepository.CreateLocationAsync(location);

                _loggerService.LogInformation($"Created location = {locationName}");

                var locationDto = new LocationDto
                {
                    Id = location.Id,
                    LocationName = location.LocationName
                };

                return locationDto;
            });
        }


        public async Task<LocationDto?> GetLocation(int id)
        {
            var locationEntity = await _locationRepository.GetLocationByIdAsync(id);

            if (locationEntity == null)
            {
                _loggerService.LogWarning($"Location {id} not found");
                return null;
            }

            return new LocationDto
            {
                Id = locationEntity.Id,
                LocationName = locationEntity.LocationName
            };
        }

        public async Task<LocationDto?> UpdateLocation(int id, string locationName)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var location = await _locationRepository.GetLocationByIdAsync(id);

                if (location == null)
                {
                    _loggerService.LogWarning($"Location = {id} not found");
                    return null;
                }

                location.LocationName = locationName;

                await _locationRepository.UpdateLocationAsync(location);

                _loggerService.LogInformation($"Updated location = {id}");

                return new LocationDto
                {
                    Id = location.Id,
                    LocationName = location.LocationName
                };
            });
        }


        public async Task DeleteLocation(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var location = await _locationRepository.GetLocationByIdAsync(id);

                if (location == null)
                {
                    _loggerService.LogWarning($"Location = {id} not found");
                    return;
                }

                try
                {
                    await _locationRepository.DeleteLocationAsync(id);
                    _loggerService.LogInformation($"Deleted location = {id}");
                }
                catch (Exception ex)
                {
                    _loggerService.LogError($"Error deleting location = {id}: {ex.Message}");
                }
            });
        }


    }
}