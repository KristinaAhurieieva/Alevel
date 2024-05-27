using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<IEnumerable<CatalogItemDto>> GetCatalogItemByIdAsync(int id);
    Task<IEnumerable<CatalogTypeDto>> GetCatalogItemByTypeAsync(int id);
    Task<IEnumerable<CatalogTypeDto>> GetAllTypesAsync();
    Task<IEnumerable<CatalogBrandDto>> GetCatalogItemByBrandAsync(int id);
    Task<IEnumerable<CatalogBrandDto>> GetAllBrandsAsync();
}