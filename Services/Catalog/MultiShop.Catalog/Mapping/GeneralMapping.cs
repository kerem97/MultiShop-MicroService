using AutoMapper;
using MultiShop.Catalog.Dtos.Category.Requests;
using MultiShop.Catalog.Dtos.Category.Responses;
using MultiShop.Catalog.Dtos.Product.Requests;
using MultiShop.Catalog.Dtos.Product.Responses;
using MultiShop.Catalog.Dtos.ProductDetail.Requests;
using MultiShop.Catalog.Dtos.ProductDetail.Responses;
using MultiShop.Catalog.Dtos.ProductImage.Requests;
using MultiShop.Catalog.Dtos.ProductImage.Responses;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryResponse>().ReverseMap();
            CreateMap<Category, GetByIdCategoryResponse>().ReverseMap();
            CreateMap<Category, UpdateCategoryRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();

            CreateMap<Product, ResultProductResponse>().ReverseMap();
            CreateMap<Product, GetByIdProductResponse>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
            CreateMap<Product, CreateProductRequest>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailResponse>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailResponse>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailRequest>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailRequest>().ReverseMap();

            CreateMap<ProductImage, CreateProductImageRequest>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageRequest>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageResponse>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageResponse>().ReverseMap();


        }
    }
}
