using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportManagement.Database.Migrations
{
    public partial class addPlateNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlateNumber",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlateNumber",
                table: "Vehicles");
        }
    }
}
