using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface ICategoryServices
    {
        public Task<List<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Category obj);
        public Task<bool> UpdateAsync(Guid id, Category obj);
        public Task<bool> RemoveAsync(Guid id);

    }
}
