using System;
using HomeWork4._4.Entities;
using HomeWork4._4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeWork4._4.EntityConfigurations
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.BreedName).IsRequired();
            builder.Property(i => i.Category_Id).IsRequired();

            builder.HasOne(category => category.Category)
                   .WithMany(b => b.Breed)
                   .HasForeignKey(b => b.Category_Id) 
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

