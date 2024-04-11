using System;
using FourModule.Entities;
using FourModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourModule.EntityConfigurations
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.BreedName).IsRequired();
            builder.Property(i => i.CategoryId).IsRequired();

            builder.HasOne(category => category.Category)
                   .WithMany(b => b.Breed)
                   .HasForeignKey(b => b.CategoryId) 
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

