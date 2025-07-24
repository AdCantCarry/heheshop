using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace heheshop.Migrations
{
    /// <inheritdoc />
    public partial class updatedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DiscountCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 8, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "DiscountCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 9, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1430));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 7, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 7, 23, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2025, 7, 20, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 25, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 24, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 0, 50, 17, 174, DateTimeKind.Local).AddTicks(1453));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "DiscountCodes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiryDate",
                value: new DateTime(2025, 8, 23, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "DiscountCodes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiryDate",
                value: new DateTime(2025, 9, 23, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2025, 7, 23, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2025, 7, 21, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2025, 7, 18, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7587));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 23, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 22, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7700));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 8, 14, 32, 136, DateTimeKind.Local).AddTicks(7701));
        }
    }
}
