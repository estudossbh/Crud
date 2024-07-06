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

        public async Task<List<Todo>> GetAsync(CancellationToken cancellationToken)
        {
            return await _collection.Find(w => true).ToListAsync(cancellationToken);
        }

        public async Task<Todo> GetAsync(string id, CancellationToken cancellationToken)
        {
            return await _collection.Find(w => w.Id == id).SingleAsync(cancellationToken);
        }

        public async Task<List<Todo>> GetAsync(List<string> ids, CancellationToken cancellationToken)
        {
            return await _collection.Find(w => ids.Contains(w.Id)).ToListAsync(cancellationToken);
        }

        public async Task InsertAsync(Todo todo, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(todo, null, cancellationToken);
        }

        public async Task UpdateAsync(Todo todo, CancellationToken cancellationToken)
        {
            await _collection.ReplaceOneAsync(w => w.Id == todo.Id, todo, cancellationToken: cancellationToken);
        }

        public async Task UpdateAsync(List<Todo> todos, CancellationToken cancellationToken)
        {
            foreach (var todo in todos)
                await _collection.ReplaceOneAsync(w => w.Id == todo.Id, todo, cancellationToken: cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(w => w.Id == id, cancellationToken);
        }
    }
}
