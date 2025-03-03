using System;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories
{
	public class CatalogTypeRepository : ICatalogTypeRepository
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogTypeRepository> _logger;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogTypeRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;

            _logger = logger;
        }

        public async Task<int?> AddType(int id, string type)
        {
            var addType = await _dbContext.AddAsync(new CatalogType
            {
                Id = id,
                Type = type
            });

            await _dbContext.SaveChangesAsync();

            return addType.Entity.Id;
        }

        public async Task<CatalogType?> UpdateType(CatalogType catalogType)
        {
            var updateType = await _dbContext.CatalogTypes.FindAsync(catalogType);
           if (updateType == null)
            {
                return null;
            }
            updateType.Type = catalogType.Type;

             await _dbContext.SaveChangesAsync();

            return updateType;
        }

        public async Task<CatalogType?> DeleteType(int id)
        {
            var deleteType = await _dbContext.CatalogTypes.FindAsync(id);
            if (deleteType == null)
            {
                return null;
            }

            _dbContext.CatalogTypes.Remove(deleteType);
            await _dbContext.SaveChangesAsync();

            return deleteType;
        }
    }
}

