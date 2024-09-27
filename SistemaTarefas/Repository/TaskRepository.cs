using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repository.Interfaces;

namespace SistemaTarefas.Repository
{
    public class TaskRepository : ITaskRepository
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public TaskRepository(SistemaTarefasDBContext dbContext) 
        {
            _dbContext = dbContext; 
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
           return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)
        {
            TaskModel taskById = await GetTaskById(id) ?? throw new Exception($"Task ID not found: {id} not found in data base");
            taskById.Name = task.Name;
            taskById.Description = task.Description;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await GetTaskById(id) ?? throw new Exception($"Task ID not found: {id} not found in data base");
            _dbContext.Tasks.Remove(taskById);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
