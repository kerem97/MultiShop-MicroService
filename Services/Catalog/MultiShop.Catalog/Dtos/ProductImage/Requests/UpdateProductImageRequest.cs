﻿namespace MultiShop.Catalog.Dtos.ProductImage.Requests
{
    public class UpdateProductImageRequest
    {
        public string Id { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }
    }
}
