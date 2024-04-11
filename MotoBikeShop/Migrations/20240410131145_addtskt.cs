using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class addtskt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DongCoCongNghe",
                table: "HangHoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThietKe",
                table: "HangHoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TienIchAnToan",
                table: "HangHoas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "thongSoKyThuats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khoiluongbanthan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    dairongcao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    tysonen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaHangHoaNavigation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_thongSoKyThuats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_thongSoKyThuats_HangHoas_MaHangHoaNavigation",
                        column: x => x.MaHangHoaNavigation,
                        principalTable: "HangHoas",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                columns: new[] { "DongCoCongNghe", "NgaySX", "ThietKe", "TienIchAnToan" },
                values: new object[] { null, new DateTime(2024, 4, 10, 20, 11, 44, 684, DateTimeKind.Local).AddTicks(6107), null, null });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                columns: new[] { "DongCoCongNghe", "NgaySX", "ThietKe", "TienIchAnToan" },
                values: new object[] { null, new DateTime(2024, 4, 10, 20, 11, 44, 684, DateTimeKind.Local).AddTicks(6126), null, null });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                columns: new[] { "DongCoCongNghe", "NgaySX", "ThietKe", "TienIchAnToan" },
                values: new object[] { null, new DateTime(2024, 4, 10, 20, 11, 44, 684, DateTimeKind.Local).AddTicks(6127), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_thongSoKyThuats_MaHangHoaNavigation",
                table: "thongSoKyThuats",
                column: "MaHangHoaNavigation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "thongSoKyThuats");

            migrationBuilder.DropColumn(
                name: "DongCoCongNghe",
                table: "HangHoas");

            migrationBuilder.DropColumn(
                name: "ThietKe",
                table: "HangHoas");

            migrationBuilder.DropColumn(
                name: "TienIchAnToan",
                table: "HangHoas");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 27, 45, 800, DateTimeKind.Local).AddTicks(9819));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 27, 45, 800, DateTimeKind.Local).AddTicks(9833));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 27, 45, 800, DateTimeKind.Local).AddTicks(9835));
        }
    }
}
