using LAB08_DiegoQuispe.Dtos;

namespace LAB08_DiegoQuispe.Services.Interfaces;

public interface IClientService
{
    Task<List<ClientDto>> GetByNameAsync(string name);
    Task<ClientOrdersDto?> GetTopClientAsync();
    Task<List<string>> GetClientsByProductAsync(int productId);
}