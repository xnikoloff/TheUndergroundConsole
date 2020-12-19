using Microsoft.EntityFrameworkCore.Migrations;

namespace TheUndergroundConsole.Data.Migrations
{
    public partial class AddRacerEventModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceEvents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(nullable: false),
                    RivalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceEvents_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RaceEvents_Players_RivalId",
                        column: x => x.RivalId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceEvents_PlayerId",
                table: "RaceEvents",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceEvents_RivalId",
                table: "RaceEvents",
                column: "RivalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceEvents");
        }
    }
}
