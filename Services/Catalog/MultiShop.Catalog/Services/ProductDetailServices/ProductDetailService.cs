using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Product.Responses;
using MultiShop.Catalog.Dtos.ProductDetail.Requests;
using MultiShop.Catalog.Dtos.ProductDetail.Responses;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailRequest request)
        {
            var value = _mapper.Map<ProductDetail>(request);
            await _ProductDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _ProductDetailCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDetailResponse>> GetAllProductDetailAsync()
        {
            var values = await _ProductDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailResponse>>(values);
        }

        public async Task<GetByIdProductDetailResponse> GetByIdProductDetailAsync(string id)
        {
            var value = await _ProductDetailCollection.Find<ProductDetail>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailResponse>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailRequest request)
        {
            var value = _mapper.Map<ProductDetail>(request);
            await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.Id == request.Id, value);
        }
    }
}
