using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.ArtShopDbContext;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.EntityFrameworkCore;

namespace Tutor_SP23_BL2_NET104.Services.Implements
{
    public class ProductBillServices : IProductBillServices
    {
        private readonly ArtShopContext _dbContext;

        public ProductBillServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(ProductBill obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.ProductBills.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<ProductBill>> GetAllAsync()
        {
            var list = await _dbContext.ProductBills.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<ProductBill> GetByIdAsync(Guid idBill, Guid idProduct)
        {
            var list = await _dbContext.ProductBills.ToListAsync();
            var obj = list.FirstOrDefault(c => c.IdBill == idBill && c.IdProduct == idProduct);
            if (obj == null)
            {
                return new ProductBill();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid idBill, Guid idProduct)
        {
            try
            {
                var listObj = await _dbContext.ProductBills.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.IdBill == idBill && c.IdProduct == idProduct);
                obj.Status = 1;

                _dbContext.ProductBills.Attach(obj);
                await Task.FromResult<ProductBill>(_dbContext.ProductBills.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid idBill, Guid idProduct, ProductBill obj)
        {
            try
            {
                var listObj = await _dbContext.ProductBills.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.IdBill == idBill && c.IdProduct == idProduct);

                objForUpdate.Amount = obj.Amount;
                objForUpdate.Status = obj.Status;

                _dbContext.ProductBills.Attach(obj);
                await Task.FromResult<ProductBill>(_dbContext.ProductBills.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
