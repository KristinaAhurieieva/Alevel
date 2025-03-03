using System;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces
{
	public interface ICatalogBrandService
	{
        Task<int?> AddBrand(CreateBrandRequest request);
        Task<CatalogTypeDto> UpdateBrand(CatalogTypeDto brand);
        Task<CatalogTypeDto> DeleteBrand(int id);

    }
}

