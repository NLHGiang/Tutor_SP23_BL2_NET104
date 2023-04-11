using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface IBillServices
    {
        public Task<List<Bill>> GetAllAsync();
        public Task<Bill> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Bill obj);
        public Task<bool> UpdateAsync(Guid id, Bill obj);
        public Task<bool> RemoveAsync(Guid id);

        public Task<List<Bill>> GetAllOfUserAsync(Guid idUser);
    }
}
