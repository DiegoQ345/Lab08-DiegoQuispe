using LAB08_DiegoQuispe.Dtos;
using LAB08_DiegoQuispe.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_DiegoQuispe.Repositories.implements;

public class OrderRepository
{
    private readonly LinQDBContext _context;

    public OrderRepository(LinQDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<OrderDetailDto>> GetProductsByOrderAsync(int orderId)
    {
        return await _context.Orderdetails
            .AsNoTracking()
            .Where(od => od.OrderId == orderId)
            .Select(od => new OrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
    
    public async Task<int> GetTotalQuantityByOrderAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.OrderId == orderId)
            .SumAsync(od => od.Quantity);
    }
    
    public async Task<List<OrderDto>> GetAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .AsNoTracking()
            .Where(o => o.OrderDate > date)
            .Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                ClientId = o.ClientId,
                OrderDate = o.OrderDate
            })
            .ToListAsync();
    }
    
    public async Task<List<OrderDetailDto>> GetAllWithDetailsAsync()
    {
        return await _context.Orderdetails
            .AsNoTracking()
            .Select(od => new OrderDetailDto
            {
                ProductName = od.Product.Name,
                Quantity = od.Quantity
            })
            .ToListAsync();
    }
}