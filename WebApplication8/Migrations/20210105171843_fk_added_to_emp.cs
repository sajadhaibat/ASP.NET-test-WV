using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication8.Migrations
{
    public partial class fk_added_to_emp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MovieId",
                table: "Employees",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Movie_MovieId",
                table: "Employees",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Movie_MovieId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_MovieId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Employees");
        }
    }
}
