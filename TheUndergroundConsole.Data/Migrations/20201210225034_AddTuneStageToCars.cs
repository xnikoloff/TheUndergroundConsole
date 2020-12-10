using Microsoft.EntityFrameworkCore.Migrations;

namespace TheUndergroundConsole.Data.Migrations
{
    public partial class AddTuneStageToCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TuneStage",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TuneStage",
                table: "Cars");
        }
    }
}
