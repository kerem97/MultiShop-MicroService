using MultiShop.Catalog.Dtos.ProductImage.Requests;
using MultiShop.Catalog.Dtos.ProductImage.Responses;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageResponse>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageRequest request);
        Task UpdateProductImageAsync(UpdateProductImageRequest request);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageResponse> GetByIdProductImageAsync(string id);
    }
}
