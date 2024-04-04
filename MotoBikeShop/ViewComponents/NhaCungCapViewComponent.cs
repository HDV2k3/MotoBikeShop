using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.ViewComponents
{
    public class NhaCungCapViewComponent : ViewComponent
    {
        private readonly motoBikeVHDbContext db;

        public NhaCungCapViewComponent(motoBikeVHDbContext context) => db = context;

        public IViewComponentResult Invoke()
        {
            var data = db.NhaCungCaps.Select(nhacungcap => new NhaCungCapVM
            {
                MaNCC = nhacungcap.MaNCC,
                TenCongTy = nhacungcap.TenCongTy
            }).OrderBy(p => p.TenCongTy);
            return View(data); //Default.cshtml
        }
    }
}
