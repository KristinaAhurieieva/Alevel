using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using HomeWork4._4.Entities;

namespace HomeWork4._4.EntityConfigurations
{
    public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(p => p.Breed_Id).IsRequired();
            builder.Property(p => p.Category_Id).IsRequired();
            builder.Property(p => p.Location_Id).IsRequired();
            builder.Property(p => p.Age).HasMaxLength(100);
            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Description).HasMaxLength(1000);
            builder.Property(p => p.ImageUrl).IsRequired();

            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.Category_Id);

            builder
                .HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.Breed_Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Location)
                .WithMany(l => l.Pets)
                .HasForeignKey(p => p.Location_Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

