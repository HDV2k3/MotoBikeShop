using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Data;
using MotoBikeShop.Migrations;
using MotoBikeShop.Models;
using MotoBikeShop.Repository;
using MotoBikeShop.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using static MotoBikeShop.Service.Models;

namespace MotoBikeShop.Controllers
{
    public class HangHoaController : Controller
    {

        private readonly motoBikeVHDbContext db;

        private readonly HttpClient _httpClient;
        public HangHoaController(motoBikeVHDbContext context)
        {
            db = context;
            _httpClient = new HttpClient();

        }
        public IActionResult Index(int? loai, int? page, string? ncc)
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

            var pagedHanghoas = hanghoas.Select(p => new HangHoaVM
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

            };
            return View(result);
        }

    }

}
