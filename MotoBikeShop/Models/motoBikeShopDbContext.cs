
using MotoBikeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MotoBikeShop.Areas.Admin.Models;
namespace MotoBikeShop.Data;


public partial class motoBikeVHDbContext : IdentityDbContext<ApplicationUser>
{
   

    public motoBikeVHDbContext(DbContextOptions<motoBikeVHDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser> applicationUsers { get; set; }
    public DbSet<ChiTietHd> ChiTietHds { get; set; }

    public  DbSet<HangHoa> HangHoas { get; set; }

    public  DbSet<HoaDon> HoaDons { get; set; }

    public  DbSet<Loai> Loais { get; set; }

    public  DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public  DbSet<YeuThich> YeuThiches { get; set; }

    public DbSet<NhanXet> NhanXets { get; set; }
    public DbSet<MoMo> results { get; set; }
    public DbSet<EmailCustomer> EmailCustomers { get; set; }
    public DbSet<ThongSoKyThuat> thongSoKyThuats { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var yourEntity1 = new Loai { MaLoai = 1, TenLoai = "Xe Côn", TenLoaiAlias = "xe-con", MoTa = "Xe này để đua ", Hinh = "xecon.png" };
        var yourEntity11 = new Loai { MaLoai = 2, TenLoai = "Xe ga", TenLoaiAlias = "xe-ga", MoTa = "Xe này để tán gái", Hinh = "xega.png" };
        var yourEntity111 = new Loai { MaLoai = 3, TenLoai = "Xe số", TenLoaiAlias = "xe-so", MoTa = "Xe này để đi làm", Hinh = "xeso.png" };

        var yourEntity2 = new NhaCungCap
        {
            MaNCC = "NCC001",
            TenCongTy = "Công ty ABC",
            DiaChi = "Địa chỉ ABC",
            DienThoai = "123456789",
            Email = "info@gmail.com",
            Logo = "logo1.png",
            NguoiLienLac = "Người liên hệ ABC",
            MoTa = "nhà cung cấp vip1"
        };
        var yourEntity22 = new NhaCungCap
        {
            MaNCC = "NCC002",
            TenCongTy = "Công ty XYZ",
            DiaChi = "Địa chỉ XYZ",
            DienThoai = "987654321",
            Email = "info@gmail.com",
            Logo = "logo2.png",
            NguoiLienLac = "Người liên hệ XYZ",
            MoTa = "nhà cung cấp vip2"
        };
        var yourEntity222 = new NhaCungCap
        {
            MaNCC = "NCC003",
            TenCongTy = "Công ty DEF",
            DiaChi = "Địa chỉ DEF",
            DienThoai = "555555555",
            Email = "info@gmail.com",
            Logo = "logo3.png",
            NguoiLienLac = "Người liên hệ DEF",
            MoTa = "nhà cung cấp vip3"
        };

        var yourEntity3 = new HangHoa
        {
            MaHH = 1,
            TenHH = "Exciter",
            TenAlias = "exciter",
            MaLoai = 1,
            MoTaDonVi = "VND",
            DonGia = 400000,
            Hinh = "xecon.png",
            NgaySX = DateTime.Now,
            GiamGia = 9999999,
            SoLanXem = 99,
            MoTa = "xe này cực đẹp",
            MaNCC = "NCC002",
           
        };

        var yourEntity33 = new HangHoa
        {
            MaHH = 2,
            TenHH = "Vario",
            TenAlias = "vario",
            MaLoai = 2,
            MoTaDonVi = "VND",
            DonGia = 300000,
            Hinh = "xega.png",
            NgaySX = DateTime.Now,
            GiamGia = 9999999,
            SoLanXem = 99,
            MoTa = "xe này cực đẹp",
            MaNCC = "NCC001",
           
        };

        var yourEntity333 = new HangHoa
        {
            MaHH = 3,
            TenHH = "Wave RSX",
            TenAlias = "wave-rsx",
            MaLoai = 3,
            MoTaDonVi = "VND",
            DonGia = 100000,
            Hinh = "xeso.png",
            NgaySX = DateTime.Now,
            GiamGia = 9999999,
            SoLanXem = 99,
            MoTa = "xe này cực đẹp",
            MaNCC = "NCC003",

    
        };

        modelBuilder.Entity<Loai>().HasData(yourEntity1, yourEntity11, yourEntity111);
        modelBuilder.Entity<NhaCungCap>().HasData(yourEntity2, yourEntity22, yourEntity222);
        modelBuilder.Entity<HangHoa>().HasData(yourEntity3, yourEntity33, yourEntity333);

        base.OnModelCreating(modelBuilder);
    }

}
