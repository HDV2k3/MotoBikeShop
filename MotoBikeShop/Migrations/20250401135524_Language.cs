using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class Language : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoaTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHH = table.Column<int>(type: "int", nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TenHH = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    MoTaNgan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    HangHoaMaHH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoaTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HangHoaTranslations_HangHoas_HangHoaMaHH",
                        column: x => x.HangHoaMaHH,
                        principalTable: "HangHoas",
                        principalColumn: "MaHH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2025, 4, 1, 20, 55, 22, 863, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2025, 4, 1, 20, 55, 22, 863, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2025, 4, 1, 20, 55, 22, 863, DateTimeKind.Local).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 4,
                column: "NgaySX",
                value: new DateTime(2025, 4, 1, 20, 55, 22, 863, DateTimeKind.Local).AddTicks(3226));

            migrationBuilder.CreateIndex(
                name: "IX_HangHoaTranslations_HangHoaMaHH",
                table: "HangHoaTranslations",
                column: "HangHoaMaHH");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoaTranslations");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2025, 3, 30, 15, 14, 27, 380, DateTimeKind.Local).AddTicks(6523));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2025, 3, 30, 15, 14, 27, 380, DateTimeKind.Local).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2025, 3, 30, 15, 14, 27, 380, DateTimeKind.Local).AddTicks(6542));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 4,
                column: "NgaySX",
                value: new DateTime(2025, 3, 30, 15, 14, 27, 380, DateTimeKind.Local).AddTicks(6544));
        }
    }
}
