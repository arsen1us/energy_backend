using energy_backend;
using energy_backend.Models;
using energy_backend.Services;
using Microsoft.EntityFrameworkCore;

namespace energy_backend.Services
{
    public class UserService : IUserService
    {
        EnergyContext _database;

        public UserService(EnergyContext database)
        {
            _database = database;
        }
        public async Task AddUser(User user)
        {
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            if (!await UserExists(id))
                throw new Exception("User is not exists");
            User user = await _database.Users.FindAsync(id);
            _database.Users.Remove(user);
            await _database.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _database.Users.FindAsync(id);
        }

        public Task PatchByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task PutByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(string id)
        {
            if(await _database.Users.AnyAsync(u => u.Id == id))
                return true;
            return false;
        }

        public async Task<bool> UserExists(string userName, string password)
        {
            if(await _database.Users.AnyAsync(u => u.Login == userName && u.Password == password))
                return true;
            return false;
        }
    }
}
