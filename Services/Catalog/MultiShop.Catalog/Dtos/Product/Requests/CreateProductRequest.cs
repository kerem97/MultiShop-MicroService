namespace MultiShop.Catalog.Dtos.Product.Requests
{
    public class CreateProductRequest
    {
      
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
