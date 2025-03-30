using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;
using MotoBikeShop.Helpers;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;

namespace MotoBikeShop.Areas.Admin
{
    [Area("admin")]

    [Authorize(Roles = SD.Role_Admin)]
  

    public class ProductController : Controller
    {
        private readonly motoBikeVHDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFactoryRepository _factoryRepository;

        public ProductController(motoBikeVHDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IFactoryRepository factoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _factoryRepository = factoryRepository;
            _context = context;

        }
      
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 6; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = page ?? 1; // Trang hiện tại
            var product = await _productRepository.GetAllAsync();
            var pagedHanghoas = product.Select(p => new HangHoaVM
            {
                MaHh = p.MaHH,
                TenHh = p.TenHH,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            })
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize)
            .ToList();

            int totalItems = product.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedHanghoas);
        }


        // Hiển thị form thêm sản phẩm mới
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await LoadDropdownData();
            return View();
        }
        // Xử lý thêm sản phẩm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HangHoa product, IFormFile imageUrl)
        {
            ModelState.Remove("MaLoaiNavigation");
            ModelState.Remove("MaNccNavigation");
            ModelState.Remove("MaTSKTNavigation");
            ModelState.Remove("Hinh");
            if (ModelState.IsValid)
            {
                try
                {
                    // Handle image upload
                    if (imageUrl != null && imageUrl.Length > 0)
                    {
                        // Lưu hình ảnh đại diện 
                        product.Hinh = await SaveImage(imageUrl);
                    }
                    else
                    {
                        // Provide a default image if none is uploaded
                        product.Hinh = "default-product.jpg";
                    }

                    // Set default values for any null properties
                    product.SoLanXem = product.SoLanXem <= 0 ? 0 : product.SoLanXem;
                    product.GiamGia = product.GiamGia < 0 ? 0 : product.GiamGia;

                    // Ensure ThongSoKyThuat exists
                    var thongSoKyThuat = await _context.thongSoKyThuats.FindAsync(product.MaTSKT);
                    if (thongSoKyThuat == null)
                    {
                        ModelState.AddModelError("MaTSKT", "Thông số kỹ thuật không tồn tại.");
                        await LoadDropdownData(product.MaLoai, product.MaNCC, product.MaTSKT);
                        return View(product);
                    }

                    // Check if Loai exists
                    var loai = await _context.Loais.FindAsync(product.MaLoai);
                    if (loai == null)
                    {
                        ModelState.AddModelError("MaLoai", "Loại sản phẩm không tồn tại.");
                        await LoadDropdownData(product.MaLoai, product.MaNCC, product.MaTSKT);
                        return View(product);
                    }

                    // Check if NhaCungCap exists
                    var nhaCungCap = await _context.NhaCungCaps.FindAsync(product.MaNCC);
                    if (nhaCungCap == null)
                    {
                        ModelState.AddModelError("MaNCC", "Nhà cung cấp không tồn tại.");
                        await LoadDropdownData(product.MaLoai, product.MaNCC, product.MaTSKT);
                        return View(product);
                    }

                    await _productRepository.AddAsync(product);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the detailed exception
                    Console.WriteLine(ex.ToString());

                    // Add a more specific error message based on the exception
                    if (ex.InnerException != null && ex.InnerException.Message.Contains("FK_HangHoas_thongSoKyThuats_MaTSKT"))
                    {
                        ModelState.AddModelError("MaTSKT", "Thông số kỹ thuật đã chọn không tồn tại trong hệ thống.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi lưu sản phẩm. Vui lòng thử lại.");
                    }
                }
            }

            // Nếu chúng ta đến đây, có lỗi xảy ra hoặc ModelState không hợp lệ
            await LoadDropdownData(product.MaLoai, product.MaNCC, product.MaTSKT);
            return View(product);
        }
        private async Task LoadDropdownData(int? selectedLoai = null, string selectedNCC = null, int? selectedTSKT = null)
        {
            try
            {
                // Get categories
                var loais = await _categoryRepository.GetAllAsync();

                // Get suppliers
                var nhaCungCaps = await _factoryRepository.GetAllAsync();

                // Get specifications
                var thongSoKyThuats = await _context.thongSoKyThuats.ToListAsync();

                // Check if thongSoKyThuats has any items and log properties for debugging
                if (thongSoKyThuats != null && thongSoKyThuats.Any())
                {
                    var firstItem = thongSoKyThuats.First();
                    Console.WriteLine($"First ThongSoKyThuat: MaTSKT={firstItem.MaTSKT}");

                    // Try to find a reasonable display property (try common property names)
                    var displayProp = "TenTSKT"; // Thử với tên TenTSKT
                    var propInfo = firstItem.GetType().GetProperty(displayProp);

                    if (propInfo == null)
                    {
                        // Log all properties to help identify the correct display property
                        var allProps = firstItem.GetType().GetProperties();
                        Console.WriteLine("All properties of ThongSoKyThuat:");
                        foreach (var prop in allProps)
                        {
                            Console.WriteLine($"- {prop.Name}: {prop.GetValue(firstItem)}");
                        }

                        // Try some common property names that might contain a name
                        var possibleNameProps = allProps.Where(p =>
                            p.Name.Contains("Ten") ||
                            p.Name.Contains("Name") ||
                            p.Name.Contains("Title") ||
                            p.Name.Contains("Loai")).ToList();

                        if (possibleNameProps.Any())
                        {
                            // Use the first one that looks like a name property
                            displayProp = possibleNameProps.First().Name;
                            Console.WriteLine($"Using {displayProp} as display property");
                        }
                        else
                        {
                            // Fallback to using ID and creating a display name
                            Console.WriteLine("No suitable display property found, using MaTSKT with prefix");
                            ViewBag.ThongSoKyThuats = new SelectList(thongSoKyThuats.Select(t => new
                            {
                                MaTSKT = t.MaTSKT,
                                DisplayName = $"Thông số kỹ thuật {t.MaTSKT}"
                            }), "MaTSKT", "DisplayName", selectedTSKT);

                            // Skip the rest of the method for ThongSoKyThuats
                            goto SkipThongSoKyThuats;
                        }
                    }

                    // If we have a valid display property, create the SelectList normally
                    ViewBag.ThongSoKyThuats = new SelectList(thongSoKyThuats, "MaTSKT", displayProp, selectedTSKT);
                }
                else
                {
                    // Empty list with placeholder
                    ViewBag.ThongSoKyThuats = new SelectList(
                        new List<SelectListItem> { new SelectListItem { Text = "-- Không có dữ liệu --", Value = "" } },
                        "Value", "Text");
                }

            SkipThongSoKyThuats:

                // Set up Loais dropdown
                ViewBag.Loais = loais != null && loais.Any()
                    ? new SelectList(loais, "MaLoai", "TenLoai", selectedLoai)
                    : new SelectList(
                        new List<SelectListItem> { new SelectListItem { Text = "-- Không có dữ liệu --", Value = "" } },
                        "Value", "Text");

                // Set up NhaCungCaps dropdown
                ViewBag.NhaCungCaps = nhaCungCaps != null && nhaCungCaps.Any()
                    ? new SelectList(nhaCungCaps, "MaNCC", "TenCongTy", selectedNCC)
                    : new SelectList(
                        new List<SelectListItem> { new SelectListItem { Text = "-- Không có dữ liệu --", Value = "" } },
                        "Value", "Text");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading dropdown data: {ex.Message}");

                // Create empty lists with placeholders as fallback
                ViewBag.Loais = new SelectList(
                    new List<SelectListItem> { new SelectListItem { Text = "-- Lỗi tải dữ liệu --", Value = "" } },
                    "Value", "Text");
                ViewBag.NhaCungCaps = new SelectList(
                    new List<SelectListItem> { new SelectListItem { Text = "-- Lỗi tải dữ liệu --", Value = "" } },
                    "Value", "Text");
                ViewBag.ThongSoKyThuats = new SelectList(
                    new List<SelectListItem> { new SelectListItem { Text = "-- Lỗi tải dữ liệu --", Value = "" } },
                    "Value", "Text");
            }
        }
        private async Task<string> SaveImage(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return "default-product.jpg";
            }

            // Ensure the directory exists
            var uploadDir = Path.Combine("wwwroot", "images");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Generate a unique filename to avoid collisions
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            var savePath = Path.Combine(uploadDir, fileName);

            try
            {
                using (var fileStream = new FileStream(savePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
                return fileName; // Return just the filename
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving image: {ex.Message}");
                return "default-product.jpg";
            }
        }

        [HttpGet]
      
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
      
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var loais = await _categoryRepository.GetAllAsync();
            ViewBag.Loais = new SelectList(loais, "MaLoai", "TenLoai", product.MaLoai);
            var nhacungcaps = await _factoryRepository.GetAllAsync();
            ViewBag.NhaCungCaps = new SelectList(nhacungcaps, "MaNCC", "MaNCC", product.MaNCC);

            return View(product);
        }

        // Xử lý cập nhật sản phẩm
        [HttpPost]
       
        public async Task<IActionResult> Edit(int id, HangHoa product, IFormFile imageUrl)
        {
            ModelState.Remove("Hinh"); // Loại bỏ xác thực ModelState cho ImageUrl
            if (id != product.MaHH)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var existingProduct = await _productRepository.GetByIdAsync(id); // Giả định có phương thức GetByIdAsync
                                                                                 // Giữ nguyên thông tin hình ảnh nếu không có hình mới được tải lên
                if (imageUrl == null)
                {
                    product.Hinh = existingProduct.Hinh;
                }
                else
                {
                    // Lưu hình ảnh mới
                    product.Hinh = await SaveImage(imageUrl);
                }
                // Cập nhật các thông tin khác của sản phẩm
                existingProduct.TenHH = product.TenHH;
                existingProduct.TenAlias = product.TenAlias;
                existingProduct.MoTaDonVi = product.MoTaDonVi;
                existingProduct.DonGia = product.DonGia;
                existingProduct.NgaySX = product.NgaySX;
                existingProduct.GiamGia = product.GiamGia;
                existingProduct.MoTa = product.MoTa;
                existingProduct.SoLanXem = product.SoLanXem;
                existingProduct.Hinh = product.Hinh;

                await _productRepository.UpdateAsync(existingProduct);

                return RedirectToAction(nameof(Index));
            }
            var loais = await _categoryRepository.GetAllAsync();
            ViewBag.Loais = new SelectList(loais, "MaLoai", "TenLoai");
            var nhacungcaps = await _factoryRepository.GetAllAsync();
            ViewBag.NhaCungCaps = new SelectList(nhacungcaps, "MaNCC", "MaNCC");
            return View(product);
        }
        [HttpGet]
        
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        // Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                await _productRepository.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Search(string keyword)
        {
            var poducts = await _productRepository.SearchAsync(keyword);
            return View(poducts);
        }
        
      
    }
}