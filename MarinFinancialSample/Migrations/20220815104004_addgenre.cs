using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarinFinancialSample.Migrations
{
    public partial class addgenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Authors",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_GenreId",
                table: "Authors",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Genres_GenreId",
                table: "Authors",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Genres_GenreId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_GenreId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Authors");
        }
    }
}
