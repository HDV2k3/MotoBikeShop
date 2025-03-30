using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class HAHAH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "test",
                table: "HangHoas");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6433));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6435));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 4,
                column: "NgaySX",
                value: new DateTime(2024, 12, 5, 1, 4, 36, 166, DateTimeKind.Local).AddTicks(6437));
        }
    }
}
