using System;
using FourModule.Repositories.Abstractions;
using FourModule.Data;
using FourModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace FourModule.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ApplicationDbContext _context;

        public PetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PetEntity> CreatePetAsync(PetEntity pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task<PetEntity> GetPetByIdAsync(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<List<PetEntity>> GetAllPetsAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public async Task<PetEntity> UpdatePetAsync(PetEntity pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task DeletePetAsync(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                throw new Exception($"Pet with id - '{id}' not found");
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<List<(string CategoryName, int UniqueBreedCount)>> GroupByCategoryAndCountUniqueBreedAsync()
        {
            var query = from pet in _context.Pets
                        where pet.Age > 3 && pet.Location.LocationName == "Ukraine"
                        group pet by pet.Category.CategoryName into g
                        select new
                        {
                            CategoryName = g.Key,
                            UniqueBreedCount = g.Select(p => p.BreedId).Distinct().Count()
                        };

            var result = await query.ToListAsync();

            return result.Select(item => (item.CategoryName, item.UniqueBreedCount)).ToList();
        }
    }
}

