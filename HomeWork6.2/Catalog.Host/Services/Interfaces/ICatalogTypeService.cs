using System;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Services.Interfaces
{
	public interface ICatalogTypeService
	{
        Task<int?> AddType(CreateTypeRequest request);
        Task<CatalogTypeDto> UpdateType(CatalogTypeDto type);
        Task<CatalogTypeDto> DeleteType(int id);
    }
}

