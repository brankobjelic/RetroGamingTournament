using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class modifiedmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Groups_GroupId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Players_PlayerId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_PlayerId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Players_GroupId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "GroupPlayer",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPlayer", x => new { x.GroupsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_GroupPlayer_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupPlayer_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupPlayer_PlayersId",
                table: "GroupPlayer",
                column: "PlayersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupPlayer");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_PlayerId",
                table: "Tournaments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GroupId",
                table: "Players",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Groups_GroupId",
                table: "Players",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Players_PlayerId",
                table: "Tournaments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
