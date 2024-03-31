using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;

namespace MotoBikeShop.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    [Route("admin")]
    [Route("Product")]
    public class ProductController : Controller
    {
       
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFactoryRepository _factoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IFactoryRepository factoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _factoryRepository = factoryRepository;
        }
        [Route("")]
        [Route("index")]
        public async Task<IActionResult> Index()
        {
            var product = await _productRepository.GetAllAsync();
            return View(product);
        }
        // Hiển thị form thêm sản phẩm mới
        
        [Route("Create")]
        // Hiển thị form thêm sản phẩm mới
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var loais = await _categoryRepository.GetAllAsync();
            if (loais == null)
            {
                loais = new List<Loai>(); // khởi tạo một danh sách rỗng nếu loais là null
            }
            ViewBag.Loais = new SelectList(loais, "MaLoai", "MaLoai");

            var nhaCungCaps = await _factoryRepository.GetAllAsync();
            if (nhaCungCaps == null)
            {
                nhaCungCaps = new List<NhaCungCap>(); // khởi tạo một danh sách rỗng nếu nhaCungCaps là null
            }
            ViewBag.NhaCungCaps = new SelectList(nhaCungCaps, "MaNCC", "MaNCC");

            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Create(HangHoa product, IFormFile imageUrl)
        {
            if (!ModelState.IsValid)
            {
                if (imageUrl != null)
                {
                    // Lưu hình ảnh đại diện tham khảo bài 02 hàm SaveImage
                    product.Hinh = await SaveImage(imageUrl);
                }
                await _productRepository.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        private async Task<string> SaveImage(IFormFile image)
        {
            var savePath = Path.Combine("wwwroot/images", image.FileName); //Thay đổi đường dẫn theo cấu hình của bạn

            using (var fileStream = new FileStream(savePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            return image.FileName; // Trả về đường dẫn tương đối
        }
    }
}
//hello