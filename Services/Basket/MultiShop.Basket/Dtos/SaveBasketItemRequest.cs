namespace MultiShop.Basket.Dtos
{
    public class SaveBasketItemRequest
    {
        public string ProductId { get; set; }  
        public string Name { get; set; }        
        public decimal Price { get; set; }     
        public int Quantity { get; set; }
    }
}
