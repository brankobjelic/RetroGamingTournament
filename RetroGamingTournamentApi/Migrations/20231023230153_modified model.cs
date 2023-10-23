using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class modifiedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Groups_GroupId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_StageTournament_Stages_TournamentStagesId",
                table: "StageTournament");

            migrationBuilder.DropTable(
                name: "GroupScores");

            migrationBuilder.DropTable(
                name: "MatchPlayers");

            migrationBuilder.DropTable(
                name: "PlayerTournament");

            migrationBuilder.DropTable(
                name: "TournamentPlayer");

            migrationBuilder.DropIndex(
                name: "IX_Matches_GroupId",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "NumberOfPlayers",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TournamentId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "NumberOfGroupContestants",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "TournamentStagesId",
                table: "StageTournament",
                newName: "StagesId");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Tournaments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_EventId",
                table: "Tournaments",
                column: "EventId");

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
                name: "FK_StageTournament_Stages_StagesId",
                table: "StageTournament",
                column: "StagesId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Events_EventId",
                table: "Tournaments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Players_PlayerId",
                table: "Tournaments",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Groups_GroupId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_StageTournament_Stages_StagesId",
                table: "StageTournament");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Events_EventId",
                table: "Tournaments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Players_PlayerId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_EventId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_PlayerId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Players_GroupId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "StagesId",
                table: "StageTournament",
                newName: "TournamentStagesId");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPlayers",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TournamentId",
                table: "Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGroupContestants",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GroupScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupScores_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupScores_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchPlayers_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTournament",
                columns: table => new
                {
                    TournamentPlayersId = table.Column<int>(type: "int", nullable: false),
                    TournamentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournament", x => new { x.TournamentPlayersId, x.TournamentsId });
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Players_TournamentPlayersId",
                        column: x => x.TournamentPlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTournament_Tournaments_TournamentsId",
                        column: x => x.TournamentsId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentPlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TournamentPlayer_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_GroupId",
                table: "Matches",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_TournamentId",
                table: "Matches",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupScores_GroupId",
                table: "GroupScores",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupScores_PlayerId",
                table: "GroupScores",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_MatchId",
                table: "MatchPlayers",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchPlayers_PlayerId",
                table: "MatchPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTournament_TournamentsId",
                table: "PlayerTournament",
                column: "TournamentsId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_GroupId",
                table: "TournamentPlayer",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_PlayerId",
                table: "TournamentPlayer",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentPlayer_TournamentId",
                table: "TournamentPlayer",
                column: "TournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Groups_GroupId",
                table: "Matches",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Tournaments_TournamentId",
                table: "Matches",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StageTournament_Stages_TournamentStagesId",
                table: "StageTournament",
                column: "TournamentStagesId",
                principalTable: "Stages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
