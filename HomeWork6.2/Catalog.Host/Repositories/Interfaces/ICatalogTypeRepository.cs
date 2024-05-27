using System;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<int?> AddType(int id, string type);
        Task<CatalogType?> UpdateType(CatalogType catalogType);
        Task<CatalogType?> DeleteType(int id);
    }
}

