using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetroGamingTournament.Migrations
{
    public partial class addedNumberOfPlayerspropertytoGamemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Banner",
                table: "Games",
                newName: "BannerFile");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPlayers",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "NumberOfPlayers" },
                values: new object[] { "Mortal Kombat 3", 2 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NumberOfPlayers" },
                values: new object[] { "Micro Machines", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfPlayers",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "BannerFile",
                table: "Games",
                newName: "Banner");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Mortal Kombat 2");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mortal Kombat 3");
        }
    }
}
