using System;
using FourModule.Models;

namespace FourModule.Entities
{
    public class BreedEntity
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public int CategoryId { get; set; }
        public List<PetEntity> Pets { get; set; } = new List<PetEntity>();
        public CategoryEntity Category { get; set; }
    }
}

