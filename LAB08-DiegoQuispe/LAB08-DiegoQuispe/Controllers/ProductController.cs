using LAB08_DiegoQuispe.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_DiegoQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    // Ejercicio 2
    [HttpGet("E2-by-min-price/{price}")]
    public async Task<IActionResult> GetByMinPrice(decimal price)
        => Ok(await _productService.GetByMinPriceAsync(price));

    // Ejercicio 5
    [HttpGet("E5-most-expensive")]
    public async Task<IActionResult> GetMostExpensive()
        => Ok(await _productService.GetMostExpensiveAsync());

    // Ejercicio 7
    [HttpGet("E7-average-price")]
    public async Task<IActionResult> GetAveragePrice()
        => Ok(await _productService.GetAveragePriceAsync());

    // Ejercicio 8
    [HttpGet("E8-without-description")]
    public async Task<IActionResult> GetWithoutDescription()
        => Ok(await _productService.GetWithoutDescriptionAsync());

    // Ejercicio 11
    [HttpGet("E11-by-client/{clientId}")]
    public async Task<IActionResult> GetByClient(int clientId)
        => Ok(await _productService.GetProductsByClientAsync(clientId));
}