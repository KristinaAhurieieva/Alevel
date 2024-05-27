using System;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
	public interface ICatalogBrandRepository
	{
        Task<int?> AddBrand(int id, string brand);
        Task<CatalogBrand?> UpdateBrand(CatalogBrand catalogBrand);
        Task<CatalogBrand?> DeleteBrand(int id);

    }
}

