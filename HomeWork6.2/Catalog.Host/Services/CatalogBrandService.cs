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
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddBrand(CreateBrandRequest request)
        {
            if(request.Brand == null)
            {
                return null;
            }
            return await ExecuteSafeAsync(() => _catalogBrandRepository.AddBrand(
                request.Id,
                request.Brand
            ));
        }
        public async Task<CatalogTypeDto> UpdateBrand(CatalogTypeDto brand)
        {
            var catalogBrand = _mapper.Map<CatalogBrand>(brand);

            catalogBrand= await ExecuteSafeAsync(() =>
              _catalogBrandRepository.UpdateBrand(catalogBrand));

            return _mapper.Map<CatalogTypeDto>(catalogBrand);
        }

        public async Task<CatalogTypeDto> DeleteBrand(int id)
        {
            var catalogBrand = _mapper.Map<CatalogBrand>(id);
            catalogBrand = await ExecuteSafeAsync(() =>
            _catalogBrandRepository.DeleteBrand(catalogBrand.Id));

            return _mapper.Map<CatalogTypeDto>(catalogBrand);
        }
    }
}

