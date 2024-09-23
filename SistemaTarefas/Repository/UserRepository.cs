using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repository.Interfaces;

namespace SistemaTarefas.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly SistemaTarefasDBContext _dbContext;

        public UserRepository(SistemaTarefasDBContext dbContext) 
        {
            _dbContext = dbContext; 
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
           return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, int id)
        {
            UserModel userById = await GetUserById(id) ?? throw new Exception($"User ID not found: {id} not found in data base");
            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;

        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User ID not found: {id} not found in data base");
            }

            _dbContext.Users.Remove(userById);
            _dbContext.SaveChanges();
            return true;

        }

        public Task<UserModel> UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
