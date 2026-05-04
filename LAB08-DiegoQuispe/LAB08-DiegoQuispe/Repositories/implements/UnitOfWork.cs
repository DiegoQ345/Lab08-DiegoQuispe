using LAB08_DiegoQuispe.Models;
using LAB08_DiegoQuispe.Repositories.Interfaces;
using LAB08_DiegoQuispe.Repositories.implements;

namespace LAB08_DiegoQuispe.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly LinQDBContext _context;

    public ClientRepository Clients { get; }
    public OrderRepository Orders { get; }
    public ProductRepository Products { get; }

    public UnitOfWork(LinQDBContext context)
    {
        _context = context;
        Clients = new ClientRepository(context);
        Orders = new OrderRepository(context);
        Products = new ProductRepository(context);
    }

    public async Task<int> SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async ValueTask DisposeAsync()
        => await _context.DisposeAsync();
}