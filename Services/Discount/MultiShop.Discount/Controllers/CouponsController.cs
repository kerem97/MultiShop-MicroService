using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos.Requests;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _couponService.GetAllCouponsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCoupon(string id)
        {
            var value = await _couponService.GetByIdCouponAsync(id);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(string id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok();
        }
        [HttpPost]

        public async Task<IActionResult> CreateDiscountCoupon(CreateCouponRequest request)
        {
            await _couponService.CreateCouponAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCouponRequest request)
        {
            await _couponService.UpdateCouponAsync(request);
            return Ok();
        }
    }
}
