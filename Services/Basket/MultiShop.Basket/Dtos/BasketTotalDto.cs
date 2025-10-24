namespace MultiShop.Basket.Dtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public decimal TotalPrice => BasketItems.Sum(x => x.Price * x.Quantity)
        * (DiscountRate.HasValue ? (100 - DiscountRate.Value) / 100m : 1m);
    }
}
