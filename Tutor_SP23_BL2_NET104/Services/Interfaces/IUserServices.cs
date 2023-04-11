using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface IUserServices
    {
        public Task<List<User>> GetAllAsync();
        public Task<User> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(User obj);
        public Task<bool> UpdateAsync(Guid id, User obj);
        public Task<bool> RemoveAsync(Guid id);
    }
}
