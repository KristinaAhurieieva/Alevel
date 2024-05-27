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
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogTypeController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPatch ("update")]
    [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateType(CatalogTypeDto request)
    {
        var result = await _catalogTypeService.UpdateType(request);
        return Ok(new AddItemResponse<CatalogTypeDto>() { Id = result });
    }

    [HttpPost("add-type")]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddType(CreateTypeRequest request)
    {
        var result = await _catalogTypeService.AddType(request);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpDelete ("delete")]
    [ProducesResponseType(typeof(CatalogTypeDto), (int)HttpStatusCode.OK)]

    public async Task<IActionResult> DeleteType(int id)
    {
        var deleteType = await _catalogTypeService.DeleteType(id);
        if (deleteType == null)
        {
            return NotFound();
        }

        return Ok(deleteType);
    }
}