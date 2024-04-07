using System;
namespace FourModule.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<PetEntity> Pets { get; set; } = new List<PetEntity>();
        public List<BreedEntity> Breed { get; set; } = new List<BreedEntity>();
    }
}

