namespace MultiShop.Basket.Dtos
{
    public class SaveBasketRequest
    {
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<SaveBasketItemRequest> BasketItems { get; set; } = new();
    }
}
