using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.ViewModels
{
    public class CheckoutVM
    {
        public bool GiongKhachHang { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? GhiChu { get; set; }
        public double? PhiVanChuyen { get; set; }
        public string? CachThanhToan { get; set; }
        public string? TongTien { get; set; }
    }
}
