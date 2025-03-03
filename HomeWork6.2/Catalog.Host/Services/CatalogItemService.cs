using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly IMapper _mapper;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _mapper = mapper;
    }

    public Task<int?> Add(
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.Add(
        name,
        description,
        price,
        availableStock,
        catalogBrandId,
        catalogTypeId,
        pictureFileName));
    }

    public async Task<CatalogItemDto> UpdateItem(CatalogItemDto item)
    {
        var catalogItem = _mapper.Map<CatalogItem>(item);

        catalogItem = await ExecuteSafeAsync(() =>
          _catalogItemRepository.UpdateItem(catalogItem));

        return  _mapper.Map<CatalogItemDto>(catalogItem);
    }

    public async Task<CatalogItemDto> DeleteItem(int id)
    {
        var catalogItem = _mapper.Map<CatalogItem>(id);
        catalogItem = await ExecuteSafeAsync(() =>
        _catalogItemRepository.DeleteItem(id));

        return _mapper.Map<CatalogItemDto>(catalogItem);
    }

}