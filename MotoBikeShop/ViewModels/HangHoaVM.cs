using MotoBikeShop.Models;
using System.ComponentModel.DataAnnotations;

namespace MotoBikeShop.ViewModels
{
    public class HangHoaVM
    {
        public int MaHh { get; set; }
        public required String TenHh { get; set; }
        public required String Hinh { get; set; }   
        public double DonGia { get; set; }   
        public required String MoTaNgan { get; set; }   
        public required String TenLoai { get; set; }
    }
    public class CTHangHoaVM
    {
        public int MaHh { get; set; }
        public required String TenHh { get; set; }
        public required String Hinh { get; set; }
        public double DonGia { get; set; }
        public required String MoTaNgan { get; set; }
        public required String TenLoai { get; set; }
        public required String ChiTiet { get; set; }
        public required int DiemDanhGia { get; set; }
        public required int SoLuongTon { get; set; }
		public required int MaLoai { get; set; }
		public string? khoiluongbanthan { get; set; }
		[MaxLength(50)]
		public string dairongcao { get; set; }
		public string? khoangcachtrucxe { get; set; }
		public string? docaoyen { get; set; }
		public string? khoangsanggamxe { get; set; }
		public string? dungtichbinhxang { get; set; }
		public string? kichthuocloptruocsau { get; set; }
		public string? phuoctruoc { get; set; }
		public string? phuocsau { get; set; }
		public string? loaidongco { get; set; }
		public string? congsuattoida { get; set; }
		public string? dungtichnhotmay { get; set; }
		public string? muctieuthunhienlieu { get; set; }
		public string? loaitruyendong { get; set; }
		public string? hethongkhoidong { get; set; }
		public string? momentcucdai { get; set; }
		public string? dungtichxylanh { get; set; }
		public string? duongkinhhanhtrinhpittong { get; set; }
		public string? ThietKe { get; set; }
		public string? DongCoCongNghe { get; set; }
		public string? TienIchAnToan { get; set; }
		public string? tysonen { get; set; }
	}

}
