using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.ArtShopDbContext;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.EntityFrameworkCore;

namespace Tutor_SP23_BL2_NET104.Services.Implements
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ArtShopContext _dbContext;

        public CategoryServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(Category obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.Categories.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var list = await _dbContext.Categories.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            var list = await _dbContext.Categories.ToListAsync();
            var obj = list.FirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var listObj = await _dbContext.Categories.ToListAsync();
                var obj = listObj.FirstOrDefault(c => c.Id == id);
                obj.Status = 1;

                _dbContext.Categories.Attach(obj);
                await Task.FromResult<Category>(_dbContext.Categories.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid id, Category obj)
        {
            try
            {
                var listObj = await _dbContext.Categories.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.Id == id);

                objForUpdate.Name = obj.Name;

                objForUpdate.Status = obj.Status;

                _dbContext.Categories.Attach(obj);
                await Task.FromResult<Category>(_dbContext.Categories.Update(obj).Entity);
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
