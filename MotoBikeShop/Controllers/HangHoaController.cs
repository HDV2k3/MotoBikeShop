using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;
using MotoBikeShop.Service;
using MotoBikeShop.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using static MotoBikeShop.Service.Models;

namespace MotoBikeShop.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly IProductRepository _productRepository;

        private readonly motoBikeVHDbContext db;
        private readonly ILocalizationService _localizationService;


        private readonly HttpClient _httpClient;
        public HangHoaController(motoBikeVHDbContext context, IProductRepository productRepository, ILocalizationService localizationService)
        {
            db = context;
            _httpClient = new HttpClient();
            _productRepository = productRepository;
            _localizationService = localizationService;
        }
        public async Task<IActionResult> Index(int? loai, int? page, string? ncc)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hanghoas = hanghoas.Where(p => p.MaLoai == loai.Value);
            }
            if (!string.IsNullOrEmpty(ncc))
            {
                hanghoas = hanghoas.Where(p => p.MaNCC == ncc);
            }

            int pageSize = 8; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = page ?? 1; // Trang hiện tại

            // Lấy danh sách mã hàng hóa cần hiển thị trên trang hiện tại
            var pagedProductIds = hanghoas
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => p.MaHH)
                .ToList();

            // Chuẩn bị danh sách hàng hóa với thông tin đa ngôn ngữ
            var currentLanguage = _localizationService.GetCurrentLanguageCode();
            var pagedHanghoas = new List<HangHoaVM>();

            foreach (var maHh in pagedProductIds)
            {
                var hangHoa = await db.HangHoas.FindAsync(maHh);

                // Kiểm tra xem có bản dịch cho sản phẩm này không
                var translation = await db.HangHoaTranslations
                    .FirstOrDefaultAsync(t => t.MaHH == maHh && t.LanguageCode == currentLanguage);

                var hangHoaVM = new HangHoaVM
                {
                    MaHh = maHh,
                    TenHh = translation?.TenHH ?? hangHoa.TenHH,
                    DonGia = hangHoa.DonGia ?? 0,
                    Hinh = hangHoa.Hinh ?? "",
                    MoTaNgan = translation?.MoTaNgan ?? hangHoa.MoTaDonVi ?? "",
                    TenLoai = hangHoa.MaLoaiNavigation?.TenLoai ?? "Chưa có loại",
                    CurrentLanguage = currentLanguage,
                    HasTranslation = translation != null
                };

                pagedHanghoas.Add(hangHoaVM);
            }

            int totalItems = hanghoas.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedHanghoas);
        }
        public IActionResult Search(String? query)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (query != null)
            {
            hanghoas = hanghoas.Where(p => p.TenHH.Contains(query));

            }
            var result = hanghoas.Select(p => new HangHoaVM
            {
                MaHh = p.MaHH,
                TenHh = p.TenHH,
                DonGia = p.DonGia ?? 0,
                Hinh = p.Hinh ?? "",
                MoTaNgan = p.MoTaDonVi ?? "",
                TenLoai = p.MaLoaiNavigation.TenLoai
            });
            return View(result);
        }
        public IActionResult Detail(int id)
        {
            var data = db.HangHoas
                .Include(p => p.MaLoaiNavigation)
                .Include(p=>p.MaTSKTNavigation)
                .SingleOrDefault(p => p.MaHH == id);
            if (data == null)
            {
                TempData["Message"] = $"Không thấy sản phẩm có mã {id}";
                return Redirect("/404");
            }
            var result = new CTHangHoaVM
            {

                MaLoai = data.MaLoai,
                MaHh = data.MaHH,
                TenHh = data.TenHH,
                DonGia = data.DonGia ?? 0,
                ChiTiet = data.MoTa ?? string.Empty,
                Hinh = data.Hinh ?? string.Empty,
                MoTaNgan = data.MoTaDonVi ?? string.Empty,
                TenLoai = data.MaLoaiNavigation.TenLoai,
                SoLuongTon = 10,//tính sau
                DiemDanhGia = 5,//check sau
                ThietKe=data.ThietKe,
                DongCoCongNghe=data.DongCoCongNghe,
                TienIchAnToan=data.TienIchAnToan,
               khoiluongbanthan=data.MaTSKTNavigation.khoiluongbanthan,
               dairongcao=data.MaTSKTNavigation.dairongcao,
               khoangcachtrucxe=data.MaTSKTNavigation.khoangcachtrucxe,
               docaoyen=data.MaTSKTNavigation.docaoyen,
               khoangsanggamxe=data.MaTSKTNavigation.khoangsanggamxe,
               dungtichbinhxang=data.MaTSKTNavigation.dungtichbinhxang,
               kichthuocloptruocsau=data.MaTSKTNavigation.kichthuocloptruocsau,
               phuoctruoc=data.MaTSKTNavigation.phuoctruoc,
               phuocsau=data.MaTSKTNavigation.phuocsau,
               loaidongco=data.MaTSKTNavigation.loaidongco,
               congsuattoida=data.MaTSKTNavigation.congsuattoida,
               dungtichnhotmay=data.MaTSKTNavigation.dungtichnhotmay,
               muctieuthunhienlieu=data.MaTSKTNavigation.muctieuthunhienlieu,
               loaitruyendong = data.MaTSKTNavigation.loaitruyendong,
               hethongkhoidong=data.MaTSKTNavigation.hethongkhoidong,
               momentcucdai=data.MaTSKTNavigation.momentcucdai,
               dungtichxylanh=data.MaTSKTNavigation.dungtichxylanh,
               duongkinhhanhtrinhpittong=data.MaTSKTNavigation.duongkinhhanhtrinhpittong,
               tysonen=data.MaTSKTNavigation.tysonen,

            };
            return View(result);
        }

        public IActionResult TangDan(int? loai, int? page, string? ncc)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hanghoas = hanghoas.Where(p => p.MaLoai == loai.Value);
            }
            if (!string.IsNullOrEmpty(ncc))
            {
                hanghoas = hanghoas.Where(p => p.MaNCC == ncc);
            }
            int pageSize = 6; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = page ?? 1; // Trang hiện tại

            var pagedHanghoas = hanghoas.OrderBy(p => p.DonGia ?? 0).Select(p => new HangHoaVM
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

            int totalItems = hanghoas.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedHanghoas);
        }

        public IActionResult GiamDan(int? loai, int? page, string? ncc)
        {
            var hanghoas = db.HangHoas.AsQueryable();
            if (loai.HasValue)
            {
                hanghoas = hanghoas.Where(p => p.MaLoai == loai.Value);
            }
            if (!string.IsNullOrEmpty(ncc))
            {
                hanghoas = hanghoas.Where(p => p.MaNCC == ncc);
            }
            int pageSize = 6; // Số lượng sản phẩm trên mỗi trang
            int pageNumber = page ?? 1; // Trang hiện tại

            var pagedHanghoas = hanghoas.OrderByDescending(p => p.DonGia ?? 0).Select(p => new HangHoaVM
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

            int totalItems = hanghoas.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;

            return View(pagedHanghoas);
        }

    }

}
