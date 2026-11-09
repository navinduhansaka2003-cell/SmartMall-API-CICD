using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMall.API.Migrations
{
    /// <inheritdoc />
    public partial class AddFloorAndCategoryToEntertainment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Entertainment",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "Entertainment",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Entertainment");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Entertainment");
        }
    }
}
