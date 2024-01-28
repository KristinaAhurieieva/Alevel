using System;
namespace HomeWorkSalad.Models.Abstractions
{
    public interface IVegetable
    {
        string Type { get; set; }
        decimal Calories { get; set; }
    }
}

