using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface IRoleServices
    {
        public Task<List<Role>> GetAllAsync();
        public Task<Role> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Role obj);
        public Task<bool> UpdateAsync(Guid id, Role obj);
        public Task<bool> RemoveAsync(Guid id);
    }
}
