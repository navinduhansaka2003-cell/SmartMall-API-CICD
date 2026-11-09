using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartMall.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cinema" },
                    { 2, "Activities" },
                    { 3, "Kid Zone" },
                    { 4, "Events" }
                });

            migrationBuilder.InsertData(
                table: "Floors",
                columns: new[] { "Id", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "" },
                    { 2, 2, "" },
                    { 3, 3, "" }
                });

            migrationBuilder.InsertData(
                table: "Entertainment",
                columns: new[] { "Id", "CategoryId", "Description", "FloorId", "Hotline", "Hours", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 1, "3D & IMAX Cinema", 3, "0112345678", "10 AM - 10 PM", "", "Movie Theaters" },
                    { 2, 2, "Arcade & VR Games", 3, "0112345679", "09 AM - 11 PM", "", "Gaming Zone" },
                    { 3, 3, "Fun zone for toddlers", 2, "0112345680", "09 AM - 08 PM", "", "Kids Play Area" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Entertainment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Entertainment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Entertainment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Floors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
