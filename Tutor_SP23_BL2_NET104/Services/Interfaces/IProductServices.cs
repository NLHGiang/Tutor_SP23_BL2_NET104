using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface IProductServices
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Product obj);
        public Task<bool> UpdateAsync(Guid id, Product obj);
        public Task<bool> RemoveAsync(Guid id);

    }
}
