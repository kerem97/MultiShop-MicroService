using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;
        private readonly JsonSerializerOptions _json = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        private static string Key(string userId) => $"basket:{userId}";

        public BasketService(RedisService redisService) => _redisService = redisService;

        public async Task DeleteBasket(string userId)
            => await _redisService.GetDb().KeyDeleteAsync(Key(userId));

        public async Task<BasketTotalDto?> GetBasket(string userId)
        {
            var raw = await _redisService.GetDb().StringGetAsync(Key(userId));
            if (!raw.HasValue) return null;
            return JsonSerializer.Deserialize<BasketTotalDto>(raw!, _json);
        }

        public async Task SaveBasket(BasketTotalDto incoming)
        {
            var db = _redisService.GetDb();
            var key = Key(incoming.UserId);

            // 1) Mevcut sepeti oku
            BasketTotalDto current = null;
            var existed = await db.StringGetAsync(key);
            if (existed.HasValue)
                current = JsonSerializer.Deserialize<BasketTotalDto>(existed!, _json);

            current ??= new BasketTotalDto
            {
                UserId = incoming.UserId,
                DiscountCode = incoming.DiscountCode,
                DiscountRate = incoming.DiscountRate,
                BasketItems = new List<BasketItemDto>()
            };

            // 2) İndirim kodu/rate güncelle (gönderdiyse)
            if (!string.IsNullOrWhiteSpace(incoming.DiscountCode))
                current.DiscountCode = incoming.DiscountCode;
            if (incoming.DiscountRate.HasValue)
                current.DiscountRate = incoming.DiscountRate;

            // 3) Ürünleri ProductId bazlı upsert/merge et
            foreach (var item in incoming.BasketItems ?? Enumerable.Empty<BasketItemDto>())
            {
                if (string.IsNullOrWhiteSpace(item.ProductId))
                    continue; // veya throw

                var ex = current.BasketItems.FirstOrDefault(x => x.ProductId == item.ProductId);
                if (ex is null)
                {
                    current.BasketItems.Add(new BasketItemDto
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = item.ProductId,
                        Name = item.Name,
                        Price = item.Price,
                        Quantity = item.Quantity
                    });
                }
                else
                {
                    ex.Quantity += item.Quantity;               // aynı üründen ekleme
                    ex.Price = item.Price;                      // stratejine göre koru/güncelle
                    ex.Name = item.Name ?? ex.Name;
                }
            }

            // 4) Geri yaz
            await db.StringSetAsync(key, JsonSerializer.Serialize(current, _json));
        }
    }

}
