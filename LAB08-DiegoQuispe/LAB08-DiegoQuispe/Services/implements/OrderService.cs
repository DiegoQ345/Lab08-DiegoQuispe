using LAB08_DiegoQuispe.Dtos;
using LAB08_DiegoQuispe.Repositories.Interfaces;
using LAB08_DiegoQuispe.Services.Interfaces;

namespace LAB08_DiegoQuispe.Services.implements;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _uow;

    public OrderService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<OrderDetailDto>> GetProductsByOrderAsync(int orderId)
        => await _uow.Orders.GetProductsByOrderAsync(orderId);

    public async Task<int> GetTotalQuantityByOrderAsync(int orderId)
        => await _uow.Orders.GetTotalQuantityByOrderAsync(orderId);

    public async Task<List<OrderDto>> GetAfterDateAsync(DateTime date)
        => await _uow.Orders.GetAfterDateAsync(date);

    public async Task<List<OrderDetailDto>> GetAllWithDetailsAsync()
        => await _uow.Orders.GetAllWithDetailsAsync();
}