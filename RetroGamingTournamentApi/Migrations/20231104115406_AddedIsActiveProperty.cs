using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class AddedIsActiveProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tournaments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Events");
        }
    }
}
