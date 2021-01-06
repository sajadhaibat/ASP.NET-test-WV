using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class add_superstars_fk_to_emp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SuperStars_SuperStrasId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "superstar_id",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SuperStrasId",
                table: "Employees",
                newName: "SuperStarsId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SuperStrasId",
                table: "Employees",
                newName: "IX_Employees_SuperStarsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SuperStars_SuperStarsId",
                table: "Employees",
                column: "SuperStarsId",
                principalTable: "SuperStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SuperStars_SuperStarsId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "SuperStarsId",
                table: "Employees",
                newName: "SuperStrasId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_SuperStarsId",
                table: "Employees",
                newName: "IX_Employees_SuperStrasId");

            migrationBuilder.AddColumn<int>(
                name: "superstar_id",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SuperStars_SuperStrasId",
                table: "Employees",
                column: "SuperStrasId",
                principalTable: "SuperStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
