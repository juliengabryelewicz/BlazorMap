using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMap.Server.Migrations
{
    public partial class AddCategoriesLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Markers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Markers_CategoryId",
                table: "Markers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Categories_CategoryId",
                table: "Markers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Categories_CategoryId",
                table: "Markers");

            migrationBuilder.DropIndex(
                name: "IX_Markers_CategoryId",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Markers");
        }
    }
}
