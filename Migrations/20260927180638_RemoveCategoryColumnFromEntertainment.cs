using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMall.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCategoryColumnFromEntertainment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Entertainment");

            migrationBuilder.CreateIndex(
                name: "IX_Entertainment_CategoryId",
                table: "Entertainment",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Entertainment_FloorId",
                table: "Entertainment",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entertainment_Categories_CategoryId",
                table: "Entertainment",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entertainment_Floors_FloorId",
                table: "Entertainment",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entertainment_Categories_CategoryId",
                table: "Entertainment");

            migrationBuilder.DropForeignKey(
                name: "FK_Entertainment_Floors_FloorId",
                table: "Entertainment");

            migrationBuilder.DropIndex(
                name: "IX_Entertainment_CategoryId",
                table: "Entertainment");

            migrationBuilder.DropIndex(
                name: "IX_Entertainment_FloorId",
                table: "Entertainment");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Entertainment",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
