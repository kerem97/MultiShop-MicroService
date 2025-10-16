using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Category.Responses;
using MultiShop.Catalog.Dtos.Product.Requests;
using MultiShop.Catalog.Dtos.Product.Responses;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _ProductCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductRequest request)
        {
            var value = _mapper.Map<Product>(request);
            await _ProductCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _ProductCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductResponse>> GetAllProductAsync()
        {
            var values = await _ProductCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductResponse>>(values);
        }

        public async Task<GetByIdProductResponse> GetByIdProductAsync(string id)
        {
            var value = await _ProductCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductResponse>(value);
        }

        public async Task UpdateProductAsync(UpdateProductRequest request)
        {
            var value = _mapper.Map<Product>(request);
            await _ProductCollection.FindOneAndReplaceAsync(x => x.Id == request.Id, value);

        }
    }
}
