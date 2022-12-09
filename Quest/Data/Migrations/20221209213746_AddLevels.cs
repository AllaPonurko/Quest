using Microsoft.EntityFrameworkCore.Migrations;

namespace Quest.Data.Migrations
{
    public partial class AddLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DifficultyLevel",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelOfFear",
                table: "Quests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfPlayers",
                table: "Quests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DifficultyLevel",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "LevelOfFear",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "NumberOfPlayers",
                table: "Quests");
        }
    }
}
