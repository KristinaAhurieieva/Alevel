using System;
using FourModule.Data;
using FourModule.Entities;
using FourModule.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FourModule.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LocationEntity> CreateLocationAsync(LocationEntity location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<LocationEntity> GetLocationByIdAsync(int id)
        {
            return await _context.Locations.FindAsync(id);
        }

        public async Task<List<LocationEntity>> GetAllLocationsAsync()
        {
            return await _context.Locations.ToListAsync();
        }

        public async Task<LocationEntity> UpdateLocationAsync(LocationEntity location)
        {
            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task DeleteLocationAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location != null)
            {
                throw new Exception($"Location with id - '{id}' not found");
            }
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
        }

    }
}

