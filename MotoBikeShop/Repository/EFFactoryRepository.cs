using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;

namespace MotoBikeShop.Repository
{
    public class EFFactoryRepository : IFactoryRepository
    {
        private readonly motoBikeVHDbContext _context;
        public EFFactoryRepository(motoBikeVHDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(NhaCungCap nhaCungCap)
        {
            _context.NhaCungCaps.Add(nhaCungCap);
           await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string id)
        {
            var nhacungcap = await _context.NhaCungCaps.FindAsync(id);
            _context.NhaCungCaps.Remove(nhacungcap);
            await _context.SaveChangesAsync();
          
        }
        //public async Task<IEnumerable<NhaCungCap>> GetAllAsync()
        //{
        //    return await _context.NhaCungCaps.ToListAsync();
        //}
        public async Task<IEnumerable<NhaCungCap>> GetAllAsync()
        {
            try
            {
                // Make sure to check for null and return an empty list instead
                var result = await _context.NhaCungCaps.ToListAsync();
                return result ?? new List<NhaCungCap>();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error in FactoryRepository.GetAllAsync: {ex.Message}");
                // Return an empty list instead of null
                return new List<NhaCungCap>();
            }
        }

        public async Task<NhaCungCap> GetByIdAsync(string id)
        {
            return await _context.NhaCungCaps.Include(p => p.MaNCC).FirstOrDefaultAsync(p=>p.MaNCC==id );    
        }

        public async Task<IEnumerable<NhaCungCap>> SearchAsync(string keyword)
        {
            return await _context.NhaCungCaps
              .Include(p => p.MaNCC)
              .Where(t => t.TenCongTy.Contains(keyword) || t.MoTa.Contains(keyword))
              .ToListAsync();
        }

        public async Task UpdateAsync(NhaCungCap nhaCungCap)
        {
            _context.NhaCungCaps.Update(nhaCungCap);
            await _context.SaveChangesAsync();
        }
    }
}
