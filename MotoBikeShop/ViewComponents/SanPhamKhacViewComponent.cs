using Microsoft.AspNetCore.Mvc;
using MotoBikeShop.Data;

namespace MotoBikeShop.ViewComponents
{
	public class SanPhamKhacViewComponent : ViewComponent
	{
		private readonly motoBikeVHDbContext db;

		public SanPhamKhacViewComponent(motoBikeVHDbContext context) => db = context;

		public IViewComponentResult Invoke()
		{
			// Lấy danh sách tất cả sản phẩm
			var products = GetProducts();

			// Trả về view và truyền danh sách sản phẩm
			return View(products);
		}

		public List<HangHoa> GetProducts()
		{
			return db.HangHoas.OrderBy(p=>p.TenHH).ToList();
		}
	}
}
