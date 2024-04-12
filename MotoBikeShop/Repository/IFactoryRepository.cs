using MotoBikeShop.Data;

namespace MotoBikeShop.Repository
{
    public interface IFactoryRepository
    {
        Task<IEnumerable<NhaCungCap>> GetAllAsync();
        Task<NhaCungCap> GetByIdAsync(string id);
        Task AddAsync(NhaCungCap product);
        Task UpdateAsync(NhaCungCap product);
        Task DeleteAsync(string id);
        Task<IEnumerable<NhaCungCap>> SearchAsync(string keyword);

    }
}
