using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
    }

    [HttpPost("add")]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.Add(
            request.Name,
            request.Description,
            request.Price,
            request.AvailableStock,
            request.CatalogBrandId,
            request.CatalogTypeId,
            request.PictureFileName);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPatch ("update")]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]

    public async Task<IActionResult> Update(CatalogItemDto request)
    {
        var result = await _catalogItemService.UpdateItem(request);
        return Ok(new AddItemResponse<CatalogItemDto>() { Id = result });
    }

    [HttpDelete("delete")]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]

    public async Task<IActionResult> DeleteItem(int id)
    {
        var deleteItem = await _catalogItemService.DeleteItem(id);
        if (deleteItem == null)
        {
            return NotFound();
        }

        return Ok(deleteItem);
    }
}