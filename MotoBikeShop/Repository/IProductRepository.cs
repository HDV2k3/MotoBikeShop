using MotoBikeShop.Models;
using MotoBikeShop.ViewModels;
using MotoBikeShop.Data;
using Microsoft.EntityFrameworkCore;

namespace MotoBikeShop.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<HangHoa>> GetAllAsync();
        Task<HangHoa> GetByIdAsync(int id);
        Task AddAsync(HangHoa product);
        Task UpdateAsync(HangHoa product);
        Task DeleteAsync(int id);
        Task<IEnumerable<HangHoa>> SearchAsync(string keyword);
        List<HangHoa> GetProductsSorted(bool ascending);
    }
}

