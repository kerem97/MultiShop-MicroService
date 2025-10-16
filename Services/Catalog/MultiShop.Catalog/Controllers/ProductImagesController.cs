using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImage.Requests;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductImage(string id)
        {
            var value = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageRequest request)
        {
            await _productImageService.CreateProductImageAsync(request);
            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> DeteleProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageRequest request)
        {
            await _productImageService.UpdateProductImageAsync(request);
            return Ok();
        }
    }
}
