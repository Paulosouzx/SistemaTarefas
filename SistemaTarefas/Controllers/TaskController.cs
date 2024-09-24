using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaTarefas.Models;
using SistemaTarefas.Repository;
using SistemaTarefas.Repository.Interfaces;
using System.Threading.Tasks;

namespace SistemaTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> ListAllTasks()
        {
            List<TaskModel> task = await _taskRepository.GetAllTasks();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> GetById(int id)
        {
            TaskModel task = await _taskRepository.GetTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Register([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.AddTask(taskModel);

            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult<TaskModel>> Refresh([FromBody] TaskModel taskModel, int id)
        {

            taskModel.ID = id;
            TaskModel task = await _taskRepository.UpdateTask(taskModel, id);
            return Ok(task);
        }

        [HttpDelete]
        public async Task<ActionResult<TaskModel>> Refresh(int id)
        {
            bool deleted = await _taskRepository.DeleteTask(id);
            return Ok(deleted);
        }
    }
}
