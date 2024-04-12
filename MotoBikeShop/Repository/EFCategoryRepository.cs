using Microsoft.EntityFrameworkCore;
using System.Collections;
using MotoBikeShop.Data;
using MotoBikeShop.Models;

namespace MotoBikeShop.Repository
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly motoBikeVHDbContext _context;
        public EFCategoryRepository(motoBikeVHDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Loai>> GetAllAsync()
        {
            return await _context.Loais.Include(p => p.HangHoas).ToListAsync();
        }
        public async Task<Loai> GetByIdAsync(int id)
        {
            return await _context.Loais.FindAsync(id);
        }
        public async Task AddAsync(Loai category)
        {
            _context.Loais.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Loai category)
        {
            _context.Loais.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Loais.FindAsync(id);
            _context.Loais.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Loai>> SearchAsync(string keyword)
        {
            return await _context.Loais
              .Include(p => p.MaLoai)
              .Where(t => t.TenLoai.Contains(keyword) || t.MoTa.Contains(keyword))
              .ToListAsync();
        }

    }
}
