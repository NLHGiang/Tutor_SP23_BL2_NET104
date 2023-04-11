using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.ArtShopDbContext;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.EntityFrameworkCore;

namespace Tutor_SP23_BL2_NET104.Services.Implements
{
    public class BillServices : IBillServices
    {
        private readonly ArtShopContext _dbContext;

        public BillServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(Bill obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.Bills.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Bill>> GetAllAsync()
        {
            var list = await _dbContext.Bills.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<List<Bill>> GetAllOfUserAsync(Guid idUser)
        {
            var list = await _dbContext.Bills.ToListAsync();
            if (list == null)
            {
                return new();
            }

            list = list.Where(c => c.IdUser == idUser && c.Status != 1).ToList();
            return list;
        }

        public async Task<Bill> GetByIdAsync(Guid id)
        {
            var list = await _dbContext.Bills.ToListAsync();
            var obj = list.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return new Bill();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var listObj = await _dbContext.Bills.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;

                _dbContext.Bills.Attach(obj);
                await Task.FromResult<Bill>(_dbContext.Bills.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Bill obj)
        {
            try
            {
                var listObj = await _dbContext.Bills.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                objForUpdate.Status = obj.Status;

                _dbContext.Bills.Attach(obj);
                await Task.FromResult<Bill>(_dbContext.Bills.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
