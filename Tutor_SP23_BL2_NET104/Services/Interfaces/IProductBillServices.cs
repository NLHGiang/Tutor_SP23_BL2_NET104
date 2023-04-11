using Tutor_SP23_BL2_NET104.Models;

namespace Tutor_SP23_BL2_NET104.Services.Interfaces
{
    public interface IProductBillServices
    {
        public Task<List<ProductBill>> GetAllAsync();
        public Task<ProductBill> GetByIdAsync(Guid idBill, Guid idProduct);
        public Task<bool> AddAsync(ProductBill obj);
        public Task<bool> UpdateAsync(Guid idBill, Guid idProductProduct, ProductBill obj);
        public Task<bool> RemoveAsync(Guid idBill, Guid idProduct);

    }
}
