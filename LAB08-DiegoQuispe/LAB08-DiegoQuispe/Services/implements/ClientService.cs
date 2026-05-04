using LAB08_DiegoQuispe.Dtos;
using LAB08_DiegoQuispe.Repositories.Interfaces;
using LAB08_DiegoQuispe.Services.Interfaces;

namespace LAB08_DiegoQuispe.Services.implements;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _uow;

    public ClientService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<ClientDto>> GetByNameAsync(string name)
        => await _uow.Clients.GetByNameAsync(name);

    public async Task<ClientOrdersDto?> GetTopClientAsync()
        => await _uow.Clients.GetTopClientAsync();

    public async Task<List<string>> GetClientsByProductAsync(int productId)
        => await _uow.Clients.GetClientsByProductAsync(productId);
}