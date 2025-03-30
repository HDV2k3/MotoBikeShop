using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class AKA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "HangHoas");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NhaCungCaps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "NhaCungCaps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NhaCungCaps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "test",
                table: "HangHoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                columns: new[] { "NgaySX", "test" },
                values: new object[] { new DateTime(2025, 3, 27, 0, 24, 37, 49, DateTimeKind.Local).AddTicks(2487), 0 });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                columns: new[] { "NgaySX", "test" },
                values: new object[] { new DateTime(2025, 3, 27, 0, 24, 37, 49, DateTimeKind.Local).AddTicks(2553), 0 });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                columns: new[] { "NgaySX", "test" },
                values: new object[] { new DateTime(2025, 3, 27, 0, 24, 37, 49, DateTimeKind.Local).AddTicks(2555), 0 });

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 4,
                columns: new[] { "NgaySX", "test" },
                values: new object[] { new DateTime(2025, 3, 27, 0, 24, 37, 49, DateTimeKind.Local).AddTicks(2557), 0 });
        }
    }
}
