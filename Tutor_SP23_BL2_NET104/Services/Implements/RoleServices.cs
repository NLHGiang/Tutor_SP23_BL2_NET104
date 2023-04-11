using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.ArtShopDbContext;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.EntityFrameworkCore;

namespace Tutor_SP23_BL2_NET104.Services.Implements
{
    public class RoleServices : IRoleServices
    {
        private readonly ArtShopContext _dbContext;

        public RoleServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(Role obj)
        {
            try
            {
                await _dbContext.Roles.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Role>> GetAllAsync()
        {
            var list = await _dbContext.Roles.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<Role> GetByIdAsync(Guid id)
        {
            var list = await _dbContext.Roles.ToListAsync();
            var obj = list.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return new Role();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var listObj = await _dbContext.Roles.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;

                _dbContext.Roles.Attach(obj);
                await Task.FromResult<Role>(_dbContext.Roles.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Role obj)
        {
            try
            {
                var listObj = await _dbContext.Roles.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                objForUpdate.Name = obj.Name;
                objForUpdate.Status = obj.Status;

                _dbContext.Roles.Attach(obj);
                await Task.FromResult<Role>(_dbContext.Roles.Update(obj).Entity);
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
