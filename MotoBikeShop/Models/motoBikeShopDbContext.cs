
using MotoBikeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    public DbSet<HangHoaTranslation> HangHoaTranslations { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var yourEntity1 = new Loai { MaLoai = 1, TenLoai = "Xe Côn", TenLoaiAlias = "xe-con", MoTa = "Động Cơ Mạnh Mẽ ", Hinh = "xecon.png" };
        var yourEntity11 = new Loai { MaLoai = 2, TenLoai = "Xe ga", TenLoaiAlias = "xe-ga", MoTa = "Sang Trọng ", Hinh = "xega.png" };
        var yourEntity111 = new Loai { MaLoai = 3, TenLoai = "Xe số", TenLoaiAlias = "xe-so", MoTa = "Lịch Lãm Chững chạc", Hinh = "xeso.png" };
        var yourEntity1111 = new Loai { MaLoai = 4, TenLoai = "Xe điện", TenLoaiAlias = "xe-dien", MoTa = "Êm Ái", Hinh = "xeso.png" };
        var yourEntity2 = new NhaCungCap
        {

            MaNCC = "NCC001",
            TenCongTy = "Honda",
            DiaChi = "Nhật Bản ",
            DienThoai = "0329999999",
            Email = "honda@gmail.com",
            Logo = "Honda_Logo.png",
            NguoiLienLac = "Huỳnh Đắc Việt",
            MoTa = "Honda là nhà sản xuất xe máy lớn nhất thế giới kể từ năm 1959,[4][5] đạt sản lượng 400 triệu vào cuối năm 2019,[6] cũng như là nhà sản xuất động cơ đốt trong lớn nhất thế giới tính theo khối lượng, sản xuất hơn 14 triệu động cơ đốt trong mỗi năm"
        };
        var yourEntity22 = new NhaCungCap
        {
            MaNCC = "NCC002",
            TenCongTy = "Yamaha",
            DiaChi = "Nhật Bản",
            DienThoai = "03298989898",
            Email = "yamaha@gmail.com",
            Logo = "Logo_Yamaha.png",
            NguoiLienLac = "Phan Nhật Trường",
            MoTa = "Yamaha ban đầu là một công ty chế tạo đàn piano, Torakusu Yamaha là người sáng lập vào năm 1887 tại thành phố Hamamatsu, Shizuoka, Nhật Bản."
        };
        var yourEntity222 = new NhaCungCap
        {
            MaNCC = "NCC003",
            TenCongTy = "Vinfast",
            DiaChi = "Việt Nam",
            DienThoai = "03298989898",
            Email = "vinfast@gmail.com",
            Logo = "vinfast_logo.png",
            NguoiLienLac = "Trần Thanh Thuận",
            MoTa = "VinFast (hay VinFast LLC; viết tắt: VF, tên đầy đủ: Công ty cổ phần sản xuất và kinh doanh VinFast) là một nhà sản xuất ô tô và xe máy điện của Việt Nam được thành lập năm 2017 tại Hải Phòng. "
        };
        var yourEntity3 = new HangHoa
        {
            MaHH = 1,
            TenHH = "Exciter",
            TenAlias = "exciter",
            MaLoai = 1,
            MoTaDonVi = "VND",
            DonGia = 40000000,
            Hinh = "ex.png",
            NgaySX = DateTime.Now,
            GiamGia = 0,
            SoLanXem = 99,
            MoTa = "Yamaha Exciter 2024 là mẫu xe côn tay được ưa chuộng nhất tại thị trường Việt Nam với thiết kế mang đậm dấu ấn đặc trưng DNA của Yamaha." +
           " Bên cạnh phiên bản Exciter 150 rất được yêu thích từ trước đó, Yamaha Motor Việt Nam vừa ra mắt phiên bản Exciter 155 VVA mới nhất được phát triển như một chiếc \"Tiểu YZF-R1\".",
            ThietKe = "Trẻ trung",
            DongCoCongNghe = "Mạnh Mẽ",
            TienIchAnToan = "Gọn Nhẹ",
            MaNCC = "NCC002",
            MaTSKT = 1,
        };

        var yourEntity33 = new HangHoa
        {
            MaHH = 2,
            TenHH = "Vario",
            TenAlias = "vario",
            MaLoai = 2,
            MoTaDonVi = "VND",
            DonGia = 30000000,
            Hinh = "varioo.png",
            NgaySX = DateTime.Now,
            GiamGia = 0,
            SoLanXem = 99,
            MoTa = "Vario 125 sở hữu thiết kế thể thao vô cùng trẻ trung ấn tượng, khác biệt hẳn so với những mẫu xe tay ga phổ thông truyền thống, " +
            "mang đậm dấu ấn cá nhân sành điệu, luôn khao khát thể hiện cái tôi & khẳng định một cách mạnh mẽ cá tính riêng biệt của chủ sở hữu.",
            ThietKe = "Trẻ trung",
            DongCoCongNghe = "Mạnh Mẽ",
            TienIchAnToan = "Gọn Nhẹ",
            MaNCC = "NCC001",
            MaTSKT = 2,
        };

        var yourEntity333 = new HangHoa
        {
            MaHH = 3,
            TenHH = "Wave RSX",
            TenAlias = "wave-rsx",
            MaLoai = 3,
            MoTaDonVi = "VND",
            DonGia = 10000000,
            Hinh = "waver.png",
            NgaySX = DateTime.Now,
            GiamGia = 0,
            SoLanXem = 99,
            MoTa = "Phong cách thiết kế của Wave RSX FI là sự kết hợp hoàn hảo giữa yếu tố thể thao, năng động và tiện lợi trong sử dụng. Những đường nét góc cạnh không chỉ tôn lên vẻ mạnh mẽ mà còn tạo ra nét cá tính riêng của xe.",
            ThietKe = "Trẻ trung",
            DongCoCongNghe = "Mạnh Mẽ",
            TienIchAnToan = "Gọn Nhẹ",
            MaNCC = "NCC001",
            MaTSKT = 3,

        };
        var yourEntity3333 = new HangHoa
        {
            MaHH = 4,
            TenHH = "Xe máy điện VinFast Klara S ",
            TenAlias = "vinfast-klara",
            MaLoai = 4,
            MoTaDonVi = "VND",
            DonGia = 10000000,
            Hinh = "xe-may-dien-vinfast-klara.jpg",
            NgaySX = DateTime.Now,
            GiamGia = 0,
            SoLanXem = 99,
            MoTa = "Phong cách thiết kế của Wave RSX FI là sự kết hợp hoàn hảo giữa yếu tố thể thao, năng động và tiện lợi trong sử dụng. Những đường nét góc cạnh không chỉ tôn lên vẻ mạnh mẽ mà còn tạo ra nét cá tính riêng của xe.",
            ThietKe = "Trẻ trung",
            DongCoCongNghe = "Mạnh Mẽ",
            TienIchAnToan = "Gọn Nhẹ",
            MaNCC = "NCC003",
            MaTSKT = 4,
        };
        var yourEntity4 = new ThongSoKyThuat
        {
            MaTSKT = 1,
            khoiluongbanthan = "122 kg",
            dairongcao = "2.019 x 727 x 1.104 mm",
            khoangcachtrucxe = "1.278 mm",
            docaoyen = "795 mm",
            khoangsanggamxe = "151 mm",
            dungtichbinhxang = "4,5 ",
            kichthuocloptruocsau = "Trước: 90/80-17M/C 46P\r\nSau: 120/70-17M/C 58P",
            phuoctruoc = "Ống lồng, giảm chấn thủy lực",
            phuocsau = "Lò xo trụ đơn",
            loaidongco = "PGM-FI, SOHC, 4 kỳ, xy-lanh đơn, côn tay 6 cấp số, làm mát bằng chất lỏng",
            hethongkhoidong = "Điện",
            congsuattoida = "11,5kW/9.000 vòng/phút",
            dungtichnhotmay = "1,1 lít khi thay nhớt\r\n1,3 lít khi rã máy",
            muctieuthunhienlieu = "1,98 lít/100km",
            loaitruyendong = "Cơ khí",
            momentcucdai = "13,5Nm/7.000 vòng/phút",
            dungtichxylanh = "149,2 cm3",
            duongkinhhanhtrinhpittong = "57,30 mm x 57,84 mm",
            tysonen = "11,3:1",


        };

        var yourEntity44 = new ThongSoKyThuat
        {
            MaTSKT = 2,
            khoiluongbanthan = "113 kg",
            dairongcao = "1918 mm x 679 mm x 1066 mm",
            khoangcachtrucxe = "1280 mm",
            docaoyen = "769 mm",
            khoangsanggamxe = "131 mm",
            dungtichbinhxang = "5,5  ",
            kichthuocloptruocsau = "\r\nTrước: 90/80 - 14M/C 43P\r\nSau: 100/80 - 14M/C 48P",
            phuoctruoc = "Ống lồng, giảm chấn thủy lực",
            phuocsau = "Lò xo trụ đơn, giảm chấn thủy lực",
            loaidongco = "4 kỳ, 1 xi lanh, làm mát bằng chất lỏng",
            congsuattoida = "8,19kW/8500 vòng/phút",
            dungtichnhotmay = "Xả: 0,8 lít\r\nTháo rã: 0,9 lít\r\nThay lọc dầu: 0,8 lít",
            muctieuthunhienlieu = "2,16l/100km",
            loaitruyendong = "Vô cấp, điều khiển tự động",
            hethongkhoidong = "Điện",
            momentcucdai = "10,79Nm/5000 vòng/phút",
            dungtichxylanh = "125 cm3",
            duongkinhhanhtrinhpittong = "52,400 x 57,907 mm",
            tysonen = "11,0 : 01",
        };
        var yourEntity444 = new ThongSoKyThuat
        {
            MaTSKT = 3,
            khoiluongbanthan = "98 Kg (Bản thể thao)",
            dairongcao = "1922 mm x 709 mm x 1082 mm (Bản thể thao & đặc biệt)",
            khoangcachtrucxe = "1227 mm",
            docaoyen = "760mm",
            khoangsanggamxe = "135mm",
            dungtichbinhxang = "4,0  ",
            kichthuocloptruocsau = "Lốp trước: 70/90 - 17 M/C 38P\r\nLốp sau: 80/90 - 17 M/C 50P",
            phuoctruoc = "Ống lồng, giảm chấn thủy lực",
            phuocsau = "Lò xo trụ, giảm chấn thủy lực",
            loaidongco = "Xăng, 4 kỳ, 1 xilanh, làm mát bằng không khí",
            congsuattoida = "6,46 kW / 7.500 vòng/phút",
            dungtichnhotmay = "0,8 lít khi thay nhớt\r\n1,0 lít khi rã máy",
            muctieuthunhienlieu = "1,56 L/100 km",
            loaitruyendong = "Vô cấp, điều khiển tự động",
            hethongkhoidong = "Đạp chân/Điện",
            momentcucdai = "8,70 Nm/6.000 vòng/phút",
            dungtichxylanh = "109,2 cm3",
            duongkinhhanhtrinhpittong = "50,0 x 55,6 mm",
            tysonen = "9,3 : 1",
        };
        var yourEntity4444 = new ThongSoKyThuat
        {
            MaTSKT = 4,
            khoiluongbanthan = "100 kg",
            dairongcao = "1895 x 678 x 1130 mm",
            khoangcachtrucxe = "1280 mm",
            docaoyen = "769 mm",
            khoangsanggamxe = "125mm",
            dungtichbinhxang = "5,5  ",
            kichthuocloptruocsau = "\r\nTrước: 90/80 - 14M/C 43P\r\nSau: 100/80 - 14M/C 48P",
            phuoctruoc = "Ống lồng, giảm chấn thủy lực",
            phuocsau = "Lò xo trụ đơn, giảm chấn thủy lực",
            loaidongco = "4 kỳ, 1 xi lanh, làm mát bằng chất lỏng",
            congsuattoida = "8,19kW/8500 vòng/phút",
            dungtichnhotmay = "Xả: 0,8 lít\r\nTháo rã: 0,9 lít\r\nThay lọc dầu: 0,8 lít",
            muctieuthunhienlieu = "2,16l/100km",
            loaitruyendong = "Vô cấp, điều khiển tự động",
            hethongkhoidong = "Điện",
            momentcucdai = "10,79Nm/5000 vòng/phút",
            dungtichxylanh = "125 cm3",
            duongkinhhanhtrinhpittong = "52,400 x 57,907 mm",
            tysonen = "11,0 : 01",

        };
       



        modelBuilder.Entity<Loai>().HasData(yourEntity1, yourEntity11, yourEntity111, yourEntity1111);
        modelBuilder.Entity<NhaCungCap>().HasData(yourEntity2, yourEntity22, yourEntity222);
        modelBuilder.Entity<HangHoa>().HasData(yourEntity3, yourEntity33, yourEntity333, yourEntity3333);
        modelBuilder.Entity<ThongSoKyThuat>().HasData(yourEntity4, yourEntity44, yourEntity444, yourEntity4444);
        base.OnModelCreating(modelBuilder);
    }

}
