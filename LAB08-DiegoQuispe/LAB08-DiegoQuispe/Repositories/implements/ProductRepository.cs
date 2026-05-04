using LAB08_DiegoQuispe.Dtos;
using LAB08_DiegoQuispe.Models;
using Microsoft.EntityFrameworkCore;

namespace LAB08_DiegoQuispe.Repositories.implements;

public class ProductRepository
{
    private readonly LinQDBContext _context;

    public ProductRepository(LinQDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductDto>> GetByMinPriceAsync(decimal price)
    {
        return await _context.Products
            .AsNoTracking()
            .Where(p => p.Price > price)
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();
    }
    
    public async Task<ProductDto?> GetMostExpensiveAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .OrderByDescending(p => p.Price)
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name,
                Price = p.Price
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products
            .AverageAsync(p => p.Price);
    }
    
    public async Task<List<ProductDto>> GetWithoutDescriptionAsync()
    {
        return await _context.Products
            .AsNoTracking()
            .Where(p => string.IsNullOrEmpty(p.Description))
            .Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                Name = p.Name
            })
            .ToListAsync();
    }
    
    public async Task<List<string>> GetProductsByClientAsync(int clientId)
    {
        return await _context.Orders
            .Where(o => o.ClientId == clientId)
            .SelectMany(o => o.Orderdetails)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();
    }
}