using LAB08_DiegoQuispe.Dtos;

namespace LAB08_DiegoQuispe.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderDetailDto>> GetProductsByOrderAsync(int orderId);
    Task<int> GetTotalQuantityByOrderAsync(int orderId);
    Task<List<OrderDto>> GetAfterDateAsync(DateTime date);
    Task<List<OrderDetailDto>> GetAllWithDetailsAsync();
}