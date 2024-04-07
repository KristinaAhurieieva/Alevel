using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FourModule.Entities;

namespace FourModule.EntityConfigurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.BreedId).IsRequired();
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.LocationId).IsRequired();
            builder.Property(p => p.Age).HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.ImageUrl).IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.CategoryId);

            builder
                .HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.BreedId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Location)
                .WithMany(l => l.Pets)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

