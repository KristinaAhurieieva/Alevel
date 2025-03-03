using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPageAsync(int pageIndex, int pageSize);
    Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<CatalogItem?> GetById(int id);
    Task<IEnumerable<CatalogItem>> GetByType(int id);
    Task<IEnumerable<CatalogItem>> GetByBrand(int id);
    Task<IEnumerable<CatalogType>> GetTypes();
    Task<IEnumerable<CatalogBrand>> GetBrands();
    Task<CatalogItem?> UpdateItem(CatalogItem item);
    Task<CatalogItem?> DeleteItem(int id);

}