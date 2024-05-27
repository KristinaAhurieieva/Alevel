using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize)
    {
        var totalItems = await _dbContext.CatalogItems
            .LongCountAsync();

        var itemsOnPage = await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .OrderBy(c => c.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem>() { TotalCount = totalItems, Data = itemsOnPage };
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<CatalogItem?> UpdateItem(CatalogItem item)
    {
        var updateItem = await _dbContext.CatalogItems.FindAsync(item.Id);
        if (updateItem == null)
        {
            return null;
        }
        updateItem.Name = item.Name;
        updateItem.Description = item.Description;
        updateItem.Price = item.Price;
        updateItem.PictureFileName = item.PictureFileName;
        updateItem.CatalogTypeId = item.CatalogTypeId;
        updateItem.CatalogBrandId = item.CatalogBrandId;
        updateItem.AvailableStock = item.AvailableStock;

        await _dbContext.SaveChangesAsync();

        return updateItem;
    }

    public async Task<CatalogItem?> DeleteItem(int id)
    {
        var item = await _dbContext.CatalogItems.FindAsync(id);
        if (item == null)
        {
            return null;
        }

        _dbContext.CatalogItems.Remove(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<CatalogItem?> GetById(int id)
    {
        return await _dbContext.CatalogItems.FindAsync(id);
    }

    public async Task<IEnumerable<CatalogItem>> GetByType(int id)
    {
        return await _dbContext.CatalogItems.Where(item => item.CatalogTypeId == id).ToListAsync();
    }

    public async Task<IEnumerable<CatalogItem>> GetByBrand(int id)
    {
        return await _dbContext.CatalogItems.Where(item => item.CatalogBrandId == id).ToListAsync();
    }

    public async Task<IEnumerable<CatalogType>> GetTypes()
    {
        return await _dbContext.CatalogTypes.ToListAsync();
    }

    public async Task<IEnumerable<CatalogBrand>> GetBrands()
    {
        return await _dbContext.CatalogBrands.ToListAsync();
    }
}