using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FourModule.Data;
using System.Linq;
using System.Threading.Tasks;
using FourModule.Services.Abstractions;
using FourModule.Models;
using FourModule.Dtos;

namespace FourModule
{
    public class App
    {
        private readonly IPetService _petService;
        private readonly IBreedService _breedService;
        private readonly ILocationService _locationService;
        private readonly ICategoryService _categoryService;

        public App(
        IPetService petService,
        IBreedService breedService,
        ILocationService locationService,
        ICategoryService categoryService)
        {
            _petService = petService;
            _breedService = breedService;
            _locationService = locationService;
            _categoryService = categoryService;
        }
        public async Task Start()
        {
            var name = "Name";
            var breedId = "Breed";
            var locationId = "Location";
            var age = "Age";
            var categoryId = "Category";
            var imageUrl = "Image";
            var description = "Description";

            var bigDogsCategory = await _categoryService.CreateCategory("Big");
            var smallDogsCategory = await _categoryService.CreateCategory("Small");

            var breed1 = await _breedService.CreateBreed("Labrador", bigDogsCategory.Id);
            var breed2 = await _breedService.CreateBreed("Buldog", smallDogsCategory.Id);
            var breed3 = await _breedService.CreateBreed("Rotveiler", bigDogsCategory.Id);
            var breed4 = await _breedService.CreateBreed("Multipu", smallDogsCategory.Id);


            var location1 = await _locationService.CreateLocation("Ukraine");
            var location2 = await _locationService.CreateLocation("Georgia");

            var createPetDto1 = new CreatePetDto
            {
                Name = "Bars",
                BreedId = breed1.Id,
                LocationId = location1.Id,
                Age = 3,
                ImageUrl = "Image1",
                Description = "description"
            };
            var createPetDto2 = new CreatePetDto
            {
                Name = "Jack",
                BreedId = breed2.Id,
                LocationId = location2.Id,
                Age = 2,
                ImageUrl = "Image2",
                Description = "Description2"
            };

            var createPetDto3 = new CreatePetDto
            {
                Name = "Rex",
                BreedId = breed3.Id,
                LocationId = location1.Id,
                Age = 3,
                ImageUrl = "Image3", 
                Description = "Description3"
            };

            var createPetDto4 = new CreatePetDto
            {
                Name = "Sharic",
                BreedId = breed3.Id,
                LocationId = location1.Id,
                Age = 5,
                ImageUrl = "Image4",
                Description = "Description4"
            };

            var pet1 = await _petService.CreatePet(createPetDto1);
            var pet2 = await _petService.CreatePet(createPetDto2);
            var pet3 = await _petService.CreatePet(createPetDto3);
            var pet4 = await _petService.CreatePet(createPetDto4);

            Console.WriteLine($"Pet 1 created with ID: {pet1.Id}");
            Console.WriteLine($"Pet 2 created with ID: {pet2.Id}");
            Console.WriteLine($"Pet 3 created with ID: {pet3.Id}");
            Console.WriteLine($"Pet 4 created with ID: {pet4.Id}");
        }
    }
}

