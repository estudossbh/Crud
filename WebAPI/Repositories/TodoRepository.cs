using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebAPI.Configurations;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class TodoRepository
    {
        public TodoRepository(IOptions<DbSettings> dbSettings)
        {
            var database = new MongoClient().GetDatabase(dbSettings.Value.DataBaseName);
            _collection = database.GetCollection<Todo>("Todo");
        }

        protected IMongoCollection<Todo> _collection;

        public async Task<Todo> GetAsync(string id, CancellationToken cancellationToken)
        {
            return await _collection.Find(w => w.Id == id).SingleAsync(cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(w => w.Id == id, cancellationToken);
        }
    }
}
