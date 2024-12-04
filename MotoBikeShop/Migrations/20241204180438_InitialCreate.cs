using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaySignUp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailCustomers",
                columns: table => new
                {
                    IdEmail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAtTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailCustomers", x => x.IdEmail);
                });

            migrationBuilder.CreateTable(
                name: "Loais",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoaiAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loais", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCaps",
                columns: table => new
                {
                    MaNCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenCongTy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NguoiLienLac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCaps", x => x.MaNCC);
                });

            migrationBuilder.CreateTable(
                name: "results",
                columns: table => new
                {
                    partnerCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    accessKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    requestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    localMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    responseTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    errorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    extraData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    signature = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_results", x => x.partnerCode);
                });

            migrationBuilder.CreateTable(
                name: "thongSoKyThuats",
                columns: table => new
                {
                    MaTSKT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoiluongbanthan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dairongcao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    khoangcachtrucxe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    docaoyen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    khoangsanggamxe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dungtichbinhxang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kichthuocloptruocsau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phuoctruoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phuocsau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loaidongco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    congsuattoida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dungtichnhotmay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    muctieuthunhienlieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    loaitruyendong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hethongkhoidong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    momentcucdai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dungtichxylanh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duongkinhhanhtrinhpittong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tysonen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongSoKyThuats", x => x.MaTSKT);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CachThanhToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CachVanChuyen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhiVanChuyen = table.Column<double>(type: "float", nullable: false),
                    MaTrangThai = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanXets",
                columns: table => new
                {
                    MaGy = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayGy = table.Column<DateOnly>(type: "date", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanXets", x => x.MaGy);
                    table.ForeignKey(
                        name: "FK_NhanXets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HangHoas",
                columns: table => new
                {
                    MaHH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHH = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenAlias = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    MoTaDonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    Hinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySX = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false),
                    SoLanXem = table.Column<int>(type: "int", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThietKe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DongCoCongNghe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienIchAnToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNCC = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaTSKT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoas", x => x.MaHH);
                    table.ForeignKey(
                        name: "FK_HangHoas_Loais_MaLoai",
                        column: x => x.MaLoai,
                        principalTable: "Loais",
                        principalColumn: "MaLoai",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangHoas_NhaCungCaps_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NhaCungCaps",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HangHoas_thongSoKyThuats_MaTSKT",
                        column: x => x.MaTSKT,
                        principalTable: "thongSoKyThuats",
                        principalColumn: "MaTSKT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHds",
                columns: table => new
                {
                    MaCT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaHH = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    GiamGia = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHds", x => x.MaCT);
                    table.ForeignKey(
                        name: "FK_ChiTietHds_HangHoas_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoas",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHds_HoaDons_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YeuThiches",
                columns: table => new
                {
                    MaYT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHH = table.Column<int>(type: "int", nullable: true),
                    MaKH = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayChon = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YeuThiches", x => x.MaYT);
                    table.ForeignKey(
                        name: "FK_YeuThiches_HangHoas_MaHH",
                        column: x => x.MaHH,
                        principalTable: "HangHoas",
                        principalColumn: "MaHH");
                });

            migrationBuilder.InsertData(
                table: "Loais",
                columns: new[] { "MaLoai", "Hinh", "MoTa", "TenLoai", "TenLoaiAlias" },
                values: new object[,]
                {
                    { 1, "xecon.png", "Động Cơ Mạnh Mẽ ", "Xe Côn", "xe-con" },
                    { 2, "xega.png", "Sang Trọng ", "Xe ga", "xe-ga" },
                    { 3, "xeso.png", "Lịch Lãm Chững chạc", "Xe số", "xe-so" },
                    { 4, "xeso.png", "Êm Ái", "Xe điện", "xe-dien" }
                });

            migrationBuilder.InsertData(
                table: "NhaCungCaps",
                columns: new[] { "MaNCC", "DiaChi", "DienThoai", "Email", "Logo", "MoTa", "NguoiLienLac", "TenCongTy" },
                values: new object[,]
                {
                    { "NCC001", "Nhật Bản ", "0329999999", "honda@gmail.com", "Honda_Logo.png", "Honda là nhà sản xuất xe máy lớn nhất thế giới kể từ năm 1959,[4][5] đạt sản lượng 400 triệu vào cuối năm 2019,[6] cũng như là nhà sản xuất động cơ đốt trong lớn nhất thế giới tính theo khối lượng, sản xuất hơn 14 triệu động cơ đốt trong mỗi năm", "Huỳnh Đắc Việt", "Honda" },
                    { "NCC002", "Nhật Bản", "03298989898", "yamaha@gmail.com", "Logo_Yamaha.png", "Yamaha ban đầu là một công ty chế tạo đàn piano, Torakusu Yamaha là người sáng lập vào năm 1887 tại thành phố Hamamatsu, Shizuoka, Nhật Bản.", "Phan Nhật Trường", "Yamaha" },
                    { "NCC003", "Việt Nam", "03298989898", "vinfast@gmail.com", "vinfast_logo.png", "VinFast (hay VinFast LLC; viết tắt: VF, tên đầy đủ: Công ty cổ phần sản xuất và kinh doanh VinFast) là một nhà sản xuất ô tô và xe máy điện của Việt Nam được thành lập năm 2017 tại Hải Phòng. ", "Trần Thanh Thuận", "Vinfast" }
                });

            migrationBuilder.InsertData(
                table: "thongSoKyThuats",
                columns: new[] { "MaTSKT", "congsuattoida", "dairongcao", "docaoyen", "dungtichbinhxang", "dungtichnhotmay", "dungtichxylanh", "duongkinhhanhtrinhpittong", "hethongkhoidong", "khoangcachtrucxe", "khoangsanggamxe", "khoiluongbanthan", "kichthuocloptruocsau", "loaidongco", "loaitruyendong", "momentcucdai", "muctieuthunhienlieu", "phuocsau", "phuoctruoc", "tysonen" },
                values: new object[,]
                {
                    { 1, "11,5kW/9.000 vòng/phút", "2.019 x 727 x 1.104 mm", "795 mm", "4,5 ", "1,1 lít khi thay nhớt\r\n1,3 lít khi rã máy", "149,2 cm3", "57,30 mm x 57,84 mm", "Điện", "1.278 mm", "151 mm", "122 kg", "Trước: 90/80-17M/C 46P\r\nSau: 120/70-17M/C 58P", "PGM-FI, SOHC, 4 kỳ, xy-lanh đơn, côn tay 6 cấp số, làm mát bằng chất lỏng", "Cơ khí", "13,5Nm/7.000 vòng/phút", "1,98 lít/100km", "Lò xo trụ đơn", "Ống lồng, giảm chấn thủy lực", "11,3:1" },
                    { 2, "8,19kW/8500 vòng/phút", "1918 mm x 679 mm x 1066 mm", "769 mm", "5,5  ", "Xả: 0,8 lít\r\nTháo rã: 0,9 lít\r\nThay lọc dầu: 0,8 lít", "125 cm3", "52,400 x 57,907 mm", "Điện", "1280 mm", "131 mm", "113 kg", "\r\nTrước: 90/80 - 14M/C 43P\r\nSau: 100/80 - 14M/C 48P", "4 kỳ, 1 xi lanh, làm mát bằng chất lỏng", "Vô cấp, điều khiển tự động", "10,79Nm/5000 vòng/phút", "2,16l/100km", "Lò xo trụ đơn, giảm chấn thủy lực", "Ống lồng, giảm chấn thủy lực", "11,0 : 01" },
                    { 3, "6,46 kW / 7.500 vòng/phút", "1922 mm x 709 mm x 1082 mm (Bản thể thao & đặc biệt)", "760mm", "4,0  ", "0,8 lít khi thay nhớt\r\n1,0 lít khi rã máy", "109,2 cm3", "50,0 x 55,6 mm", "Đạp chân/Điện", "1227 mm", "135mm", "98 Kg (Bản thể thao)", "Lốp trước: 70/90 - 17 M/C 38P\r\nLốp sau: 80/90 - 17 M/C 50P", "Xăng, 4 kỳ, 1 xilanh, làm mát bằng không khí", "Vô cấp, điều khiển tự động", "8,70 Nm/6.000 vòng/phút", "1,56 L/100 km", "Lò xo trụ, giảm chấn thủy lực", "Ống lồng, giảm chấn thủy lực", "9,3 : 1" },
                    { 4, "8,19kW/8500 vòng/phút", "1895 x 678 x 1130 mm", "769 mm", "5,5  ", "Xả: 0,8 lít\r\nTháo rã: 0,9 lít\r\nThay lọc dầu: 0,8 lít", "125 cm3", "52,400 x 57,907 mm", "Điện", "1280 mm", "125mm", "100 kg", "\r\nTrước: 90/80 - 14M/C 43P\r\nSau: 100/80 - 14M/C 48P", "4 kỳ, 1 xi lanh, làm mát bằng chất lỏng", "Vô cấp, điều khiển tự động", "10,79Nm/5000 vòng/phút", "2,16l/100km", "Lò xo trụ đơn, giảm chấn thủy lực", "Ống lồng, giảm chấn thủy lực", "11,0 : 01" }
                });

            migrationBuilder.InsertData(
                table: "HangHoas",
                columns: new[] { "MaHH", "DonGia", "DongCoCongNghe", "GiamGia", "Hinh", "MaLoai", "MaNCC", "MaTSKT", "MoTa", "MoTaDonVi", "NgaySX", "SoLanXem", "TenAlias", "TenHH", "ThietKe", "TienIchAnToan" },
                values: new object[,]
                {
                    { 1, 40000000.0, "Mạnh Mẽ", 0.0, "ex.png", 1, "NCC002", 1, "Yamaha Exciter 2024 là mẫu xe côn tay được ưa chuộng nhất tại thị trường Việt Nam với thiết kế mang đậm dấu ấn đặc trưng DNA của Yamaha. Bên cạnh phiên bản Exciter 150 rất được yêu thích từ trước đó, Yamaha Motor Việt Nam vừa ra mắt phiên bản Exciter 155 VVA mới nhất được phát triển như một chiếc \"Tiểu YZF-R1\".", "VND", new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6415), 99, "exciter", "Exciter", "Trẻ trung", "Gọn Nhẹ" },
                    { 2, 30000000.0, "Mạnh Mẽ", 0.0, "varioo.png", 2, "NCC001", 2, "Vario 125 sở hữu thiết kế thể thao vô cùng trẻ trung ấn tượng, khác biệt hẳn so với những mẫu xe tay ga phổ thông truyền thống, mang đậm dấu ấn cá nhân sành điệu, luôn khao khát thể hiện cái tôi & khẳng định một cách mạnh mẽ cá tính riêng biệt của chủ sở hữu.", "VND", new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6433), 99, "vario", "Vario", "Trẻ trung", "Gọn Nhẹ" },
                    { 3, 10000000.0, "Mạnh Mẽ", 0.0, "waver.png", 3, "NCC001", 3, "Phong cách thiết kế của Wave RSX FI là sự kết hợp hoàn hảo giữa yếu tố thể thao, năng động và tiện lợi trong sử dụng. Những đường nét góc cạnh không chỉ tôn lên vẻ mạnh mẽ mà còn tạo ra nét cá tính riêng của xe.", "VND", new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6435), 99, "wave-rsx", "Wave RSX", "Trẻ trung", "Gọn Nhẹ" },
                    { 4, 10000000.0, "Mạnh Mẽ", 0.0, "xe-may-dien-vinfast-klara.jpg", 4, "NCC003", 4, "Phong cách thiết kế của Wave RSX FI là sự kết hợp hoàn hảo giữa yếu tố thể thao, năng động và tiện lợi trong sử dụng. Những đường nét góc cạnh không chỉ tôn lên vẻ mạnh mẽ mà còn tạo ra nét cá tính riêng của xe.", "VND", new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6437), 99, "vinfast-klara", "Xe máy điện VinFast Klara S ", "Trẻ trung", "Gọn Nhẹ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHds_MaHD",
                table: "ChiTietHds",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHds_MaHH",
                table: "ChiTietHds",
                column: "MaHH");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaLoai",
                table: "HangHoas",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaNCC",
                table: "HangHoas",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_HangHoas_MaTSKT",
                table: "HangHoas",
                column: "MaTSKT");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_UserId",
                table: "HoaDons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanXets_UserId",
                table: "NhanXets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_YeuThiches_MaHH",
                table: "YeuThiches",
                column: "MaHH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChiTietHds");

            migrationBuilder.DropTable(
                name: "EmailCustomers");

            migrationBuilder.DropTable(
                name: "NhanXets");

            migrationBuilder.DropTable(
                name: "results");

            migrationBuilder.DropTable(
                name: "YeuThiches");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "HangHoas");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Loais");

            migrationBuilder.DropTable(
                name: "NhaCungCaps");

            migrationBuilder.DropTable(
                name: "thongSoKyThuats");
        }
    }
}
