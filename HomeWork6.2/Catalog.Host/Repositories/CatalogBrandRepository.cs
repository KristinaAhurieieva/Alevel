using System;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
	public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> AddBrand(int id, string brand)
        {
            var addBrand = await _dbContext.AddAsync(new CatalogBrand
            {
                Id = id,
                Brand = brand
            });

            await _dbContext.SaveChangesAsync();

            return addBrand.Entity.Id;
        }

        public async Task<CatalogBrand?> UpdateBrand(CatalogBrand catalogBrand)
        {
            var updateBrand = await _dbContext.CatalogBrands.FindAsync(catalogBrand);
            if (updateBrand == null)
            {
                return null;
            }
            updateBrand.Brand = catalogBrand.Brand;

            await _dbContext.SaveChangesAsync();

            return updateBrand;
        }

        public async Task<CatalogBrand?> DeleteBrand(int id)
        {
            var deleteBrand = await _dbContext.CatalogBrands.FindAsync(id);
            if (deleteBrand == null)
            {
                return null;
            }

            _dbContext.CatalogBrands.Remove(deleteBrand);
            await _dbContext.SaveChangesAsync();

            return deleteBrand;
        }
    }
}


