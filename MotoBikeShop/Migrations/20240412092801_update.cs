using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DaySignUp",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 12, 16, 28, 1, 107, DateTimeKind.Local).AddTicks(5540));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 12, 16, 28, 1, 107, DateTimeKind.Local).AddTicks(5570));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 12, 16, 28, 1, 107, DateTimeKind.Local).AddTicks(5572));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaySignUp",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 11, 23, 25, 6, 946, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 11, 23, 25, 6, 946, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 11, 23, 25, 6, 946, DateTimeKind.Local).AddTicks(3930));
        }
    }
}
