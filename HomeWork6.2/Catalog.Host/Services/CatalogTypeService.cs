using System;
using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddType(CreateTypeRequest request)
        {
            if (request.Type == null)
            {
                return null;
            }
            return await ExecuteSafeAsync(() => _catalogTypeRepository.AddType(
            request.Id,
            request.Type
        ));
        }

        public async Task<CatalogTypeDto> UpdateType(CatalogTypeDto type)
        {
            var catalogType = _mapper.Map<CatalogType>(type);

            catalogType = await ExecuteSafeAsync(() =>
              _catalogTypeRepository.UpdateType(catalogType));

            return _mapper.Map<CatalogTypeDto>(catalogType);
        }

        public async Task<CatalogTypeDto> DeleteType(int id)
        {
            var catalogType = _mapper.Map<CatalogType>(id);
            catalogType = await ExecuteSafeAsync(() =>
            _catalogTypeRepository.DeleteType(id));

            return _mapper.Map<CatalogTypeDto>(catalogType);
        }

    }
}
