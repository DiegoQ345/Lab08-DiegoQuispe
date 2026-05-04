using LAB08_DiegoQuispe.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LAB08_DiegoQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    // Ejercicio 3
    [HttpGet("{orderId}/E3-products")]
    public async Task<IActionResult> GetProductsByOrder(int orderId)
        => Ok(await _orderService.GetProductsByOrderAsync(orderId));

    // Ejercicio 4
    [HttpGet("{orderId}/E4-total-quantity")]
    public async Task<IActionResult> GetTotalQuantity(int orderId)
        => Ok(await _orderService.GetTotalQuantityByOrderAsync(orderId));

    // Ejercicio 6
    [HttpGet("E6-after-date")]
    public async Task<IActionResult> GetAfterDate([FromQuery] DateTime date)
        => Ok(await _orderService.GetAfterDateAsync(date));

    // Ejercicio 10
    [HttpGet("E10-all-with-details")]
    public async Task<IActionResult> GetAllWithDetails()
        => Ok(await _orderService.GetAllWithDetailsAsync());
}