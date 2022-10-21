using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorMap.Server.Migrations
{
    public partial class setNullOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Categories_CategoryId",
                table: "Markers");

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Categories_CategoryId",
                table: "Markers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Categories_CategoryId",
                table: "Markers");

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Categories_CategoryId",
                table: "Markers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
