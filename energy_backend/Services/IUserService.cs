using Microsoft.AspNetCore.Mvc;

namespace energy_backend.Services
{
    public interface IUserService
    {
        // Add user
        public Task AddUser(User user);

        // Get user by id
        public Task<User> GetByIdAsync(string id);

        // Full update user by id
        public Task PutByIdAsync(string id);

        // Partial update user by id 
        public Task PatchByIdAsync(string id);

        // Delete user by id
        public Task DeleteByIdAsync(string id);
        
        // User exists???
        public Boolean UserExists(string id);
    }
}
