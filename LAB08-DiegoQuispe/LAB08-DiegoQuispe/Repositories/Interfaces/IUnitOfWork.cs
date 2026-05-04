using LAB08_DiegoQuispe.Repositories.implements;

namespace LAB08_DiegoQuispe.Repositories.Interfaces;

public interface IUnitOfWork
{
    ClientRepository Clients { get; }
    OrderRepository Orders { get; }
    ProductRepository Products { get; }
    
    Task<int> SaveChangesAsync();
}