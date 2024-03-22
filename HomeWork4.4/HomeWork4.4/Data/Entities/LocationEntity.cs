using System;
using HomeWork4._4.Models;

namespace HomeWork4._4.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public ICollection<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}

