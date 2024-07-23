using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MatchdayMadness2.Migrations
{
    /// <inheritdoc />
    public partial class relacioniTeamsPlayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Teamsid",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_Teamsid",
                table: "Players",
                column: "Teamsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_Teamsid",
                table: "Players",
                column: "Teamsid",
                principalTable: "Teams",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_Teamsid",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_Teamsid",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Teamsid",
                table: "Players");
        }
    }
}
