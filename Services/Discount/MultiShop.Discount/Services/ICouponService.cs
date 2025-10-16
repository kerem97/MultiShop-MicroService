using MultiShop.Discount.Dtos.Requests;
using MultiShop.Discount.Dtos.Responses;

namespace MultiShop.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponResponse>> GetAllCouponsAsync();
        Task CreateCouponAsync(CreateCouponRequest request);
        Task UpdateCouponAsync(UpdateCouponRequest request);
        Task DeleteCouponAsync(string id);
        Task<GetByIdCouponResponse> GetByIdCouponAsync(string id);
    }
}
