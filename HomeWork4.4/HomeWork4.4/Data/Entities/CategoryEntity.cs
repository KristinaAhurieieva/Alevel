using System;
namespace HomeWork4._4.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<PetEntity> Pets { get; set; } = new List<PetEntity>();
        public ICollection<BreedEntity> Breed { get; set; } = new List<BreedEntity>();
    }
}

