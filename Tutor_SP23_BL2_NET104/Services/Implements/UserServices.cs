using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.ArtShopDbContext;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Tutor_SP23_BL2_NET104.Services.Implements
{
    public class UserServices : IUserServices
    {
        private readonly ArtShopContext _dbContext;

        public UserServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(User obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.Users.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllAsync()
        {
            var list = await _dbContext.Users.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var list = await _dbContext.Users.ToListAsync();
            var obj = list.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return new User();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var listObj =  await _dbContext.Users.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;

                _dbContext.Users.Attach(obj);
                await Task.FromResult<User>(_dbContext.Users.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, User obj)
        {
            try
            {
                var listObj = await _dbContext.Users.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                objForUpdate.FullName = obj.FullName;
                objForUpdate.Email = obj.Email;
                objForUpdate.Username = obj.Username;
                objForUpdate.Password = obj.Password;
                objForUpdate.Status = obj.Status;

                _dbContext.Users.Attach(obj);
                await Task.FromResult<User>(_dbContext.Users.Update(obj).Entity);
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
