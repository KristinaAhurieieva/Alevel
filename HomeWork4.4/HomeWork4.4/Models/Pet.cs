using System;
namespace HomeWork4._4.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category_Id { get; set; }
        public int Breed_Id { get; set; }
        public float Age { get; set; }
        public int Location_Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
    }
}

