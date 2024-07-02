using TaskListApi.Models.TaskItem;

namespace TaskListApi.Interface.ITaskRepository
{

    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(string id);
        Task CreateAsync(TaskItem task);
        Task UpdateAsync(string id, TaskItem task);
        Task DeleteAsync(string id);
    }
}