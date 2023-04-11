using Tutor_SP23_BL2_NET104.Services.Interfaces;
using Tutor_SP23_BL2_NET104.ArtShopDbContext;
using Tutor_SP23_BL2_NET104.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Tutor_SP23_BL2_NET104.Services.Implements
{
    public class CartDetailsServices : ICartDetailsServices
    {
        private readonly ArtShopContext _dbContext;

        public CartDetailsServices()
        {
            this._dbContext = new ArtShopContext();
        }

        public async Task<bool> AddAsync(CartDetails obj)
        {
            try
            {
                obj.CreatedTime = DateTime.Now;

                await _dbContext.CartDetailses.AddAsync(obj);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<CartDetails>> GetAllAsync()
        {
            var list = await _dbContext.CartDetailses.ToListAsync();
            if (list == null)
            {
                return new();
            }
            return list;
        }

        public async Task<List<CartDetails>> GetAllOfUserAsync(Guid idUser)
        {
            var list = await _dbContext.CartDetailses.ToListAsync();
            if (list == null)
            {
                return new();
            }

            list = list.Where(c => c.IdUser == idUser && c.Status == 0).ToList();
            return list;
        }

        public async Task<CartDetails> GetByIdAsync(Guid idProduct, Guid idUser)
        {
            var list = await _dbContext.CartDetailses.ToListAsync();
            var obj = list.FirstOrDefault(c => c.IdUser == idUser && c.IdProduct == idProduct);
            if (obj == null)
            {
                return new CartDetails();
            }
            return obj;
        }

        public async Task<bool> RemoveAsync(Guid idProduct, Guid idUser)
        {
            try
            {
                var list = await _dbContext.CartDetailses.ToListAsync();
                var obj = list.FirstOrDefault(c => c.IdUser == idUser && c.IdProduct == idProduct);
                obj.Status = 1;

                _dbContext.CartDetailses.Attach(obj);
                await Task.FromResult<CartDetails>(_dbContext.CartDetailses.Update(obj).Entity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Guid idProduct, Guid idUser, CartDetails obj)
        {
            try
            {
                var listObj = await _dbContext.CartDetailses.ToListAsync();
                var objForUpdate = listObj.FirstOrDefault(c => c.IdUser == idUser && c.IdProduct == idProduct);

                objForUpdate.Amount = obj.Amount;
                objForUpdate.Status = obj.Status;

                _dbContext.CartDetailses.Update(objForUpdate);
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
