using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskListApi.Data.MongoDBSettings;
using TaskListApi.Interface.ITaskRepository;
using TaskListApi.Models.TaskItem;

public class TaskRepository : ITaskRepository
{
    private readonly IMongoCollection<TaskItem> _taskCollection;

    public TaskRepository(IOptions<MongoDBSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _taskCollection = database.GetCollection<TaskItem>("Tasks");
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _taskCollection.Find(task => true).ToListAsync();
    }

    public async Task<TaskItem> GetByIdAsync(string id)
    {
        return await _taskCollection.Find(task => task.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(TaskItem task)
    {
        await _taskCollection.InsertOneAsync(task);
    }

    public async Task UpdateAsync(string id, TaskItem task)
    {
        await _taskCollection.ReplaceOneAsync(t => t.Id == id, task);
    }

    public async Task DeleteAsync(string id)
    {
        await _taskCollection.DeleteOneAsync(task => task.Id == id);
    }
}
