using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class add_superstart_fk_to_emp_new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_SuperStars_SuperStarsId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "SuperStarsId",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AlterColumn<int>(
                name: "SuperStarsId",
                table: "Employees",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_SuperStars_SuperStarsId",
                table: "Employees",
                column: "SuperStarsId",
                principalTable: "SuperStars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
