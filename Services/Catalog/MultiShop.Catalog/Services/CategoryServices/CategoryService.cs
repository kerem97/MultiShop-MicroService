using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.Category.Requests;
using MultiShop.Catalog.Dtos.Category.Responses;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryRequest request)
        {
            var value = _mapper.Map<Category>(request);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultCategoryResponse>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryResponse>>(values);
        }

        public async Task<GetByIdCategoryResponse> GetByIdCategoryAsync(string id)
        {
            var value = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryResponse>(value);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            var value = _mapper.Map<Category>(request);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.Id == request.Id, value);

        }
    }
}
