using LAB08_DiegoQuispe.Dtos;

namespace LAB08_DiegoQuispe.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetByMinPriceAsync(decimal price);
    Task<ProductDto?> GetMostExpensiveAsync();
    Task<decimal> GetAveragePriceAsync();
    Task<List<ProductDto>> GetWithoutDescriptionAsync();
    Task<List<string>> GetProductsByClientAsync(int clientId);
}