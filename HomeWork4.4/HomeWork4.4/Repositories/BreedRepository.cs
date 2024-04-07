using System;
using FourModule.Data;
using FourModule.Entities;
using FourModule.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FourModule.Repositories
{
    public class BreedRepository : IBreedRepository
    {
        private readonly ApplicationDbContext _context;

        public BreedRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BreedEntity> CreateBreedAsync(BreedEntity breed)
        {
            _context.Breeds.Add(breed);
            await _context.SaveChangesAsync();
            return breed;
        }
        public async Task<List<BreedEntity>> GetAllBreedsAsync()
        {
            return await _context.Breeds.ToListAsync();
        }

        public async Task<BreedEntity> GetBreedByIdAsync(int id)
        {
            return await _context.Breeds.FindAsync(id);
        }

        public async Task<BreedEntity> UpdateBreedAsync(BreedEntity breed)
        {
            _context.Breeds.Update(breed);
            await _context.SaveChangesAsync();
            return breed;
        }

        public async Task DeleteBreedAsync(int id)
        {
            var breed = await _context.Breeds.FindAsync(id);
            if (breed != null)
            {
                throw new Exception($"Pet with id - '{id}' not found");     
            }
            _context.Breeds.Remove(breed);
            await _context.SaveChangesAsync();
        }
    }
}

