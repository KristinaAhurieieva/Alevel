using System;
using FourModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FourModule.EntityConfigurations
{
	public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
		public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.CategoryName).HasMaxLength(255);


        }
	}
}

