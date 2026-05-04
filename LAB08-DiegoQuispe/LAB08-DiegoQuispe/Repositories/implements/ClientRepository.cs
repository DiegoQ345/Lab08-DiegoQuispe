using System.Linq.Expressions;
using LAB08_DiegoQuispe.Dtos;
using LAB08_DiegoQuispe.Models;
using LAB08_DiegoQuispe.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LAB08_DiegoQuispe.Repositories.implements;

public class ClientRepository : IClientRepository
{
    
    private readonly LinQDBContext _context;

    public ClientRepository(LinQDBContext context)
    {
        _context = context;
    }
    
    
    public async Task<List<ClientDto>> GetByNameAsync(string name)
    {
        return await _context.Clients
            .AsNoTracking()
            .Where(c => c.Name.StartsWith(name))
            .Select(c => new ClientDto
            {
                ClientId = c.ClientId,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<ClientOrdersDto?> GetTopClientAsync()
    {
        return await _context.Orders
            .GroupBy(o => o.ClientId)
            .Select(g => new ClientOrdersDto
            {
                ClientId = g.Key,
                TotalOrders = g.Count()
            })
            .OrderByDescending(x => x.TotalOrders)
            .FirstOrDefaultAsync();
    }

    public async Task<List<string>> GetClientsByProductAsync(int productId)
    {
        return await _context.Orderdetails
            .Where(od => od.ProductId == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();

    }
}