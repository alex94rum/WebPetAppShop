using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class CorrectFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("064f9892-393b-4b1b-85a5-ba611acd90df"),
                column: "Name",
                value: "Курс по Java");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6498025c-cec5-43e5-8740-403fc45e9396"),
                column: "Name",
                value: "Курс по C#");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("064f9892-393b-4b1b-85a5-ba611acd90df"),
                column: "Name",
                value: "КУср по Java");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6498025c-cec5-43e5-8740-403fc45e9396"),
                column: "Name",
                value: "КУср по C#");
        }
    }
}
