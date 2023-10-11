using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class changedplayerpropertyNameAudioFileUrltoNAmeAudioFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAudioUrl",
                table: "Players",
                newName: "NameAudioFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameAudioFile",
                table: "Players",
                newName: "NameAudioUrl");
        }
    }
}
