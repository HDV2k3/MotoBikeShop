using System.Collections;
using MotoBikeShop.Data;
using MotoBikeShop.Models;

namespace MotoBikeShop.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Loai>> GetAllAsync();
        Task<Loai> GetByIdAsync(int id);
        Task AddAsync(Loai category);
        Task UpdateAsync(Loai category);
        Task DeleteAsync(int id);
        Task<IEnumerable<Loai>> SearchAsync(string keyword);

    }
}
