using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMall.API.Migrations
{
    /// <inheritdoc />
    public partial class AddShopImagesAndUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Shops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitNumber",
                table: "Shops",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "UnitNumber",
                table: "Shops");
        }
    }
}
