using LAB08_DiegoQuispe.Dtos;
using LAB08_DiegoQuispe.Repositories.Interfaces;
using LAB08_DiegoQuispe.Services.Interfaces;

namespace LAB08_DiegoQuispe.Services.implements;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _uow;

    public ProductService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<ProductDto>> GetByMinPriceAsync(decimal price)
        => await _uow.Products.GetByMinPriceAsync(price);

    public async Task<ProductDto?> GetMostExpensiveAsync()
        => await _uow.Products.GetMostExpensiveAsync();

    public async Task<decimal> GetAveragePriceAsync()
        => await _uow.Products.GetAveragePriceAsync();

    public async Task<List<ProductDto>> GetWithoutDescriptionAsync()
        => await _uow.Products.GetWithoutDescriptionAsync();

    public async Task<List<string>> GetProductsByClientAsync(int clientId)
        => await _uow.Products.GetProductsByClientAsync(clientId);
}