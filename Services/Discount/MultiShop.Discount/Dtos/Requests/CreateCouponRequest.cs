namespace MultiShop.Discount.Dtos.Requests
{
    public class CreateCouponRequest
    {

        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
