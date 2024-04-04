using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoBikeShop.Migrations
{
    /// <inheritdoc />
    public partial class tableEmail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailCustomers_AspNetUsers_UserId",
                table: "EmailCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmailCustomers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmailCustomers_AspNetUsers_UserId",
                table: "EmailCustomers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailCustomers_AspNetUsers_UserId",
                table: "EmailCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EmailCustomers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 1,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 1, 7, 280, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 2,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 1, 7, 280, DateTimeKind.Local).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "HangHoas",
                keyColumn: "MaHH",
                keyValue: 3,
                column: "NgaySX",
                value: new DateTime(2024, 4, 1, 20, 1, 7, 280, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.AddForeignKey(
                name: "FK_EmailCustomers_AspNetUsers_UserId",
                table: "EmailCustomers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
