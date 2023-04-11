using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface ICartDetailsServices
    {
        public Task<List<CartDetails>> GetAllAsync();
        public Task<CartDetails> GetByIdAsync(Guid idProduct, Guid idUser);
        public Task<bool> AddAsync(CartDetails obj);
        public Task<bool> UpdateAsync(Guid idProduct, Guid idUser, CartDetails obj);
        public Task<bool> RemoveAsync(Guid idProduct, Guid idUser);
        public Task<List<CartDetails>> GetAllOfUserAsync(Guid idUser);
    }
}
