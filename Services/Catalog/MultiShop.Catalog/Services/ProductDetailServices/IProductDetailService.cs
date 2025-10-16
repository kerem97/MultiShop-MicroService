using MultiShop.Catalog.Dtos.ProductDetail.Requests;
using MultiShop.Catalog.Dtos.ProductDetail.Responses;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailResponse>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailRequest request);
        Task UpdateProductDetailAsync(UpdateProductDetailRequest request);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailResponse> GetByIdProductDetailAsync(string id);
    }
}
