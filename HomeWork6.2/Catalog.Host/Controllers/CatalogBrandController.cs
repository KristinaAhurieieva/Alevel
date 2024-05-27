using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(
        ILogger<CatalogBrandController> logger,
        ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpPatch ("update")]
    [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateBrand(CatalogTypeDto request)
    {
        var result = await _catalogBrandService.UpdateBrand(request);
        return Ok(new AddItemResponse<CatalogTypeDto>() { Id = result });
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddBrand(CreateBrandRequest request)
    {
        var result = await _catalogBrandService.AddBrand(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpDelete ("delete")]
    [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]

    public async Task<IActionResult> DeleteBrand(int id)
    {
        var deleteBrand = await _catalogBrandService.DeleteBrand(id);
        if (deleteBrand == null)
        {
            return NotFound();
        }

        return Ok(deleteBrand);
    }
}