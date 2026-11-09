using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartMall.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveLocationColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Entertainment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Entertainment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Entertainment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "");

            migrationBuilder.UpdateData(
                table: "Entertainment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "");

            migrationBuilder.UpdateData(
                table: "Entertainment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Location",
                value: "");
        }
    }
}
