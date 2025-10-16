using MultiShop.Catalog.Dtos.Category.Requests;
using MultiShop.Catalog.Dtos.Category.Responses;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryResponse>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryRequest request);
        Task UpdateCategoryAsync(UpdateCategoryRequest request);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryResponse> GetByIdCategoryAsync(string id);
    }
}
