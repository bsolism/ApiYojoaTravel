using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiYojoaTravel.Migrations
{
    public partial class ActualizacionUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sal",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sal",
                table: "User");
        }
    }
}
