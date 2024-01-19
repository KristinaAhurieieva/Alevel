using System;
using System.Xml.Linq;

namespace SweetGift.Models
{
    public class Sweet
    {

        public string? Name { get; set; }
        public double Weight { get; set; }
        public string? Type { get; set; }
        public int Id { get; set; }
        public string Flavour { get; set; }

        public Sweet(string name, double weight, string type, int id, string flavour)
        {
            Name = name;
            Weight = weight;
            Type = type;
            Id = id;
            Flavour = flavour;

            
        }

        public virtual void Display()
        {
            Console.WriteLine($"Sweet: Name: {Name}, Weight: {Weight}, Type: {Type}, Id: {Id}, Flavour: {Flavour}");
        }

        


    }
}

