using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class newStages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "RankingPlay5-8" });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "RankingPlay9-10" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
