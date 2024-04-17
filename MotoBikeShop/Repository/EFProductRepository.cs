using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;
using MotoBikeShop.Models;

namespace MotoBikeShop.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private readonly motoBikeVHDbContext _context;
        public EFProductRepository(motoBikeVHDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<HangHoa>> GetAllAsync()
        {
            return await _context.HangHoas.Include(p => p.MaLoaiNavigation).ToListAsync();
        }
        public async Task<HangHoa> GetByIdAsync(int id)
        {
            return await _context.HangHoas.Include(p => p.MaLoaiNavigation).FirstOrDefaultAsync(p => p.MaHH == id);
        }
        public async Task AddAsync(HangHoa product)
        {
            _context.HangHoas.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(HangHoa product)
        {
            _context.HangHoas.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var product = await _context.HangHoas.FindAsync(id);
            _context.HangHoas.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HangHoa>> SearchAsync(string keyword)
        {
            return await _context.HangHoas
               .Include(p => p.MaLoaiNavigation)
               .Where(t => t.TenHH.Contains(keyword) || t.MoTa.Contains(keyword))
               .ToListAsync();
        }
        public  List<HangHoa> GetProductsSorted(bool ascending)
        {
            if (ascending)
            {
                return _context.HangHoas.OrderBy(p => p.TenHH).ToList();
            }
            else
            {
                return _context.HangHoas.OrderByDescending(p => p.TenHH).ToList();
            }
        }
    }
}
