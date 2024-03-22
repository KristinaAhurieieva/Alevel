using System;
using HomeWork4._4.Models;

namespace HomeWork4._4.Entities
{
    public class BreedEntity
    {
        public int Id { get; set; }
        public string BreedName { get; set; }
        public int Category_Id { get; set; }
        public ICollection<PetEntity> Pets { get; set; } = new List<PetEntity>();
        public CategoryEntity Category { get; set; }
    }
}

