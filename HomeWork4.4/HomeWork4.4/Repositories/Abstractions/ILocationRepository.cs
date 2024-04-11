using System;
using FourModule.Entities;

namespace FourModule.Repositories.Abstractions
{
    public interface ILocationRepository
    {
        Task<LocationEntity> CreateLocationAsync(LocationEntity location);
        Task<LocationEntity> GetLocationByIdAsync(int id);
        Task<List<LocationEntity>> GetAllLocationsAsync();
        Task<LocationEntity> UpdateLocationAsync(LocationEntity location);
        Task DeleteLocationAsync(int id);
    }
}

