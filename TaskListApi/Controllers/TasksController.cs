using Microsoft.AspNetCore.Mvc;
using TaskListApi.Interface.ITaskRepository;
using TaskListApi.Models.TaskItem;


namespace TaskListApi.Controllers.TasksController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskItem>> Get()
        {
            return await _taskRepository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> Get(string id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Post([FromBody] TaskItem task)
        {
            await _taskRepository.CreateAsync(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] TaskItem task)
        {
            var existingTask = await _taskRepository.GetByIdAsync(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            task.Id = id;
            await _taskRepository.UpdateAsync(id, task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            await _taskRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}