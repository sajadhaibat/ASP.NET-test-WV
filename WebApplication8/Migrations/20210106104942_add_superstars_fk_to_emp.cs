using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class add_superstars_fk_to_emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuperStrasId",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "superstar_id",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SuperStrasId",
                table: "Employees",
                column: "SuperStrasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SuperStars_SuperStrasId",
                table: "Employees",
                column: "SuperStrasId",
                principalTable: "SuperStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SuperStars_SuperStrasId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SuperStrasId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SuperStrasId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "superstar_id",
                table: "Employees");
        }
    }
}
