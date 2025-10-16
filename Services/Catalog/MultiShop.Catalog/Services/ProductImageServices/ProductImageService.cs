using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImage.Requests;
using MultiShop.Catalog.Dtos.ProductImage.Responses;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductImageAsync(CreateProductImageRequest request)
        {
            var value = _mapper.Map<ProductImage>(request);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _ProductImageCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductImageResponse>> GetAllProductImageAsync()
        {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageResponse>>(values);
        }

        public async Task<GetByIdProductImageResponse> GetByIdProductImageAsync(string id)
        {
            var value = await _ProductImageCollection.Find<ProductImage>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageResponse>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageRequest request)
        {
            var value = _mapper.Map<ProductImage>(request);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.Id == request.Id, value);
        }
    }
}
