﻿using System;
using FourModule.Models;

namespace FourModule.Entities
{
    public class LocationEntity
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public List<PetEntity> Pets { get; set; } = new List<PetEntity>();
    }
}

