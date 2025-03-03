using AutoMapper;
using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<IEnumerable<CatalogItemDto>> GetCatalogItemByIdAsync(int id)
    {
        var catalogItem = await _catalogItemRepository.GetById(id);

        var catalogItemDto = _mapper.Map < IEnumerable<CatalogItemDto>>(catalogItem);

        return catalogItemDto;
    }

    public async Task<IEnumerable<CatalogTypeDto>> GetCatalogItemByTypeAsync(int id)
    {
        var catalogItem = await _catalogItemRepository.GetByType(id);

        var catalogTypeDto = _mapper.Map<IEnumerable<CatalogTypeDto>>(catalogItem);

        return catalogTypeDto;
    }

    public async Task<IEnumerable<CatalogTypeDto>> GetAllTypesAsync()
    {
        var types = await _catalogItemRepository.GetTypes();

        return _mapper.Map<IEnumerable<CatalogTypeDto>>(types);
    }

    public async Task<IEnumerable<CatalogBrandDto>> GetCatalogItemByBrandAsync(int id)
    {
        var catalogBrand = await _catalogItemRepository.GetByBrand(id);

        var catalogBrandDto = _mapper.Map < IEnumerable<CatalogBrandDto>>(catalogBrand);

        return catalogBrandDto;
    }

    public async Task<IEnumerable<CatalogBrandDto>> GetAllBrandsAsync()
    {
        var brands = await _catalogItemRepository.GetBrands();

        return _mapper.Map<IEnumerable<CatalogBrandDto>>(brands);
    }
}