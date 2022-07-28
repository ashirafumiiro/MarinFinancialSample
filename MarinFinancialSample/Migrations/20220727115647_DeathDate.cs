using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarinFinancialSample.Migrations
{
    public partial class DeathDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeath",
                table: "Authors",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfDeath",
                table: "Authors");
        }
    }
}
