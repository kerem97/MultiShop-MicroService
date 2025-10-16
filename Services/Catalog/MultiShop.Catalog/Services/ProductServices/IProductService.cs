using MultiShop.Catalog.Dtos.Product.Requests;
using MultiShop.Catalog.Dtos.Product.Responses;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductResponse>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductRequest request);
        Task UpdateProductAsync(UpdateProductRequest request);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductResponse> GetByIdProductAsync(string id);
    }
}
