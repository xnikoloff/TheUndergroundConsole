using Microsoft.EntityFrameworkCore.Migrations;

namespace TheUndergroundConsole.Data.Migrations
{
    public partial class AddModficationPropToCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Modification",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Cars");
        }
    }
}
