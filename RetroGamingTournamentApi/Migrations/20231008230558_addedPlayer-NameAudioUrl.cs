using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class addedPlayerNameAudioUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameAudioUrl",
                table: "Players",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAudioUrl",
                table: "Players");
        }
    }
}
