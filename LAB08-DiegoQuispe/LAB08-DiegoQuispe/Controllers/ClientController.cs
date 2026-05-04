using LAB08_DiegoQuispe.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_DiegoQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // Ejercicio 1
    [HttpGet("E1-by-name/{name}")]
    public async Task<IActionResult> GetByName(string name)
        => Ok(await _clientService.GetByNameAsync(name));

    // Ejercicio 9
    [HttpGet("E9-top")]
    public async Task<IActionResult> GetTop()
        => Ok(await _clientService.GetTopClientAsync());

    // Ejercicio 12
    [HttpGet("E12-by-product/{productId}")]
    public async Task<IActionResult> GetByProduct(int productId)
        => Ok(await _clientService.GetClientsByProductAsync(productId));
}