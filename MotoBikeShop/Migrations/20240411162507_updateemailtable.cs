using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class updateemailtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EmailCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "EmailCustomers",
                type: "nvarchar(max)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmailCustomers");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "EmailCustomers");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 10, 20, 11, 44, 684, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 10, 20, 11, 44, 684, DateTimeKind.Local).AddTicks(6126));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 10, 20, 11, 44, 684, DateTimeKind.Local).AddTicks(6127));
        }
    }
}
