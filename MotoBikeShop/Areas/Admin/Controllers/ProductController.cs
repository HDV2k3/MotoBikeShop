﻿using Microsoft.AspNetCore.Authorization;
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
        //Hiển thị form thêm sản phẩm mới

      
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