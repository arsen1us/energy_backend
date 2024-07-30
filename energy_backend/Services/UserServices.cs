using energy_backend;
using energy_backend.Services;

namespace energy_backend.Services
{
    public class UserServices : IUserService
    {
        EnergyContext _database;

        public UserServices(EnergyContext database)
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
            if (!UserExists(id))
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

        public bool UserExists(string id)
        {
            User user = _database.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
                return true;
            return false;
        }
    }
}
