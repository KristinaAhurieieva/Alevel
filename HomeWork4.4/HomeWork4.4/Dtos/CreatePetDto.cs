using System;
namespace FourModule.Dtos
{
	public class CreatePetDto
	{
        public string Name { get; set; }
        public float Age { get; set; }
        public int BreedId { get; set; }
        public int LocationId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}

