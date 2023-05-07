using minimal_api.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace minimal_api.Services;

public class TodoService
{
    private readonly IMongoCollection<TodoItem> _todoCollection;

    public TodoService(IOptions<TodoDatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);

        _todoCollection = mongoDatabase.GetCollection<TodoItem>(
            databaseSettings.Value.TodoCollectionName
        );
    }

    public async Task<List<TodoItem>> GetAsync(bool isComplete) =>
        await _todoCollection.Find(x => x.IsComplete == isComplete).ToListAsync();

    public async Task<TodoItem?> GetAsync(string id) =>
        await _todoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(TodoItem newItem) =>
        await _todoCollection.InsertOneAsync(newItem);

    public async Task UpdateAsync(string name, TodoItem newItem)
    {
        var result = await _todoCollection.Find(x => x.Name == name).FirstOrDefaultAsync();
        if (result == null)
        {
            return;
        }
        newItem.Id = result.Id;
        await _todoCollection.ReplaceOneAsync(x => x.Name == name, newItem);
    }

    public async Task RemoveAsync(string name) =>
        await _todoCollection.DeleteOneAsync(x => x.Name == name);
}
