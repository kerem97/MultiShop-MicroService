using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var userId = _loginService.GetUserId;
            var dto = await _basketService.GetBasket(userId);

            if (dto is null)
                return Ok(new BasketView(userId, null, null, new List<BasketItemDto>(), 0m));

            var subTotal = dto.BasketItems.Sum(i => i.Price * i.Quantity);
            var total = dto.DiscountRate.HasValue
                ? subTotal * (100 - dto.DiscountRate.Value) / 100m
                : subTotal;

            var view = new BasketView(dto.UserId, dto.DiscountCode, dto.DiscountRate, dto.BasketItems, total);
            return Ok(view);
        }


        [HttpPost]
        public async Task<IActionResult> SaveBasketItems([FromBody] SaveBasketRequest req)
        {
            var userId = _loginService.GetUserId;

            if (req.BasketItems.Any(i => string.IsNullOrWhiteSpace(i.ProductId)))
                return BadRequest(new { message = "BasketItems.*.productId gerekli." });

            var dto = new BasketTotalDto
            {
                UserId = userId,
                DiscountCode = req.DiscountCode,
                DiscountRate = req.DiscountRate,
                BasketItems = req.BasketItems.Select(i => new BasketItemDto
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = i.ProductId,
                    Name = i.Name,
                    Price = i.Price,
                    Quantity = i.Quantity
                }).ToList()
            };

            await _basketService.SaveBasket(dto);   
            return NoContent();                     
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok();
        }
        public record BasketView(
    string UserId,
    string? DiscountCode,
    int? DiscountRate,
    List<BasketItemDto> BasketItems,
    decimal TotalPrice
);
    }
}
