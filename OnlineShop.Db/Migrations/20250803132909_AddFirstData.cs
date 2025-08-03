using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("064f9892-393b-4b1b-85a5-ba611acd90df"), 99m, "Описание курса по Java", "/images/java.png", "КУср по Java" },
                    { new Guid("6498025c-cec5-43e5-8740-403fc45e9396"), 100m, "Описание курса по C#", "/images/c-sharp.png", "КУср по C#" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("064f9892-393b-4b1b-85a5-ba611acd90df"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6498025c-cec5-43e5-8740-403fc45e9396"));
        }
    }
}
