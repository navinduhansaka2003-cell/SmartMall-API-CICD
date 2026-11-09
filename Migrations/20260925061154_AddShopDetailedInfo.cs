using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMall.API.Migrations
{
    /// <inheritdoc />
    public partial class AddShopDetailedInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CloseTime",
                table: "Shops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HotlineNumber",
                table: "Shops",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OpenTime",
                table: "Shops",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CloseTime",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "HotlineNumber",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "Shops");
        }
    }
}
