using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class tableEmail11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailCustomers_AspNetUsers_UserId",
                table: "EmailCustomers");

            migrationBuilder.DropIndex(
                name: "IX_EmailCustomers_UserId",
                table: "EmailCustomers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EmailCustomers");

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 16, 36, 97, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 16, 36, 97, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 16, 36, 97, DateTimeKind.Local).AddTicks(7684));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "EmailCustomers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 10, 55, 581, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 10, 55, 581, DateTimeKind.Local).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 10, 55, 581, DateTimeKind.Local).AddTicks(7975));

            migrationBuilder.CreateIndex(
                name: "IX_EmailCustomers_UserId",
                table: "EmailCustomers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailCustomers_AspNetUsers_UserId",
                table: "EmailCustomers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
