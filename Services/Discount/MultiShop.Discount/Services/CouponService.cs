using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos.Requests;
using MultiShop.Discount.Dtos.Responses;

namespace MultiShop.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly DapperContext _context;

        public CouponService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponRequest request)
        {
            string query = @"INSERT INTO Coupons (Id, Code, Rate, IsActive, ValidDate)
                     VALUES (@id, @code, @rate, @isActive, @validDate)";

            var parameters = new DynamicParameters();

            var id = Guid.NewGuid();             
            parameters.Add("@id", id.ToString());            

            parameters.Add("@code", request.Code);
            parameters.Add("@rate", request.Rate);
            parameters.Add("@isActive", request.IsActive);
            parameters.Add("@validDate", request.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task DeleteCouponAsync(string id)
        {
            string query = "DELETE FROM Coupons WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }


        public async Task<List<ResultCouponResponse>> GetAllCouponsAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponResponse>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCouponResponse> GetByIdCouponAsync(string id)
        {
            string query = "SELECT * FROM Coupons WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIdCouponResponse>(query, parameters);
                return value;
            }
        }


        public async Task UpdateCouponAsync(UpdateCouponRequest request)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate Where Id=@Id";
            var parameters = new DynamicParameters();
            parameters.Add("@code", request.Code);
            parameters.Add("@rate", request.Rate);
            parameters.Add("@isActive", request.IsActive);
            parameters.Add("@validDate", request.ValidDate);
            parameters.Add("@Id", request.Id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
