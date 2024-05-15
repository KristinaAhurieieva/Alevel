using Microsoft.AspNetCore.Mvc;
using eShop.Models;

namespace eShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController 
{
    private static readonly string[] Summaries = new[]
    {
        "Broccoli", "Carrot", "Pepper", "Potato", "Cucumber", "Tomato"
    };

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProduct")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
        {
            DateAdded = DateTime.Now.AddDays(index), 
            Grams = Random.Shared.Next(100, 500), 
            Vegetable = Summaries[Random.Shared.Next(Summaries.Length)], 
        })
        .ToArray();

    }

    [HttpPost(Name = "PostProduct")]
    public string Post(CalkProduct input)
    {

        return ProductServices.GetSummary(input.Product).ToString();
        
    }


}

