using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetail.Requests;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductDetail(string id)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailRequest request)
        {
            await _productDetailService.CreateProductDetailAsync(request);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeteleProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailRequest request)
        {
            await _productDetailService.UpdateProductDetailAsync(request);
            return Ok();
        }
    }
}
